// 9. Write a JavaScript function findMostFreqNum(value) that finds the most frequent number in an array.
//    If multiple numbers appear the same maximal number of times, print the leftmost of them.
//    Write JS program numberFinder.js that invokes your function with the sample input data below
//    and prints the output at the console.

function findMostFreqNum(array) {
    'use strict';

    var frequency = {},
        value,
        element = array[0],
        maxCount = 1,
        arrLength = array.length,
        i;

    for (i = 0; i < arrLength; i++) {
        value = array[i];

        if (frequency[value] == null) {
            frequency[value] = 1;
        }
        else {
            frequency[value]++;
        }
        if (frequency[value] > maxCount) {
            element = value;
            maxCount = frequency[value];
        }
    }

    return element + ' (' + (maxCount === 1 ?
        maxCount + ' time)' : maxCount + ' times)');
}

[
    [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
    [2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
].forEach(function (value) {
        console.log(findMostFreqNum(value));
    });