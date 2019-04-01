package config

import (
	"github.com/rdavidnota/mis.soe.mod13/source/commands/config"
	"github.com/rdavidnota/mis.soe.mod13/source/commands/utils"
	"github.com/rdavidnota/mis.soe.mod13/source/handlers/auth"
	"net/http"
	"strconv"
)

func ChangueLevelConfigurationHandler(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var queryLevel = r.URL.Query().Get("level")
		level, error := strconv.Atoi(queryLevel)

		utils.Check(error)

		if error == nil && config.ChangeLevelConfiguration(level) {
			w.WriteHeader(http.StatusOK)
		} else {
			w.WriteHeader(http.StatusInternalServerError)
		}
	}
}
