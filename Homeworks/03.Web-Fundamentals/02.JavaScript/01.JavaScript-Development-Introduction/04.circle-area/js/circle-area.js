function calcCircleArea(r) {
    'use strict';
    var radius = r.value;
    var area = Math.PI * Math.pow(radius, 2);
    var result;

    if(isNaN(radius)) {
        alert(radius + ' is not a number!');
    }
    else if (!radius) {
        alert('Enter a value!');
    }
    else {
        result = document.createTextNode('r = ' + radius + '; ' + 'area = ' + area);
        document.body.appendChild(document.createElement('br'));
        document.body.appendChild(result);
    }
}