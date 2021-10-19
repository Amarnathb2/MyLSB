(function () {

    var Locations_Svc = function ($http, $window) {

        var Search = function (searchValues) {

            var config = { headers: { 'Content-Type': 'application/json' } }

            return $http.post('/Api/Locations/GetLocations', searchValues, config)
               .then(
                   // success
                   function (response) {
                       return response.data
                   },
                   // failure
                   function (response) {
                       return response.data
                   }
                )
        }

        return {
            Search: Search
        };
    };

    var module = angular.module("Locations_App");
    module.factory("Locations_Svc", ["$http", "$window", Locations_Svc]);

}());