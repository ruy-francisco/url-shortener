app.factory('urlShortenerService', ['$http', 
    function ($http) {
        var service = {};

        service.shorten = function (url) {
            let baseUrl = "http://localhost:5000";
            let apiUrl = baseUrl + "/api/UrlShortener/Shorten";

            let params = {
                "url": url
            };

            return $http.post(apiUrl, params)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        return service;
    }]);