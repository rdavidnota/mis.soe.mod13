package passwordHistory

import (
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/passwordHistory"
	"time"
)

func SavePasswordHistory(password string, user string) {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var pwdHistory = passwordHistory.PasswordHistory{}
	pwdHistory.User = user
	pwdHistory.Password = password
	pwdHistory.Date = time.Now()

	db.Create(&pwdHistory)
}

func DeleteOldPassword(user string) {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)
	var pwdHistory = passwordHistory.PasswordHistory{}
	db.Where("user = ?", user).Last(&pwdHistory)
	db.Delete(&pwdHistory)
}

func CountHistory(user string) int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)
	var resultado int

	db.Model(passwordHistory.PasswordHistory{}).Where("user = ?", user).Count(&resultado)

	return resultado
}

func GetPasswordHistory(user string) []string {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)
	var resultado []string
	var history []passwordHistory.PasswordHistory

	db.Where("user = ?", user).Find(&history)

	for _, step := range history {
		password_decrypt, _ := utils.Decrypt(step.Password)
		resultado = append(resultado, password_decrypt)
	}

	return resultado

}
