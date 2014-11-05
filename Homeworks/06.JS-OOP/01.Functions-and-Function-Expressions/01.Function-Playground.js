/* 1. Create a function with no parameters. Perform the following operations:
        • The function should print the number of its arguments and each of the arguments' type.
            o Call the function with different number and type of arguments.
        • The function should print the this object.
      Compare the results when calling the function from:
         o Global scope
         o Function scope
         o Over the object
         o Use call and apply to call the function with parameters and without parameters */

;
(function () {
    //'use strict';

    function printArguments() {
        console.log('\r\nNumber of arguments: ' + arguments.length);

        for (var i = 0; i < arguments.length; i++) {
            var object = arguments[i];

            console.log('Type of argument ' + object + ': ' + typeof object);
        }

        console.log(this);
    }

    // -- Test printArguments()
    //var printThis = printArguments();
    printArguments.call(12, 'Pesho', 'Gosho');
    printArguments.apply(false, []);
    //printArguments.call(); // undefined if 'use strict'
})();