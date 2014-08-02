window.onload = function () {
    var keys = document.querySelectorAll('button');
    var screen = document.getElementById('screen');
    var inputValue;

    for (var i = 0; i < keys.length; i++) {
        keys[i].onclick = function () {
            if (screen.value == 0 && screen.value.length == 1) {
                screen.value = '';
            }

            inputValue = this.innerText;

            switch (inputValue) {
                case '←':
                    screen.value = screen.value.substr(0, screen.value.length - 1);
                    return;
                case 'CE' :
                    screen.value = 0;
                    return;
                case 'C' :
                    screen.value = 0;
                    return;
                case '±' :
                    screen.value[0] == '-' ?
                        screen.value = screen.value.substr(1) :
                        screen.value = '-' + screen.value;
                    return;
                case '√':
                    calculateRoot();
                    return;
                case '=':
                    calculate();
                    return;
                case '.':
                    if (screen.value.indexOf('.') > -1) {
                        return;
                    }
                    if (screen.value.length == 0) {
                        screen.value += 0 + '.';
                        return;
                    }
            }

            screen.value += inputValue;
        }
    }
}

function calculate() {
    var screen = document.getElementById('screen');
    screen.value = eval(screen.value);
}

function calculateRoot() {
    var screen = document.getElementById('screen');
    screen.value = Math.sqrt(screen.value);
}