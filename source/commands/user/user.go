package user

import (
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/config"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/passwordHistory"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/user"
	"strings"
	"time"
)

func ListUsers() []user.User {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var users []user.User
	db.Find(&users)

	return users
}

func SaveUser(fullname string, email string, document string, usuario string, typeUser int) {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}
	dbUser.FullName = fullname
	dbUser.Email = email
	dbUser.Document = document
	dbUser.IsBlocked = false
	dbUser.CountBlocked = 0
	dbUser.Password = utils.RandStringBytes(8)
	dbUser.DateUpdatePassword = time.Now()
	dbUser.UpdatePassword = config.GetUpdatePassword()
	dbUser.User = usuario
	dbUser.TypeUser = typeUser

	db.Create(&dbUser)
}

func ChangePassword(password string, usuario string, update bool, policy bool) (bool, []int) {

	var resultado bool
	var codigoError []int

	if policy {
		resultado, codigoError = ValidatePassword(password, usuario)
	} else {
		resultado = true
	}

	if resultado {
		encrypt_password, _ := utils.Encrypt(password)

		resultado := config.GetCountPasswordHistory(usuario)

		if resultado == passwordHistory.CountHistory(usuario) {
			passwordHistory.DeleteOldPassword(usuario)
		}

		passwordHistory.SavePasswordHistory(encrypt_password, usuario)

		db, error := gorm.Open(utils.Connector, utils.NameDatabase)
		defer db.Close()

		utils.CheckPanic(error)

		var dbUser = user.User{}
		db.Where("user = ?", usuario).First(&dbUser)

		dbUser.Password = encrypt_password
		dbUser.DateUpdatePassword = time.Now()
		dbUser.UpdatePassword = update

		db.Save(&dbUser)

		return true, []int{0}
	} else {
		return resultado, codigoError
	}
}

func ValidatePassword(password string, usuario string) (bool, []int) {
	resultado := true

	var codigoErrors []int

	resultado = resultado && utils.CountDigits(password) >= config.GetPolicyDigits()
	if !resultado {
		codigoErrors = append(codigoErrors, 1)
	}

	resultado = resultado && utils.CountLetter(password) >= config.GetPolicyLetters()
	if !resultado {
		codigoErrors = append(codigoErrors, 2)
	}

	resultado = resultado && utils.CountCapitalLetter(password) >= config.GetPolicyCapitalLetters()
	if !resultado {
		codigoErrors = append(codigoErrors, 3)
	}

	resultado = resultado && utils.CountSpecialCharacter(password) >= config.GetPolicySpecialCharacter()
	if !resultado {
		codigoErrors = append(codigoErrors, 4)
	}

	if config.GetPolicyBasicData() {
		resultado = resultado && !validateBasicData(password, usuario)
	}

	if !resultado {
		codigoErrors = append(codigoErrors, 5)
	}

	resultado = resultado && !validatePasswordHistory(password, usuario)
	if !resultado {
		codigoErrors = append(codigoErrors, 6)
	}

	resultado = resultado && !validateDictonary(password)
	if !resultado {
		codigoErrors = append(codigoErrors, 7)
	}

	resultado = resultado && utils.CountDiferents(usuario, password) >= config.GetPolicyLogin()
	if !resultado {
		codigoErrors = append(codigoErrors, 8)
	}

	return resultado, codigoErrors
}

func validatePasswordHistory(password string, usuario string) bool {
	lasts_passwords := passwordHistory.GetPasswordHistory(usuario)

	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	sw := false
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		if utils.Contains(lasts_passwords, password) {
			for _, last_password := range lasts_passwords {
				sw = sw || utils.CountDiferents(last_password, password) >= config.GetPolicyLastPassword()
			}
		}
	}

	return sw
}

func validateDictonary(password string) bool {
	words := config.GetPolicyDictionary()

	resultado := false

	for _, word := range words {
		resultado = resultado || strings.Contains(password, word.Texto)
	}

	return resultado
}

func validateBasicData(password string, usuario string) bool {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	sw := false
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		names := strings.Split(dbUser.FullName, " ")
		mails := strings.Split(dbUser.Email, "@")
		compare := []string{dbUser.Document}
		compare = append(compare, names...)
		compare = append(compare, mails...)

		sw = sw || utils.Contains(compare, password)
	}

	return sw
}

func ValidateUser(password string, usuario string) bool {

	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	sw := false
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		if dbUser.IsBlocked == false {
			decryt_password, _ := utils.Decrypt(dbUser.Password)

			if password == decryt_password {
				sw = true
			} else {
				AddBlocked(usuario)
			}
		}
	}

	return sw
}

func AddBlocked(usuario string) {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		dbUser.CountBlocked = dbUser.CountBlocked + 1
		if dbUser.CountBlocked == config.GetCountFailedLogin() {
			dbUser.IsBlocked = true
		}

		db.Save(dbUser)
	}
}

func RescuePassword(usuario string) string {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	new_password := ""
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		new_password = utils.RandStringBytes(8)
		ChangePassword(new_password, usuario, config.GetUpdatePassword(), false)
	}

	return new_password
}

func GetUpdatePassword(usuario string) bool {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	resultado := false
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		resultado = dbUser.UpdatePassword
	}

	return resultado
}

func IsVigentePassword(usuario string) bool {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	resultado := false
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		t1 := dbUser.DateUpdatePassword
		t2 := time.Now()
		days := int(t2.Sub(t1).Hours() / 24)

		resultado = days >= config.GetDaysPassword()
	}

	return resultado
}

func GetDocumentUser(usuario string) string {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	resultado := ""
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		resultado = dbUser.Document
	}

	return resultado
}

func GetTypeUser(usuario string)int{
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbUser = user.User{}

	resultado := user.Normal
	if err := db.Where("user = ?", usuario).First(&dbUser).Error; err == nil {
		resultado = dbUser.TypeUser
	}

	return resultado
}
