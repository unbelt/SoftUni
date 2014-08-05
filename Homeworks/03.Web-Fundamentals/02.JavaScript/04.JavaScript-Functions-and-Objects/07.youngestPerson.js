/**
* Write a JavaScript function findYoungestPerson(persons) that accepts as parameter an array of persons,
* finds the youngest person and returns his full name. Write a JS program youngestPerson.js to execute your
* function for the below examples and print the result at the console.
*/

function findYoungestPerson(persons) {
	var index = 0;
	var minAges = Number.MAX_VALUE;
	var opit = Number.MIN_VALUE;
	
	for (var i = 0; i < persons.length; i++) {
		if (persons[i].age < minAges ) {
			minAges = persons[i].age;
			index = i;
		}
	}

	console.log('The youngest person is ' + persons[index].firstname +
				 ' ' + persons[index].lastname);
}

var persons = [
	{ firstname : 'Pesho', lastname: 'Peshov', age: 56},
	{ firstname : 'Gosho', lastname: 'Goshev', age: 32}, 
	{ firstname : 'Ivan', lastname: 'Ivanov', age: 81},
	{ firstname : 'Petq', lastname: 'Petkova', age: 40}]

findYoungestPerson(persons);