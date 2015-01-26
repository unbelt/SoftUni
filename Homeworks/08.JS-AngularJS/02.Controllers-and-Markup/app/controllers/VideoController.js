'use strict';

videoApp.controller('VideoController',
    function VideoController($scope, videoData) {

        function like(comment) {
            comment.likes++;
        }
        function dislike(comment) {
            comment.dislikes++;
        }

        $scope.like = like;
        $scope.dislike = dislike;
        $scope.video = videoData.getVideo(1);
    }
);