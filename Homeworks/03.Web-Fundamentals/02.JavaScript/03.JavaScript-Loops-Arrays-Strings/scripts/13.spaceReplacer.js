// 13. Write a JavaScript function replaceSpaces(value) that replaces the
//     white-space characters in a text with &nbsp;. Write JS program spaceReplacer.js
//     that invokes your function with the sample input data below
//     and prints the output at the console.

function replaceSpaces(value) {
    'use strict';

    return value.replace(/ /g,'&nbsp;');
}

console.log(replaceSpaces('But you were living in another world tryin\' to get your message through'));