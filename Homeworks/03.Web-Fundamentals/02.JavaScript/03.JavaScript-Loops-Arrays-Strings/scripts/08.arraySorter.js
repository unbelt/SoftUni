// 8. Sorting an array means to arrange its elements in increasing order.
//    Write a JavaScript function sortArray(value) to sort an array.
//    Use the "selection sort" algorithm: find the smallest element,
//    move it at the first position, find the smallest from the rest,
//    move it at the second position, etc. Write JS program arraySorter.js
//    that invokes your function with the sample input data below and prints the output at the console.

function sortArray(array) {
    'use strict';

    var min = 0,
        oldValue = 0,
        arrLength = array.length,
        i, j;

    for (i = 0; i < arrLength - 1; i++) {
        min = i;

        for (j = i + 1; j < arrLength; j++) {
            if (array[j] < array[min]) {
                min = j;
            }
        }

        oldValue = array[min];
        array[min] = array[i];
        array[i] = oldValue;

    }

    return array;
}

[
    [5, 4, 3, 2, 1],
    [12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]
].forEach(function (value) {
        console.log(sortArray(value));
    });