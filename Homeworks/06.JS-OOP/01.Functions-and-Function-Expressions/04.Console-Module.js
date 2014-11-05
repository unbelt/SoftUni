/* 4. Create a module for working with the console object.
      The module should support the following functionality:
         • Writing a line to the console
         • Writing a line to the console using formatting (with placeholders)
         • Writing to the console should call toString() to each element
         • Writing errors and warnings to the console with and without format */

;
(function () {
    'use strict';

    var specialConsole = (function () {

        function parseCommand() {

            // Limit placeholders to 30
            var args = arguments[0].split(/(\{[0-30]\})/g),
                counter = 1;

            for (var i = 1; i < args.length; i += 2) {
                args[i] = arguments[counter++];
            }

            return args.join('');
        }

        function writeLine() {
            console.log(parseCommand.apply(null, arguments));
        }

        function writeWarning() {
            console.warn(parseCommand.apply(null, arguments));
        }

        function writeError() {
            console.error(parseCommand.apply(null, arguments));
        }

        return {
            writeLine: writeLine,
            writeWarning: writeWarning,
            writeError: writeError
        }
    }());

    // -- Testing
    specialConsole.writeLine('Message: hello');
    specialConsole.writeLine('Message: {0} I am {1}, and I am {2} years old.', 'hello', 'Johnny', 12);
    specialConsole.writeError('Error: {0}', 'A fatal error has occurred.');
    specialConsole.writeWarning('Warning: {0}', 'You are not allowed to do that!');

})();