// 12. Write a JavaScript function variablesTypes(value) that accepts the following parameters:
//     name, age, isMale (true or false), array of your favorite foods.
//     The function must return the values of the variables and their types.

function variablesTypes(value) {
    var name = value[0],
        age = value[1],
        isMale = value[2],
        foods = value[3];

    console.log('\"My name: ' + name + ' //type is ' + typeof name +
        '\r\nMy age: ' + age + ' //type is ' + typeof age +
        '\r\nI am male: ' + isMale + ' //type is ' + typeof isMale +
        '\r\nMy favorite foods are: ' + foods.join() + ' //type is ' + typeof foods + '\"');
}

variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);