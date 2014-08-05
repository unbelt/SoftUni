// 11. Write a JavaScript function convertDigitToWord(value) that prints the name of an integer number n (0<n<10)
//     in English using switch statement. Write JS program digitAsWord.js that prints a few digits on the console.
//     Run the program through Node.js.

function convertDigitToWord(value) {
    if(value < 0 || value > 9) {
        return 'The number must be between 0 and 9';
    }

    var numberAsWord = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    return numberAsWord[value];
}

[8, 3, 5].forEach(function (value) {
    console.log(convertDigitToWord(value));
});