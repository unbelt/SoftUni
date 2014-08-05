/**
* Write a JavaScript function reverseWordsInString(str) to reverse the characters of every word in the
* string but leaves the words in the same order. Words are considered to be sequences of characters 
* separated by spaces. Write a JavaScript program reverseWords.js that prints on the console the output 
* of the examples below:
*				Input						Output
* Hello, how are you.				,olleH woh era .uoy
* Life is pretty good, isn’t it?	efiL si ytterp ,doog t'nsi ?ti
*/

function reverseWordsInString(str) {
	var words = str.split(' ');
	var length = words.length;

	for (var i = 0; i < length; i++) {
		var text = '';
		
		for (var j = words[i].length - 1; j >= 0 ; j--) {
			text += words[i][j];
		}

		words[i] = text;
	}

	return words.join(' ');
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString('Life is pretty good, isn’t it?'));