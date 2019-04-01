package utils

import (
	"fmt"
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/config"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/passwordHistory"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/user"
	"golang.org/x/crypto/bcrypt"
	"log"
	"time"
)

const (
	Connector    = "sqlite3"
	NameDatabase = "test.db"
)

func Check(err error) {
	if err != nil {
		fmt.Println(err)
	}
}

func CheckPanic(err error) {
	if err != nil {
		log.Fatal(err)
	}
}

func HashPassword(password string) string {
	bytes, err := bcrypt.GenerateFromPassword([]byte(password), 14)
	Check(err)
	return string(bytes)
}

func CheckPasswordHash(password, hash string) bool {
	err := bcrypt.CompareHashAndPassword([]byte(hash), []byte(password))
	return err == nil
}

func Migrate() {
	db, error := gorm.Open(Connector, NameDatabase)
	defer db.Close()

	CheckPanic(error)

	db.DropTableIfExists(&user.User{}, &config.PassCompose{}, &passwordHistory.PasswordHistory{}, &config.Word{})
	db.AutoMigrate(&user.User{}, &config.PassCompose{}, &passwordHistory.PasswordHistory{}, &config.Word{})

	var rnota = user.User{FullName: "Raul Nota", Document: "6391159", DateUpdatePassword: time.Now(), Password: HashPassword("mercado.nota"), TypeUser: user.Administrador, User: "rnota"}
	var jnota = user.User{FullName: "Jazmin Nota", Document: "7665894", DateUpdatePassword: time.Now(), Password: HashPassword("jazmin.nota"), TypeUser: user.Normal, User: "jnota"}

	db.Create(&rnota)
	db.Create(&jnota)

}
