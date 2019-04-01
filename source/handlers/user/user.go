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
