package user

import (
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/config"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/passwordHistory"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/user"
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

func ChangePassword(password string, usuario string, update bool) {

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
}

func ValidatePassword(password string) bool {
	return true
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
		ChangePassword(new_password, usuario, config.GetUpdatePassword(usuario))
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
