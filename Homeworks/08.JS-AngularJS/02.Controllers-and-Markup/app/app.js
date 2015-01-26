'use strict';

var videoApp = angular.module('videoApp', ['ngResource', 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'app/views/home.html',
                controller: 'HomeController'
            })
            .when('/video', {
                templateUrl: 'app/views/video.html',
                controller: 'VideoController'
            })
            .when('/add-video', {
                templateUrl: 'app/views/add-video.html',
                controller: 'AddVideoController'
            })
            .when('/edit-video', {
                templateUrl: 'app/views/edit-video.html',
                controller: 'EditVideoController'
            })
            .otherwise({redirectTo: '/home'});
    }
);