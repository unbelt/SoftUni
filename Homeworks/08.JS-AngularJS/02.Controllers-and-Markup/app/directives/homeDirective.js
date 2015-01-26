'use strict';

videoApp.directive('homeDirective', function() {
    return {
        restrict: 'A',
        templateUrl: 'views/directives/home-directive.html',
        scope: {
            album: '='
        }
    }
});