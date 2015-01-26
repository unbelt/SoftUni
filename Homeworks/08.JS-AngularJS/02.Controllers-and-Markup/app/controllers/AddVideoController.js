'use strict';

videoApp.controller('AddVideoController',
    function AddVideoController($scope, videoData) {

        $scope.saveVideo = function saveVideo(video, addVideoForm) {
            if (addVideoForm.$valid) {
                video.id = 10;
                videoData.saveVideo(video);
                alert('Data Saved');
            }
            else {
                alert('Invalid data!');
            }
        };

        $scope.cancel = function cancel() {
            // TODO: Redirect
            console.log('cancel');
        };
    }
);