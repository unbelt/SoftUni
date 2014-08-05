// 3. Write a JavaScript function evenNumber(value) that checks if an integer number is even.
//    Write JS program evenChecker.js to check if a few numbers are even.
//    The result should be printed on the console (true or false).
//    Run the program through Node.js.

function evenNumber(value) {
    return value % 2 === 0;
}

[3, 127, 588].forEach(function (value) {
    console.log(evenNumber(value));
});