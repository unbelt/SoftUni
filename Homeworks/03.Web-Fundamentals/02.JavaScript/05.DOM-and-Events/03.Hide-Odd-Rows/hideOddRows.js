(function () {
    'use strict';

    var button = document.getElementById('btnHideOddRows'),
        rows = document.querySelectorAll('tr'),
        i, len;

    button.onclick = function () {
        for (i = 0, len = rows.length; i < len; i += 2) {
            rows[i].innerHTML = '';
        }
    }
}());


