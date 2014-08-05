// 14. Write a JavaScript function findPalindromes(value) that extracts from a given text
//     all palindromes, e.g. "ABBA", "lamal", "exe". Write JS program palindromesExtract.js
//     that invokes your function with the sample input data below and prints the output at the console.

function findPalindromes(value) {
    'use strict';

    var palindromes = [];

    value.split(/[\s,.!?]+/).forEach(function (value) {
        if(value.split('').reverse().join('').toLocaleLowerCase() === value.toLowerCase()) {
            palindromes.push(value.toLowerCase());
        }
    });

    return palindromes.filter(Boolean);

}

console.log(findPalindromes('There is a man, his name was Bob.'));