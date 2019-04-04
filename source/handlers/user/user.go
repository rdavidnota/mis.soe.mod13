package user

import (
	"encoding/json"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/user"
	userEntity "github.com/rdavidnota/mis.soe.mod13/source/domain/user"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers/auth"
	"net/http"
	"strconv"
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
		var email = r.URL.Query().Get("email")

		if user.IsValidMail(usuario, email) {
			new_password := user.RescuePassword(usuario)

			w.Header().Set("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
			json.NewEncoder(w).Encode(new_password)
		} else {
			w.WriteHeader(http.StatusForbidden)
		}
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
		var new_password = r.URL.Query().Get("new_password")
		var usuario = r.URL.Query().Get("usuario")
		var document = r.URL.Query().Get("document")

		var codigos []int

		if document == user.GetDocumentUser(usuario) && user.ValidateUser(password, usuario) {
			_, codigos = user.ChangePassword(new_password, usuario, false, true)
		}

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)

		json.NewEncoder(w).Encode(codigos)
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

func SaveUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {

		var usuario_admin = r.URL.Query().Get("usuario_admin")
		var fullname = r.URL.Query().Get("fullname")
		var email = r.URL.Query().Get("email")
		var document = r.URL.Query().Get("document")
		var usuario = r.URL.Query().Get("usuario")
		var paramTypeUser = r.URL.Query().Get("typeUser")

		typeUser, _ := strconv.Atoi(paramTypeUser)

		if user.GetTypeUser(usuario_admin) == userEntity.Administrador {
			user.SaveUser(fullname, email, document, usuario, typeUser)

			w.Header().Set("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
			json.NewEncoder(w).Encode(true)
		} else {
			w.WriteHeader(http.StatusForbidden)
		}
	}
}

func GetUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var usuario = r.URL.Query().Get("usuario")

		resultado := user.GetUser(usuario)

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(resultado)

	}
}

func BlockedUserHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var usuario = r.URL.Query().Get("usuario")
		var usuario_admin = r.URL.Query().Get("usuario_admin")

		if user.GetTypeUser(usuario_admin) == userEntity.Administrador {
			user.SetBlocked(usuario)

			w.Header().Set("Content-Type", "application/json")
			w.WriteHeader(http.StatusOK)
		} else {
			w.WriteHeader(http.StatusForbidden)
		}
	}
}
