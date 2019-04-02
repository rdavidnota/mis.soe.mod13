package main

import (
	"github.com/gorilla/mux"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers/config"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers/user"
	"log"
	"net/http"
)

func main() {

	utils.Migrate()

	var router = mux.NewRouter()

	router.HandleFunc("/", handlers.MainHandler)
	router.HandleFunc("/configuration", config.ChangueLevelConfigurationHandler).Queries("level", "{level}").Methods(http.MethodPost)
	router.HandleFunc("/users", user.ListUsersHandler).Methods(http.MethodGet)
	router.HandleFunc("/user_validate", user.ValidateUserHandler).Methods(http.MethodGet).Queries("password", "{password}", "usuario", "{usuario}")
	router.HandleFunc("/rescue_password", user.RescueUserHandler).Methods(http.MethodPost).Queries("usuario", "{usuario}")
	router.HandleFunc("/update_password", user.UpdatePasswordUserHandler).Methods(http.MethodPost).Queries("usuario", "{usuario}")
	router.HandleFunc("/change_password", user.ChanguePasswordUserHandler).Methods(http.MethodPost).Queries("password", "{password}", "usuario", "{usuario}", "document", "{document}")
	router.HandleFunc("/user_validate", user.VigentePasswordUserHandler).Methods(http.MethodGet).Queries("usuario", "{usuario}")

	http.Handle("/", router)

	log.Fatal(http.ListenAndServe(":9000", router))
}
