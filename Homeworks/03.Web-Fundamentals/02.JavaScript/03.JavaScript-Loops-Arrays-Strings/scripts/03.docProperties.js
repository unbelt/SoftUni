//  3. Write a JavaScript function displayProperties(value)
//     that displays all the properties of the "document" object in alphabetical order.
//     Write a JS program docProperties.js that invokes your function with the sample
//     input data below and prints the output at the console.

function displayProperties(value) {
    'use strict';

    var properties = [],
        prop,
        submit = document.getElementById('submit');

    for (prop in value) {
        properties.push(prop);
    }

    properties = properties.sort().join('\r\n');

    submit.addEventListener('click', function() {
        document.body.innerText = properties;
    });

    return properties;
}

console.log(displayProperties(document));