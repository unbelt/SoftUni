// 10. Write a JavaScript function reverseString(value) that reverses string and returns it.
//     Write JS program stringReverser.js that invokes your function with the sample input
//     data below and prints the output at the console.

function reverseString(value) {
    'use strict';

    return value.split('').reverse().join('');
}

['sample', 'softUni', 'java script'].forEach(function (value) {
    console.log(reverseString(value));
});