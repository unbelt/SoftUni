// 10. Write a JavaScript function checkDigit(value) that finds if the third digit (right-to-left)
//     of an integer number n (n>1000) is 3. Write JS program digitChecker.js that checks a few numbers.
//     The result (true or false) should be printed on the console. Run the program through Node.js.

function checkDigit(value) {
    if(value < 1000) {
        return 'The number cannot be less than 1000!';
    }

    var n = value.toString();
    return Number(n[n.length - 3]) === 3;
}

[1235, 25368, 123456].forEach(function (value) {
    console.log(checkDigit(value));
});