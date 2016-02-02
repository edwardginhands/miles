var app = angular.module('miles', []);

app.controller('milesCtl', function ($scope, $http) {
    $http.get('http://localhost:51685/api/journeys').then(function (resp) {
        $scope.journeys = resp.data;
    }, function (err) {
        console.error('ERR', err);
        // err.status will contain the status code
    })
})