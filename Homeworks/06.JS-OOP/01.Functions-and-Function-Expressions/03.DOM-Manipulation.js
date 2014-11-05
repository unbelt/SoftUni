/* 3. Create an IIFE module for working with the DOM tree.
      The module should support the following operations:
         • Adding а DOM element to a parent element specified by selector
         • Removing a child element from a parent specified by selector
         • Attaching an event to a given selector by given event type and event hander
         • Retrieving elements by a given CSS selector
      The module should reveal only its methods (i.e. everything else should be encapsulated). */

;
(function () {
    'use strict';

    var domModule = (function () {

        function appendElement(elementToAppend, parentNode) {
            document.querySelector(parentNode)
                .appendChild(document.createElement(elementToAppend));
        }

        function removeElement(parentNode, elementToRemove) {
            document.querySelector(parentNode)
                .removeChild(document.querySelector(elementToRemove));
        }

        function addEventHandler(parentNode, eventType, eventFunction) {
            document.querySelector(parentNode).style.cursor = 'pointer';
            document.querySelector(parentNode).addEventListener(eventType, eventFunction, false);
        }

        function retrieveElements(selector) {
            var selectedElements = document.querySelectorAll(selector),
                elements = [];

            for (var e in selectedElements) {
                var textContent = selectedElements[e].textContent || selectedElements[e].innerText || '',
                    textElements = textContent.split(/[\n\r]+/g);

                for (var element in textElements) {
                    if (textElements[element].trim()) {
                        elements.push(textElements[element].trim());
                    }
                }
            }

            return elements;
        }

        return {
            appendChild: appendElement,
            removeChild: removeElement,
            addHandler: addEventHandler,
            retrieveElements: retrieveElements
        }
    })();

    // -- For testing results look at index.html file

    // Appends a list item to ul.birds-list
    domModule.appendChild('li', '.birds-list');

    // Removes the first li child from the bird list
    domModule.removeChild('ul.birds-list', 'li:first-child');

    // Adds a click event to all bird list items
    domModule.addHandler('.birds', 'click', function () {
        alert('I\'m a bird!')
    });

    // Retrieves all elements of class "bird"
    var elements = domModule.retrieveElements('.bird');
    console.log(elements); // Print at the browser console

})();