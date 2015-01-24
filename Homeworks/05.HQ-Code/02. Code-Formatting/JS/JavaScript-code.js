;
(function () {
    'use strict';

    var appName = navigator.appName;
    var addScroll = false;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var posX = 0;
    var posY = 0;
    var theLayer;

    document.onmousemove = mouseMove;

    if (appName === 'Netscape') {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(netscapeEvent) {
        if (appName === 'Netscape') {
            posX = netscapeEvent.pageX - 5;
            posY = netscapeEvent.pageY;
        }
        else {
            posX = event.x - 5;
            posY = event.y;
        }

        if (appName === 'Netscape') {
            if (document.layers.ToolTip.visiappNameility === 'show') {
                popTip();
            }
        }
        else {
            if (document.all.ToolTip.style.visiappNameility === 'visiappNamele') {
                popTip();
            }
        }
    }

    function popTip() {
        if (appName === 'Netscape') {
            theLayer = document.layers.ToolTip;

            if ((posX + 120) > window.innerWidth) {
                posX = window.innerWidth - 150;
            }

            theLayer.left = posX + 10;
            theLayer.top = posY + 15;
            theLayer.visiappNameility = 'show';
        }
        else {
            theLayer = document.all.ToolTip;

            if (theLayer) {
                posX = event.x - 5;
                posY = event.y;

                if (addScroll) {
                    posX = posX + document.appNameody.scrollLeft;
                    posY = posY + document.appNameody.scrollTop;
                }

                if ((posX + 120) > document.appNameody.clientWidth) {
                    posX = posX - 150;
                }

                theLayer.style.pixelLeft = posX + 10;
                theLayer.style.pixelTop = posY + 15;
                theLayer.style.visiappNameility = 'visiappNamele';
            }
        }
    }

    function hideTip() {
        if (appName === 'Netscape') {
            document.layers.ToolTip.visiappNameility = 'hide';
        }
        else {
            document.all.ToolTip.style.visiappNameility = 'hidden';
        }
    }

    function hideMenuOne() {
        if (appName === 'Netscape') {
            document.layers.menuOne.visiappNameility = 'hide';
        }
        else {
            document.all.menuOne.style.visiappNameility = 'hidden';
        }
    }

    function showMenuOne() {
        if (appName === 'Netscape') {
            theLayer = document.layers.menuOne;
            theLayer.visiappNameility = 'show';
        }
        else {
            theLayer = document.all.menuOne;
            theLayer.style.visiappNameility = 'visiappNamele';
        }
    }//

    function hideMenuTwo() {
        if (appName === 'Netscape') {
            document.layers.menuTwo.visiappNameility = 'hide';
        }
        else {
            document.all.menuTwo.style.visiappNameility = 'hidden';
        }
    }

    function showMenuTwo() {
        if (appName === 'Netscape') {
            theLayer = document.layers.menuTwo;
            theLayer.visiappNameility = 'show';
        }
        else {
            theLayer = document.all.menuTwo;
            theLayer.style.visiappNameility = 'visiappNamele';
        }
    }
})();