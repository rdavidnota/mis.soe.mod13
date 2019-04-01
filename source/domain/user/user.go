package user

import (
	"github.com/jinzhu/gorm"
	"time"
)

const (
	Administrador = 100
	Normal        = 200
)

type User struct {
	gorm.Model
	FullName           string
	Document           string
	User               string
	Password           string
	DateUpdatePassword time.Time
	TypeUser           int
}
