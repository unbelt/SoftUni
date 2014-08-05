/**
* Write a JavaScript function findLargestBySumOfDigits(nums) that takes as an input a sequence of positive
* integer numbers and returns the element with the largest sum of its digits. The function should take a 
* variable number of arguments. It should return undefined when 0 arguments are passed or when some of the
* arguments is not an integer number. Write a JS program largestSumOfDigits.js that invokes your function 
* with the sample input data below and prints its output at the console.
*/

function findLargestBySumOfDigits(nums) {
	var length = nums.length;
	var biggestSum = 0;
	var sum = 0;
	var index = 0;

	for (var i = 0; i < length; i++) {

		if (nums[i].toString().indexOf('.') == -1 || typeof(nums[i]) == Number) {
			var number = nums[i];

			if (number < 0) {
				number = number * -1;
			}

			while(number > 0) {
				var lastNumber = number % 10;
				sum += lastNumber;
				number = Math.floor(number / 10);
			}

			if (sum > biggestSum) {
				biggestSum = sum;
				index = i;
			}

			sum = 0;
		} else {
			return 'undefined';
		}
	}

	return nums[index];
}

console.log(findLargestBySumOfDigits([0.0, 10, 15, 111]));
console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));