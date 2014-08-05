// 2. Write a JavaScript function roundNumber(value) that rounds floating-point number using Math.round(), Math.floor().
//    Write a JS program roundingNumbers.js that rounds a few sample values. Run the program through Node.js.

function roundNumber(value) {
    return Math.floor(value) + '\r\n' + Math.round(value) + '\r\n';
}

[22.7, 12.3, 58.7].forEach(function(value) {
    console.log(roundNumber(value));
});