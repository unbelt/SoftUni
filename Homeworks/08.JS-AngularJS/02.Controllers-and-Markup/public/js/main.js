'use strict';

require.config({
    paths: {
        'jquery': '../../vendor/jquery/dist/jquery',
        'bootstrap': '../../vendor/bootstrap/dist/js/bootstrap'
    },
    shim: {
        'bootstrap': ['jquery']
    }
});

require(['bootstrap'], function () {
    $(function () {

        // Page show-up
        $('#status').fadeOut();
        $('#preloader').delay(150).fadeOut('slow');
        $('body').delay(150).css({'overflow': 'visible'});

        // target _blank to all external links
        $('body a').each(function () {
            if (this.href.indexOf(location.hostname) === -1) {
                $(this).attr('target', '_blank');
            }
        });
    });
});