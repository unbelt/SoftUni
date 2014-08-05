// 1. Write a JavaScript function printNumbers(n) that accepts as parameter integer n.
//    The function finds all integer numbers from 1 to n that are not divisible by 4 or by 5.
//    Write a JS program numberChecker.js that invokes your function with the sample input data below
//    and prints the output at the console.

function printNumbers(n) {
    'use strict';

    if (isNaN(n)) {
        throw 'Not a number!';
    }

    var result = [];

    for (var i = 0; i <= n; i++) {
        if (i % 4 == !0 || i % 5 == !0) {
            result.push(i);
        }
    }

    return result.join(', ') || 'no';
}

[20, -5, 13].forEach(function(value) {
    console.log(printNumbers(value));
});