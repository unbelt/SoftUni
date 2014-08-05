// 2. Write a JavaScript function findMinAndMax(value)
//    that accepts as parameter an array of numbers.
//    The function finds the minimum and the maximum number.
//    Write a JS program minMaxNumbers.js that invokes your function
//    with the sample input data below and prints the output at the console.

function findMinAndMax(value) {
    'use strict';

    return 'Min -> ' + Math.min.apply(null, value) +
        '\r\nMax -> ' + Math.max.apply(null, value) + '\r\n';
}

[
    [1, 2, 1, 15, 20, 5, 7, 31],
    [2, 2, 2, 2, 2],
    [500, 1, -23, 0, -300, 28, 35, 12]
].forEach(function (value) {
        console.log(findMinAndMax(value));
    });