// 14. Write a HTML page (with text field, button, and paragraph). Write JS program calcExpression.js
//     that calculates any expression put in the text field and prints it in the paragraph.
//     Link the JS file to the HTML file. (100% accuracy is not required).

function calcExpression(value) {
    var result = document.getElementById('result');

    (/[a-zA-Z]/.test(value.value) || eval(value.value) === undefined) ?
        result.innerText = 'Please enter an expression!' :
        result.innerText = eval(value.value);
}