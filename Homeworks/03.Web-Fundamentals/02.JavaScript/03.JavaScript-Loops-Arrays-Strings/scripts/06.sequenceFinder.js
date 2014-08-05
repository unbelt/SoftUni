// 6. Write a JavaScript function findMaxSequence(value) that finds the maximal
//    sequence of equal elements in an array and returns the result as an array.
//    If there is more than one sequence with the same maximal length, print the rightmost one.
//    Write JS program sequenceFinder.js that invokes your function with the sample input data
//    below and prints the output at the console.

function findMaxSequence(value) {
    'use strict';

    if (value.length === 1) {
        return value;
    }

    var count = 0,
        maxCount = 0,
        bestValue;

    for (var i = 0; i < value.length - 1; i++) {

        if (value[i] === value[i + 1]) {
            count++;
        }
        else {
            count = 0;
        }

        if (maxCount <= count) {
            maxCount = count;
            bestValue = value[i];
        }
    }

    var result = [];

    for (var i = 0; i <= maxCount; i++) {
        result.push(bestValue);
    }

    return result;
}

[
    [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
    ['happy'],
    [2, 'qwe', 'qwe', 3, 3, '3']
].forEach(function (value) {
        console.log(findMaxSequence(value));
    });