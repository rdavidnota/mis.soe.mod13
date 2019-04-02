package utils

import (
	"crypto/aes"
	"crypto/cipher"
	"crypto/rand"
	"encoding/base64"
	"fmt"
	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/sqlite"
	"github.com/pkg/errors"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/config"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/passwordHistory"
	"github.com/rdavidnota/mis.soe.mod13/source/domain/user"
	"golang.org/x/crypto/bcrypt"
	"io"
	"log"
	rnd "math/rand"
	"strings"
	"time"
)

const (
	Connector    = "sqlite3"
	NameDatabase = "test.db"
	Key          = "a very very very very secret key"
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

// See alternate IV creation from ciphertext below
//var iv = []byte{35, 46, 57, 24, 85, 35, 24, 74, 87, 35, 88, 98, 66, 32, 14, 05}

func Encrypt(text string) (string, error) {
	key := []byte(Key)
	byte_text := []byte(text)
	block, err := aes.NewCipher(key)
	if err != nil {
		return "", err
	}
	b := base64.StdEncoding.EncodeToString(byte_text)
	ciphertext := make([]byte, aes.BlockSize+len(b))
	iv := ciphertext[:aes.BlockSize]
	if _, err := io.ReadFull(rand.Reader, iv); err != nil {
		return "", err
	}
	cfb := cipher.NewCFBEncrypter(block, iv)
	cfb.XORKeyStream(ciphertext[aes.BlockSize:], []byte(b))
	var result string
	result = string(ciphertext)
	return result, nil
}

func Decrypt(text string) (string, error) {
	key := []byte(Key)
	encrypt_text := []byte(text)
	block, err := aes.NewCipher(key)
	if err != nil {
		return "", err
	}
	if len(encrypt_text) < aes.BlockSize {
		return "", errors.New("ciphertext too short")
	}
	iv := encrypt_text[:aes.BlockSize]
	encrypt_text = encrypt_text[aes.BlockSize:]
	cfb := cipher.NewCFBDecrypter(block, iv)
	cfb.XORKeyStream(encrypt_text, encrypt_text)
	data, err := base64.StdEncoding.DecodeString(string(encrypt_text))
	if err != nil {
		return "", err
	}
	result := string(data)
	return result, nil
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

	password_rnota, _ := Encrypt("mercado.nota")
	password_jnota, _ := Encrypt("jazmin.nota")

	var rnota = user.User{FullName: "Raul Nota", Document: "6391159", Email: "rdavid.nota@gmail.com", DateUpdatePassword: time.Now(), Password: password_rnota, TypeUser: user.Administrador, User: "rnota", IsBlocked: false}
	var jnota = user.User{FullName: "Jazmin Nota", Document: "7665894", Email: "jazmin.nota@gmail.com", DateUpdatePassword: time.Now(), Password: password_jnota, TypeUser: user.Normal, User: "jnota", IsBlocked: false}

	db.Create(&rnota)
	db.Create(&jnota)

}

const letterBytes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"

func RandStringBytes(n int) string {
	b := make([]byte, n)
	for i := range b {
		b[i] = letterBytes[rnd.Intn(len(letterBytes))]
	}
	return string(b)
}

func CountDigits(texto string) int {
	digits := []string{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
	resultado := 0
	for _, digit := range digits {
		resultado = strings.Count(texto, digit)
	}

	return resultado
}

func CountLetter(texto string) int {
	letters := []string{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
	resultado := 0
	for _, letter := range letters {
		resultado = strings.Count(texto, letter)
	}

	return resultado
}

func CountCapitalLetter(texto string) int {
	capitalLetters := []string{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
	resultado := 0
	for _, capitalLetter := range capitalLetters {
		resultado = strings.Count(texto, capitalLetter)
	}

	return resultado
}

func CountSymbols(texto string) int {
	symbols := []string{"$", "#", "&", "@", ".", "-", "_", "*"}
	resultado := 0
	for _, symbol := range symbols {
		resultado = strings.Count(texto, symbol)
	}

	return resultado
}
