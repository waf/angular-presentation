var app = angular.module('flightApp', ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            controller: 'FlightListController',
            templateUrl: "/Templates/flightlist.html"
        })
        .when("/flight/:id", {
            controller: 'FlightController',
            templateUrl: "/Templates/flight.html"
        });
});

app.controller('FlightListController', function ($scope, $http) {
    $http.get("/api/departures/").success(function (departures) {
        $scope.departures = departures;
    })
    $http.get("/api/destinations/").success(function (destinations) {
        $scope.destinations = destinations;
    });
    $scope.getFlights = function () {
        $http.get("/api/flights", {
            params: {
                departureCode: $scope.selectedDeparture,
                destinationCode: $scope.selectedDestination
            }
        })
        .success(function (flights) {
            $scope.flights = flights;
        });
    };
});

app.controller('FlightController', function ($scope, $http, $routeParams) {
    $http.get("/api/flights/" + $routeParams.id).success(function (flight) {
        $scope.flight = flight;
    });
});