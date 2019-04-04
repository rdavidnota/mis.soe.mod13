package config

import (
	"encoding/json"
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
		if (level == 0) {

			var min_digits, _ = strconv.Atoi(r.URL.Query().Get("min_digits"))
			var min_letters, _ = strconv.Atoi(r.URL.Query().Get("min_letters"))
			var min_capitals, _ = strconv.Atoi(r.URL.Query().Get("min_capitals"))
			var min_special, _ = strconv.Atoi(r.URL.Query().Get("min_special"))
			var longitud, _ = strconv.Atoi(r.URL.Query().Get("longitud"))
			var max_days, _ = strconv.Atoi(r.URL.Query().Get("max_days"))

			config.SaveCustomConfiguration(min_digits, min_letters, min_capitals, min_special, longitud, max_days)
			w.WriteHeader(http.StatusOK)

		} else {
			if error == nil && config.ChangeLevelConfiguration(level) {
				w.WriteHeader(http.StatusOK)
			} else {
				w.WriteHeader(http.StatusInternalServerError)
			}
		}

	}
}

func GetConfiguration(w http.ResponseWriter, r *http.Request) {
	if auth.Authorizer(w, r) {
		var resultado = config.GetConfiguration()

		w.Header().Set("Content-Type", "application/json")
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(resultado)
	}
}
