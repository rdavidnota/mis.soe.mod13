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
	http.Handle("/", router)

	log.Fatal(http.ListenAndServe(":9000", router))
}
