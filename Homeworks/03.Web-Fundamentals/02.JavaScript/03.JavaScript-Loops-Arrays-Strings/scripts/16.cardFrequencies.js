// 16. Write a JavaScript function findCardFrequency(value) that that accepts
//     the following parameters: array of several cards (face + suit), separated by a space.
//     The function calculates and prints at the console the frequency of each card face in format
//     "card_face -> frequency". The frequency is calculated by the formula appearances / N and is
//     expressed in percentages with exactly 2 digits after the decimal point. The card faces with
//     their frequency should be printed in the order of the card face's first appearance in the input.
//     The same card can appear multiple times in the input, but its face should be listed only once
//     in the output. Write JS program cardFrequencies.js that invokes your function with the sample
//     input data below and prints the output at the console.

function findCardFrequency(value) {
    'use strict';

    var i, k,
        result = [],
        cardsCount = { },
        allCards = value.split(/[♣♦♥♠ ]+/).filter(Boolean),
        uniqueCards = value.split(/[♣♦♥♠ ]+/).filter(function (elem, index, self) {
            return index == self.indexOf(elem);
        }).filter(Boolean);

    for (i = 0; i < allCards.length; i++) {
        cardsCount[allCards[i]] = (cardsCount[allCards[i]] || 1) + 1;
    }

    for (k in uniqueCards) {
        result.push(uniqueCards[k] + ' -> ' +
            ((cardsCount[uniqueCards[k]] - 1) * 100 / allCards.length)
                .toFixed(2) + '%');
    }

    return result.join('\r\n');
}

[
    '8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦',
    'J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠',
    '10♣ 10♥'
].forEach(function (value) {
        console.log(findCardFrequency(value) + '\r\n');
    });