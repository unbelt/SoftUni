// 15. Write a JavaScript function findMostFreqWord(value) that finds
//     the most frequent word in a text and prints it, as well as how many
//     times it appears in format "word -> count". Consider any non-letter
//     character as a word separator. Ignore the character casing.
//     If several words have the same maximal frequency, print all of them
//     in alphabetical order. Write JS program frequentWord.js that invokes
//     your function with the sample input data below and prints the output at the console.

function findMostFreqWord(value) {
    'use strict';

    var i, j,
        item,
        sorted = [],
        result = [],
        wordCount = { },
        words = value.split(/[\s,.!?]+/);

    for (i = 0; i < words.length; i++) {
        wordCount[words[i].toLowerCase()] =
            (wordCount[words[i].toLowerCase()] || 0) + 1;
    }

    for (item in wordCount) {
        sorted.push([item, wordCount[item]]);
    }

    sorted.sort(function(a, b) {
        return a[1] - b[1];
    }).reverse();

    for (j = 0; j < sorted.length; j++) {
        if (sorted[0][1] === sorted[j][1] && sorted[j][1] !== undefined) {
            result.push(sorted[j][0] + ' -> ' + sorted[j][1] + ' times');
        }
    }

    return result.join('\r\n');
}

[
    'in the middle of the night',
    'Welcome to SoftUni. Welcome to Java. Welcome everyone.',
    'Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'
].forEach(function (value) {
        console.log(findMostFreqWord(value) + '\r\n');
    });