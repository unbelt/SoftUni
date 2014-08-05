// 1. Write a JavaScript function convertKWtoHP(value) to convert car’s kW into hp (horse power).
//    Write a JS program powerfulCars.js that converts a few sample values to hp (see the examples below).
//    The result should be printed on the console, rounded up to the second sign after the decimal point.
//        Run the program through Node.js.

function convertKWtoHP(value) {
    return (value / 0.745699872).toFixed(2);
}

[75, 150, 1000].forEach(function(value) {
    console.log(convertKWtoHP(value));
});