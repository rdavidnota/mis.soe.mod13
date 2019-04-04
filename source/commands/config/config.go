package config

import (
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/config"
	"math"
)

func ChangeLevelConfiguration(levelCode int) bool {
	switch levelCode {
	case config.Alto:
		changeHighConfiguration()
		break
	case config.Medio:
		changeMediumConfiguration()
		break
	case config.Bajo:
		changeLowConfiguration()
		break
	default:
		changeHighConfiguration()
		break
	}

	return true
}

func saveConfiguration(configuration config.PassCompose) {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	dbConfiguration.Letters = configuration.Letters
	dbConfiguration.AlphabetKeys = configuration.AlphabetKeys
	dbConfiguration.BasicData = configuration.BasicData
	dbConfiguration.CapitalLetter = configuration.CapitalLetter
	dbConfiguration.ChanguePassNewUser = configuration.ChanguePassNewUser
	dbConfiguration.CloseKeys = configuration.CloseKeys
	dbConfiguration.Dictionary = configuration.Dictionary
	dbConfiguration.Digits = configuration.Digits
	dbConfiguration.LastPass = configuration.LastPass
	dbConfiguration.Login = configuration.Login
	dbConfiguration.LogoutInactive = configuration.LogoutInactive
	dbConfiguration.LogoutInactiveTime = configuration.LogoutInactiveTime
	dbConfiguration.MaximumAlphabet = configuration.MaximumAlphabet
	dbConfiguration.MaximumClose = configuration.MaximumClose
	dbConfiguration.MaximumDaysChanguePassword = configuration.MaximumDaysChanguePassword
	dbConfiguration.MaximumFailedLogin = configuration.MaximumFailedLogin
	dbConfiguration.MaximunRepeatKeys = configuration.MaximunRepeatKeys
	dbConfiguration.MinimumCapitalLetters = configuration.MinimumCapitalLetters
	dbConfiguration.MinimumDiferentsToLogin = configuration.MinimumDiferentsToLogin
	dbConfiguration.MinimumDigits = configuration.MinimumDigits
	dbConfiguration.MinimumLetters = configuration.MinimumLetters
	dbConfiguration.MinimumSpecialCharacter = configuration.MinimumSpecialCharacter
	dbConfiguration.MinimunLength = configuration.MinimunLength
	dbConfiguration.NumberDiferentsLastPassword = configuration.NumberDiferentsLastPassword
	dbConfiguration.NumberSessions = configuration.NumberSessions
	dbConfiguration.PasswordHistory = configuration.PasswordHistory
	dbConfiguration.PasswordHistoryNumber = configuration.PasswordHistoryNumber
	dbConfiguration.RepeatKeys = configuration.RepeatKeys
	dbConfiguration.SessionUnique = configuration.SessionUnique
	dbConfiguration.SpecialCharacters = configuration.SpecialCharacters
	dbConfiguration.TimeBlockedFailedLogin = configuration.TimeBlockedFailedLogin

	db.Where("pass_compose_id = ?", dbConfiguration.ID).Find(&dbConfiguration.Words)

	for _, dbWord := range dbConfiguration.Words {
		sw := false
		for _, word := range configuration.Words {
			if word.Texto == dbWord.Texto {
				sw = true
			}
		}

		if sw == false {
			db.Delete(dbWord)
		}
	}

	db.Where("pass_compose_id = ?", dbConfiguration.ID).Find(&dbConfiguration.Words)

	for _, word := range configuration.Words {
		sw := false
		for _, dbWord := range dbConfiguration.Words {
			if word.Texto == dbWord.Texto {
				sw = true
			}
		}

		if sw == false {
			dbConfiguration.Words = append(dbConfiguration.Words, word)
		}
	}

	db.Save(&dbConfiguration)
}

func changeHighConfiguration() {
	var configuration = config.PassCompose{}

	configuration.Letters = true
	configuration.MaximumAlphabet = 1

	configuration.AlphabetKeys = true

	configuration.BasicData = true

	configuration.CapitalLetter = true
	configuration.MinimumCapitalLetters = 2
	configuration.MinimumLetters = 2

	configuration.ChanguePassNewUser = true

	configuration.CloseKeys = true
	configuration.MaximumClose = 1

	configuration.Digits = true
	configuration.MinimumDigits = 2

	configuration.LastPass = true
	configuration.NumberDiferentsLastPassword = 6

	configuration.Login = true
	configuration.MinimumDiferentsToLogin = 3

	configuration.LogoutInactive = true
	configuration.LogoutInactiveTime = 15

	configuration.MaximumDaysChanguePassword = 30
	configuration.MaximumFailedLogin = 3
	configuration.MinimunLength = 15

	configuration.PasswordHistory = true
	configuration.PasswordHistoryNumber = 8

	configuration.RepeatKeys = true
	configuration.MaximunRepeatKeys = 1

	configuration.SessionUnique = true
	configuration.NumberSessions = 1

	configuration.SpecialCharacters = true
	configuration.MinimumSpecialCharacter = 2

	configuration.TimeBlockedFailedLogin = 15

	configuration.Dictionary = true
	configuration.Words = []config.Word{}

	var word1 = config.Word{Texto: "654321"}
	var word2 = config.Word{Texto: "123456"}
	var word3 = config.Word{Texto: "admin"}

	configuration.Words = append(configuration.Words, word1, word2, word3)

	saveConfiguration(configuration)
	//saveWords(configuration.Words, configuration.ID)
}

func changeMediumConfiguration() {
	var configuration = config.PassCompose{}

	configuration.Letters = true
	configuration.MaximumAlphabet = 1

	configuration.AlphabetKeys = true

	configuration.BasicData = true

	configuration.CapitalLetter = true
	configuration.MinimumCapitalLetters = 1
	configuration.MinimumLetters = 1

	configuration.ChanguePassNewUser = true

	configuration.CloseKeys = true
	configuration.MaximumClose = 1

	configuration.Digits = true
	configuration.MinimumDigits = 1

	configuration.LastPass = true
	configuration.NumberDiferentsLastPassword = 5

	configuration.Login = true
	configuration.MinimumDiferentsToLogin = 3

	configuration.LogoutInactive = true
	configuration.LogoutInactiveTime = 15

	configuration.MaximumDaysChanguePassword = 30
	configuration.MaximumFailedLogin = 3
	configuration.MinimunLength = 10

	configuration.PasswordHistory = true
	configuration.PasswordHistoryNumber = 5

	configuration.RepeatKeys = true
	configuration.MaximunRepeatKeys = 3

	configuration.SessionUnique = true
	configuration.NumberSessions = 1

	configuration.SpecialCharacters = false
	configuration.MinimumSpecialCharacter = 0

	configuration.TimeBlockedFailedLogin = 15

	configuration.Dictionary = true
	configuration.Words = []config.Word{}

	var word1 = config.Word{Texto: "654321"}
	var word2 = config.Word{Texto: "123456"}
	var word3 = config.Word{Texto: "admin"}

	configuration.Words = append(configuration.Words, word1, word2, word3)

	saveConfiguration(configuration)
	//saveWords(configuration.Words, configuration.ID)
}

func changeLowConfiguration() {
	var configuration = config.PassCompose{}

	configuration.Letters = false
	configuration.MaximumAlphabet = math.MaxInt32

	configuration.AlphabetKeys = false

	configuration.BasicData = true

	configuration.CapitalLetter = false
	configuration.MinimumCapitalLetters = 0
	configuration.MinimumLetters = 1

	configuration.ChanguePassNewUser = true

	configuration.CloseKeys = false
	configuration.MaximumClose = math.MaxInt32

	configuration.Digits = true
	configuration.MinimumDigits = 1

	configuration.LastPass = true
	configuration.NumberDiferentsLastPassword = 3

	configuration.Login = true
	configuration.MinimumDiferentsToLogin = 2

	configuration.LogoutInactive = true
	configuration.LogoutInactiveTime = 20

	configuration.MaximumDaysChanguePassword = 30
	configuration.MaximumFailedLogin = 3
	configuration.MinimunLength = 8

	configuration.PasswordHistory = true
	configuration.PasswordHistoryNumber = 3

	configuration.RepeatKeys = false
	configuration.MaximunRepeatKeys = math.MaxInt32

	configuration.SessionUnique = true
	configuration.NumberSessions = 1

	configuration.SpecialCharacters = false
	configuration.MinimumSpecialCharacter = 0

	configuration.TimeBlockedFailedLogin = 15

	configuration.Dictionary = false
	configuration.Words = []config.Word{}

	saveConfiguration(configuration)
	//  saveWords(configuration.Words, configuration.ID)
}

func GetCountPasswordHistory(user string) int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.PasswordHistory {
		resultado = dbConfiguration.PasswordHistoryNumber
	}

	return resultado
}

func GetUpdatePassword() bool {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := dbConfiguration.ChanguePassNewUser

	return resultado
}

func GetDaysPassword() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := dbConfiguration.MaximumDaysChanguePassword

	return resultado
}

func GetCountFailedLogin() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := dbConfiguration.MaximumFailedLogin

	return resultado
}

func GetPolicyDigits() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.Digits {
		resultado = dbConfiguration.MinimumDigits
	}

	return resultado
}

func GetPolicyLetters() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.Letters {
		resultado = dbConfiguration.MinimumLetters
	}

	return resultado
}

func GetPolicyCapitalLetters() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.CapitalLetter {
		resultado = dbConfiguration.MinimumCapitalLetters
	}

	return resultado
}

func GetPolicySpecialCharacter() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.SpecialCharacters {
		resultado = dbConfiguration.MinimumSpecialCharacter
	}

	return resultado
}

func GetPolicyBasicData() bool {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := dbConfiguration.BasicData

	return resultado
}

func GetPolicyLastPassword() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.LastPass {
		resultado = dbConfiguration.NumberDiferentsLastPassword
	}

	return resultado
}

func GetPolicyDictionary() []config.Word {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	var resultado []config.Word

	if dbConfiguration.Dictionary {
		resultado = dbConfiguration.Words
	}

	return resultado
}

func GetPolicyLogin() int {
	db, error := gorm.Open(utils.Connector, utils.NameDatabase)
	defer db.Close()

	utils.CheckPanic(error)

	var dbConfiguration = config.PassCompose{}
	db.First(&dbConfiguration).Related(&config.Word{})

	resultado := 0

	if dbConfiguration.Login {
		resultado = dbConfiguration.MinimumDiferentsToLogin
	}

	return resultado
}
