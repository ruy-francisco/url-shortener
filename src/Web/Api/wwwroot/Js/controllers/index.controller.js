app.controller('indexController', ['$scope',  '$http', 'urlShortenerService',
    function ($scope, $http, urlShortenerService) {
        var vm = $scope;

        vm.originalUrl = "";
        vm.shortenedUrl = "";

        vm.shorten = function () {

            $http.defaults.headers.common['Access-Control-Allow-Origin'] = "*";

            urlShortenerService.shorten(vm.originalUrl)
                .then(function (response) {
                    console.log(response);
                })
        }
    }]);