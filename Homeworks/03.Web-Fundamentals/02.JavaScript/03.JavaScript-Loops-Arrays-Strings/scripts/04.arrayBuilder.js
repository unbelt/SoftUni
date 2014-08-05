// 4. Write a JavaScript function createArray(value) that allocates array of 20 integers
//    and initializes each element by its index multiplied by 5. Write JS program arrayBuilder.js
//    that invokes your function with the sample input data below and prints the output at the console.

function createArray(value) {
    'use strict';

    var array = [];

    for (var i = 0; i <= value; i++) {
        array.push(i * 5);
    }

    return array;
}

console.log(createArray(20));