// 9. Write a JavaScript function treeHouseCompare(value) that accepts the following parameters:
//    integers a and b. The function compares the area of the house and the area of the tree
//    and returns the name of the figure with bigger area (house or tree) and the value of the area.
//    Write JS program treehouse.js that compares a few houses and trees.
//    The result should be printed on the console. Run the program through Node.js.

function treeHouseCompare(a, b) {
    var houseArea = a * a + (a * (a * 2 / 3)) / 2;
    var treeArea = b * (b / 3) + Math.PI * (b * 2 / 3) * (b * 2 / 3);

    return houseArea > treeArea ? 'house/' + houseArea.toFixed(2) : 'tree/' + treeArea.toFixed(2);
}

[
    [3, 2],
    [3, 3],
    [4, 5]
].forEach(function (value) {
        console.log(treeHouseCompare(value[0], value[1]));
    });