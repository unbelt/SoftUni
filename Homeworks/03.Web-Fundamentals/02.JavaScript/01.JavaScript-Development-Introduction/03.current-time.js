(function () {
    'use strict';
    var date = new Date();

    console.log(date.getHours() + ':' +
        (date.getMinutes() > 9 ? date.getMinutes() : '0' + date.getMinutes()));
}());