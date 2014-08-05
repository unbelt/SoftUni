// 8. Write a JavaScript function calcCylinderVol(value) that accepts the following parameters:
//    radius and the height of a straight circular cylinder.
//    The function calculates the volume of the cylinder.
//    Write JS program cylinderVol.js that calculates the volume of a few cylinders.
//    The result should be printed on the console. Run the program through Node.js.

function calcCylinderVol(radius, height) {
    return Math.PI * Math.pow(radius, 2) * height;
}

[
    [2, 4],
    [5, 8],
    [12, 3]
].forEach(function (value) {
        console.log(calcCylinderVol(value[0], value[1]));
    });