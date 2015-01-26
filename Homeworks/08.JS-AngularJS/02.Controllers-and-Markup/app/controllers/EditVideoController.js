'use strict';

videoApp.controller('EditVideoController',
    function EditVideoController($scope) {

        $scope.saveVideo = function saveVideo(video, editVideoForm) {
            if (editVideoForm.$valid) {
                console.log(video);
            }
            else {
                alert('Invalid data!')
            }
        };

        $scope.cancel = function cancel() {
            // TODO: Redirect
            console.log('cancel');
        };
    }
);