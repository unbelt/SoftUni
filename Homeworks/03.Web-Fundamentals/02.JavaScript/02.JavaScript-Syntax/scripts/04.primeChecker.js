// 3. Write a JavaScript function isPrime(value) that checks if an integer number is prime.
//    Write JS program primeChecker.js that checks if a few numbers are prime.
//    The result should be printed on the console (true or false) on the console.
//    Run the program through Node.js.

function divisionBy3(value) {
    var count = 0;

    for (var i = 0; i < value; i++) {
        if (value % i === 0) {
            count++;
        }
    }

    return count === 1;
}

[7, 254, 587].forEach(function (value) {
    console.log(divisionBy3(value));
});