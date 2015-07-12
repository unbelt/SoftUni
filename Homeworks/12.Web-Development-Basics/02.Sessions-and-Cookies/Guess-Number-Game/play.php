<?php
session_start();

$tooltip = 'Guess the number';

if (isset($_POST['user']) && !isset($_SESSION['user'])) {
    $_SESSION['user'] = $_POST['user'];
}

if (isset($_POST['logout'])) {
    session_destroy();
    header('Location:index.php');
}

if (isset($_POST['number'])) {

    if (!is_numeric($_POST['number']) || $_POST['number'] < 1 || $_POST['number'] > 100) {
        return $tooltip = 'Enter a number between 1 and 100!';
    }

    if (!isset($_SESSION['secret'])) {
        $_SESSION['secret'] = rand(1, 100);
        $_SESSION['count'] = 0;
    }

    if ($_POST['number'] == $_SESSION['secret']) {
        $tooltip = 'Congratulations, ' . $_SESSION['user'] .
            '! Your score is: ' . $_SESSION['count'];
        unset($_SESSION['secret']);
        $count = 0;
    } else if ($_POST['number'] > $_SESSION['secret']) {
        $tooltip = 'Down';
        $_SESSION['count']++;
    } else {
        $tooltip = 'Up';
        $_SESSION['count']++;
    }

    //$tooltip = $_SESSION['secret'];
}