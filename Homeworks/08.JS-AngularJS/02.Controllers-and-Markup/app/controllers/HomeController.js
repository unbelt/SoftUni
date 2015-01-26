'use strict';

videoApp.controller('HomeController',
    function HomeController($scope, videoData) {

        $scope.videos = videoData.getAllVideos();

        $scope.sort = '-date';
        $scope.category = '';
    }
);