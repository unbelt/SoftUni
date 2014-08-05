// 7. Write a JavaScript function findMaxSequence(value) that finds the maximal
//    increasing sequence in an array of numbers and returns the result as an array.
//    If there is no increasing sequence the function returns 'no'.
//    Write JS program maxSequenceFinder.js that invokes your function
//    with the sample input data below and prints the output at the console.

function findMaxSequence(value) {
    'use strict';

    if (value.length === 1) {
        return value;
    }

    var count = 0,
        maxCount = 0,
        endIndex = 0,
        result = [],
        i;

    for (i = 0; i < value.length - 1; i++) {

        if (value[i] < value[i + 1]) {
            count++;
        }
        else {
            count = 0;
        }

        if (maxCount <= count) {
            maxCount = count;
            endIndex = i;
        }
    }

    if (maxCount === 0) {
        return 'no';
    }

    for (i = endIndex - maxCount + 1; i <= endIndex + 1; i++) {
        result.push(value[i]);
    }

    return result;
}

[
    [3, 2, 3, 4, 2, 2, 4],
    [3, 5, 4, 6, 1, 2, 3, 6, 10, 32],
    [3, 2, 1]
].forEach(function (value) {
        console.log(findMaxSequence(value));
    });