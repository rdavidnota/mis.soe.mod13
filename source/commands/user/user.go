package user

import (
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/user"
)

func ListUsers() []user.User {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var users []user.User
	db.Find(&users)

	return users
}
