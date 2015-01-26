'use strict';

videoApp.factory('videoData', function ($resource) {

    var resource = $resource('/data/videos/:id', {id: '@id'});

    return {
        getVideo: function (id) {
            return resource.get({id: id})
        },
        saveVideo: function (video) {
            resource.save(video);
        },
        getAllVideos: function () {
            return resource.query();
        }
    }
});