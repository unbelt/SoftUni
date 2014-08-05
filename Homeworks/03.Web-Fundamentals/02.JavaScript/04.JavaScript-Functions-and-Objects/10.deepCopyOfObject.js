/**
* Write a JavaScript function clone(obj) that accept as parameter an object of reference type.  The function
* should return a deep copy of the object. Write a second function compareObjects(obj, objCopy) that compare
* the two objects by reference (==) and print on the console the output given below. Read in Internet about
* "deep copy" of an object and how to create it.
*/


(function() {
	var a = { name: 'Pesho', age: 21 } 
	var b = clone(a);
	compareObjects(a, b);  

	var a = { name: 'Pesho', age: 21 };
	var b = a;
	compareObjects(a, b);
}());


function clone(input) {
	return input = JSON.parse(JSON.stringify(input));
}

function compareObjects(a, b) {
	console.log('a == b --> ' + (a == b));
}