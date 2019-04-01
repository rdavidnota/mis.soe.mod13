package config

import (
	"github.com/jinzhu/gorm"
)

const (
	Bajo          = 100
	Medio         = 200
	Alto          = 300
	Personalizado = 400
)

type PassCompose struct {
	gorm.Model
	Digits                  bool
	MinimumDigits           int
	Alphabet                bool
	MinimumLetters          int
	CapitalLetter           bool
	MinimumCapitalLetters   int
	SpecialCharacters       bool
	MinimumSpecialCharacter int
	MinimunLength           int

	ChanguePassNewUser         bool
	MaximumDaysChanguePassword int
	MaximumFailedLogin         int
	TimeBlockedFailedLogin     int
	LogoutInactive             bool
	LogoutInactiveTime         int
	SessionUnique              bool
	NumberSessions             int
	PasswordHistory            bool
	PasswordHistoryNumber      int

	BasicData                   bool
	Dictionary                  bool
	Words                       []Word `gorm:"foreignkey:PassComposeID"`
	Login                       bool
	MinimumDiferentsToLogin     int
	LastPass                    bool
	NumberDiferentsLastPassword int
	CloseKeys                   bool
	MaximumClose                int
	AlphabetKeys                bool
	MaximumAlphabet             int
	RepeatKeys                  bool
	MaximunRepeatKeys           int
}

type Word struct {
	gorm.Model
	Texto         string `gorm:"primary_key"`
	PassComposeID uint
}
