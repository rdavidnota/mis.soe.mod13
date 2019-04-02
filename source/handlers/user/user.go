package user

import (
	"encoding/json"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/user"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers/auth"
	"net/http"
)

func ListUsersHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		users := user.ListUsers()

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(users)
	}
}

func ValidateUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var password = r.URL.Query().Get("password")
		var usuario = r.URL.Query().Get("usuario")
		isOk := user.ValidateUser(password, usuario)

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(isOk)
	}
}

func RescueUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var usuario = r.URL.Query().Get("usuario")
		new_password := user.RescuePassword(usuario)

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(new_password)
	}
}

func UpdatePasswordUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var usuario = r.URL.Query().Get("usuario")
		resultado := user.GetUpdatePassword(usuario)

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(resultado)
	}
}

func ChanguePasswordUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var password = r.URL.Query().Get("password")
		var usuario = r.URL.Query().Get("usuario")
		var document = r.URL.Query().Get("document")

		if document == user.GetDocumentUser(usuario) {
			user.ChangePassword(password, usuario, false)
		}

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(true)
	}
}

func VigentePasswordUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var usuario = r.URL.Query().Get("usuario")
		resultado := user.IsVigentePassword(usuario)

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(resultado)
	}
}
