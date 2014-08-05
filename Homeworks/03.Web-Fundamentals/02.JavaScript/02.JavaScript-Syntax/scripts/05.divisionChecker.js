// 5. Write a JavaScript function divisionBy3(value) that finds the sum of digits
//    of integer number n (n > 9) and checks if the sum is divided by 3 without remainder.
//    Write JS program divisionChecker.js to check a few numbers.
//    The result should be printed on the console (“the number is divided by 3 without remainder”
//    or “the number is not divided by 3 without remainder”). Run the program through Node.js.

function divisionBy3(value) {
    if (value < 10) {
        return 'The number cannot be with one digit!';
    }

    var sum = 0;

    value.toString().split('').forEach(function (value) {
        if (parseInt(value)) {
            sum += parseInt(value);
        }
    });

    return sum % 3 === 0 ?
        'the number is divided by 3 without remainder' :
        'the number is not divided by 3 without remainder';
}

[12, 188, 591].forEach(function (value) {
    console.log(divisionBy3(value))
});