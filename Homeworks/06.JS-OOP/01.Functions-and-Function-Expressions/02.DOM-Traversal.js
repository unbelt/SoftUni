/* 2. You are given an HTML file. Write a function that traverses all child elements of an element
      by a given CSS selector and prints all found elements in the format:
        <Element name>: id="<id>", class="<class>"
      Print each element on a new line. Indent child elements. */

;
(function () {
    'use strict';

    function traverse(element) {
        var node = document.querySelector(element);
        traverseNode(node);

        function traverseNode(node, spacing) {
            spacing = spacing || '\r\n';
            var nodeId = '',
                nodeClass = '';

            if (node.id) {
                nodeId = 'id="' + node.id + '"';
            }

            if (node.className) {
                nodeClass = 'class="' + node.className + '"';
            }

            console.log(spacing + node.nodeName.toLocaleLowerCase() + ': ' + nodeId + nodeClass);

            for (var i = 0, len = node.childNodes.length; i < len; i += 1) {
                var child = node.childNodes[i];

                if (child.nodeType === document.ELEMENT_NODE) {
                    traverseNode(child, spacing + '     ');
                }
            }
        }
    }

    traverse('.birds');
})();