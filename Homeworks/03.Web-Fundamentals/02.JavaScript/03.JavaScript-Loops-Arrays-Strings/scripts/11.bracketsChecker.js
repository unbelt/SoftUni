// 11. Write a JavaScript function checkBrackets(value) to check if in a given expression
//     the brackets are put correctly. Write JS program bracketsChecker.js that invokes your
//     function with the sample input data below and prints the output at the console.

function checkBrackets(value) {
    'use strict';
    var count = 0;

    value.split('').forEach(function (value) {
        if (value === '(') {
            count++;
        }
        if (value === ')') {
            count--;
        }
    });

    return count === 0 ? 'correct' : 'incorrect';
}

['( ( a + b ) / 5 – d )', ') ( a + b ) )', '( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )']
    .forEach(function (value) {
        console.log(checkBrackets(value));
    });