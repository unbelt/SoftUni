// 7. Write a JavaScript function calcSupply(value) that accepts the following parameters:
//    your age (years), your maximum age (years), your favorite food name (e.g. "chocolate"),
//    estimate amount of your favorite food per day (a number).
//    The function calculates how many of the food you will eat for the rest of your life.
//    Write JS program lifetimeSupplyCalc.js that calculates the amount of a few foods that you will eat.
//    The result should be printed on the console. Run the program through Node.js.
//    Note: we assume that there are no leap years.

function calcSupply(age, maxAge, food, amountPerDay) {
    var totalFood = ((maxAge - age) * 365) * amountPerDay;

    return totalFood + 'kg of ' + food + ' would be enough until I am ' + maxAge + ' years old.';
}

[
    [38, 118, 'chocolate', 0.5],
    [20, 87, 'fruits', 2],
    [16, 102, 'nuts', 1.1]
].forEach(function (value) {
        console.log(calcSupply(value[0], value[1], value[2], value[3]));
    });