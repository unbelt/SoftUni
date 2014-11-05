;
(function () {
    'use strict';

    var shapes = document.getElementById('shapes'),
        shapePoints = document.getElementById('shape-points'),
        addShape = document.getElementById('add-shape'),
        clearShapes = document.getElementById('clear-shapes'),
        addedShapes = document.getElementById('added-shapes');

    shapes.addEventListener('change', function () {
        var selectedShape = shapes.options[shapes.selectedIndex].value;
        shapePoints.innerHTML = '';

        switch (selectedShape) {

            case 'circle':
                appendInput('radius', ' Radius: ');
                break;
            case 'rectangle':
                appendInput('width', ' Width: ');
                appendInput('height', ' Height: ');
                break;
            case 'triangle':
                appendInput('a', ' Point A: ');
                appendInput('b', ' Point B: ');
                appendInput('c', ' Point C: ');
                break;
            case 'segment':
                appendInput('x', ' Point X: ');
                appendInput('y', ' Point Y: ');
                break;
            default :
                shapePoints.innerHTML = '';
                break;
        }
    });

    addShape.addEventListener('click', function () {
        var selectedShape = shapes.options[shapes.selectedIndex].value,
            x = document.getElementById('point-x').value,
            y = document.getElementById('point-y').value,
            color = document.getElementById('color').value;

        switch (selectedShape) {

            case 'circle':
                var radius = document.getElementById('radius').value,
                    circle = new shape.Circle(x, y, color, radius);
                circle.draw();
                addedShapes.innerHTML += selectedShape + ' - X: ' + circle._x + ', Y: ' + circle._y + ', Color: ' + circle._color + ', Radius: ' + circle._radius;
                break;
            case 'rectangle':
                var width = document.getElementById('width').value,
                    height = document.getElementById('height').value,
                    rectangle = new shape.Rectangle(x, y, color, width, height);
                rectangle.draw();
                addedShapes.innerHTML += selectedShape + ' - X: ' + rectangle._x + ', Y: ' + rectangle._y + ', Color: ' + rectangle._color + ', Width: ' + rectangle._width + ', Height: ' + rectangle._height;
                break;
            case 'triangle':
                var a = document.getElementById('a').value,
                    b = document.getElementById('b').value,
                    c = document.getElementById('c').value,
                    triangle = new shape.Triangle(x, y, color, a, b, c);
                triangle.draw();
                addedShapes.innerHTML += selectedShape + ' - X: ' + triangle._x + ', Y: ' + triangle._y + ', Color: ' + triangle._color + ', A: ' + triangle._pointA + ', B: ' + triangle._pointB + ', C: ' + triangle._pointC;
                break;
            case 'segment':
                var pointX = document.getElementById('x').value,
                    pointY = document.getElementById('y').value,
                    segment = new shape.Segment(x, y, color, pointX, pointY);
                segment.draw();
                addedShapes.innerHTML += selectedShape + ' - X: ' + segment._x + ', Y: ' + segment._y + ', Color: ' + segment._color + ', Point X: ' + segment._pointX + ', Point Y: ' + segment._pointY;
                break;
            case 'point':
                var point = new shape.Point(x, y, color);
                point.draw();
                addedShapes.innerHTML += selectedShape + ' - X: ' + point._x + ', Y: ' + point._y + ', Color: ' + point._color;
                break;
        }

        addedShapes.innerHTML += '\r\n';
    });

    clearShapes.addEventListener('click', function () {
        shape.Clear();
        addedShapes.innerHTML = '';
    });

    // [private] Create input function
    function appendInput(id, text, element, type) {

        element = element || '#shape-points';
        type = type || 'input';

        var parent = document.querySelector(element),
            input = document.createElement(type),
            label = document.createElement('label');

        input.id = id;
        input.type = 'text';
        label.htmlFor = id;
        label.innerText = text;

        parent.appendChild(label);
        parent.appendChild(input);
    }

    // [public] Shape module
    var shape = (function () {
        // Setup Canvas
        var canvas = document.createElement('canvas'),
            ctx = canvas.getContext('2d');
        canvas.width = 800;
        canvas.height = 600;

        document.body.appendChild(canvas);

        // [private] Abstract Shape
        function Shape(x, y, color) {

            validateNumber(x, 0, canvas.width);
            validateNumber(y, 0, canvas.height);
            validateString(color);

            this._x = x || 0;
            this._y = y || 0;
            this._color = color || 'black';
        }

        // Canvas drawing
        Shape.prototype.draw = function () {
            ctx.beginPath();

            if (this instanceof Circle) {
                ctx.arc(this._x, this._y, this._radius, 0, Math.PI * 2, true);
            }
            else if (this instanceof Rectangle) {
                ctx.rect(this._x, this._y, this._width, this._height);
            }
            else if (this instanceof Triangle) {
                ctx.moveTo(this._x, this._y);
                ctx.lineTo(this._pointA, this._pointB);
                ctx.lineTo(this._pointC, this._pointA);
            }
            else if (this instanceof Segment) {
                ctx.moveTo(this._x, this._y);
                ctx.lineTo(this._pointX, this._pointY);
            }
            else if (this instanceof Point) {
                ctx.rect(this._x, this._y, 1, 1);
            }

            ctx.fillStyle = this._color;
            ctx.closePath();
            ctx.fill();
            ctx.stroke();
        };

        Shape.prototype.toString = function () {
            console.log('X: ' + this._x + '\r\nY: ' + this._y + '\r\nColor: ' + this._color);
        };

        // [public] Circle
        Circle.prototype = new Shape();

        function Circle(x, y, color, radius) {
            Shape.call(this, x, y, color);

            validateNumber(radius);
            this._radius = radius || 0;
        }

        Circle.prototype.toString = function () {
            console.log('\r\nCircle');
            Shape.prototype.toString.call(this);
            console.log('Radius: ' + this._radius);
        };

        // [public] Rectangle
        Rectangle.prototype = new Shape();

        function Rectangle(x, y, color, width, height) {
            Shape.call(this, x, y, color);

            validateNumber(width);
            validateNumber(height);
            this._width = width || 0;
            this._height = height || 0;
        }

        Rectangle.prototype.toString = function () {
            console.log('\r\nRectangle');
            Shape.prototype.toString.call(this);
            console.log('Width ' + this._width + '\r\nHeight: ' + this._height);
        };

        // [public] Triangle
        Triangle.prototype = new Shape();

        function Triangle(x, y, color, pointA, pointB, pointC) {
            Shape.call(this, x, y, color);

            validateNumber(pointA);
            validateNumber(pointB);
            validateNumber(pointC);
            this._pointA = pointA || 0;
            this._pointB = pointB || 0;
            this._pointC = pointC || 0;
        }

        Triangle.prototype.toString = function () {
            console.log('\r\nTriangle');
            Shape.prototype.toString.call(this);
            console.log('Point A: ' + this._pointA + '\r\nPoint B: ' + this._pointB + '\r\nPoint C: ' + this._pointC);
        };

        // [public] Segment
        Segment.prototype = new Shape();

        function Segment(x, y, color, pointX, pointY) {
            Shape.call(this, x, y, color);

            validateNumber(pointX);
            validateNumber(pointY);
            this._pointX = pointX || 0;
            this._pointY = pointY || 0;
        }

        Segment.prototype.toString = function () {
            console.log('\r\nSegment');
            Shape.prototype.toString.call(this);
            console.log('Point X: ' + this._pointX + '\r\nPoint Y: ' + this._pointY);
        };

        // [public] Point
        Point.prototype = new Shape();

        function Point(x, y, color) {
            Shape.call(this, x, y, color);
        }

        Point.prototype.toString = function () {
            console.log('\r\nPoint');
            Shape.prototype.toString.call(this);
        };

        // [public] Clear canvas
        function clear() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
        }

        function validateNumber(number, min, max) {
            min = min || 0;
            max = max || canvas.height;

            if (number < min || number > max) {
                throw 'The number ' + number + ' must be between ' + min + ' and ' + max + '!';
            }
        }

        function validateString(string) {
            if (typeof string !== 'string' && string) {
                throw 'The value ' + string + ' must be a string!';
            }
        }

        return {
            Circle: Circle,
            Rectangle: Rectangle,
            Triangle: Triangle,
            Segment: Segment,
            Point: Point,
            Clear: clear
        }
    })();

    // -- Testing Shapes
    var circle = new shape.Circle(100, 200, 'red', 50);
    circle.toString();
    //circle.draw();

    var rectangle = new shape.Rectangle(150, 250, 'blue', 100, 50);
    rectangle.toString();
    //rectangle.draw();

    var triangle = new shape.Triangle(130, 100, 'yellow', 10, 180, 30);
    triangle.toString();
    //triangle.draw();

    var segment = new shape.Segment(250, 10, null, 300, 300);
    segment.toString();
    //segment.draw();

    var point = new shape.Point(15, 20, 'red');
    point.toString();
    //point.draw();
})();