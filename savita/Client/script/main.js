'use strict';

var apiserver = 'http://localhost:36081/';
var savita = angular.module('savita', ['ngResource', 'ngRoute', 'ngAnimate', 'ngSanitize']);

savita.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when('/shop',
        {
            templateUrl: 'template/shop.html'
        });

    $routeProvider.when('/',
        {
            templateUrl: 'template/home.html',
            controller: 'HomeController'
        });
		
    $routeProvider.when('/members',
        {
            templateUrl: 'template/members.html',
            controller: 'MembersController'
        });

    $routeProvider.when('/servers',
        {
            templateUrl: 'template/servers.html',
            controller: 'ServersController'
        });
    //$locationProvider.html5Mode(true);
});
