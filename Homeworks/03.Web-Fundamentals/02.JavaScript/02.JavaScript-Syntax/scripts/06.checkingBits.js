// 6. Write a JavaScript function bitChecker(value) that finds if the bit 3 an integer number (counting from 0) is 1.
//    Write JS program checkingBits.js to check a few numbers. The result (true or false) should be printed on the console.
//      Run the program through Node.js.

function bitChecker(value) {
    var binary = Number(value).toString(2);

    return Number(binary[binary.length - 4]) === 1;
}

[333, 425, 2567564754].forEach(function (value) {
    console.log(bitChecker(value));
});