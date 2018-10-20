app.controller('indexController', ['$scope',  '$http', 'urlShortenerService',
    function ($scope, $http, urlShortenerService) {
        var vm = $scope;

        vm.originalUrl = "";
        vm.shortenedUrl = "";

        vm.shorten = function () {
            urlShortenerService.shorten(vm.originalUrl)
                .then(function (response) {
                    console.log(response);
                })
        }
    }]);