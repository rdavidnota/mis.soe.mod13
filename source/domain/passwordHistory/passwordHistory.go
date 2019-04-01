package passwordHistory

import (
	"github.com/jinzhu/gorm"
	"time"
)

type PasswordHistory struct {
	gorm.Model
	User     string
	Password string
	Date     time.Time
}
