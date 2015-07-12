<?php include_once 'play.php'; ?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Guess Number Game</title>
    <meta name="description" content="Guess Number Game">
    <link rel="stylesheet" href="style.css"/>

    <script type="text/javascript">
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;
    </script>

</head>
<body>

<form method="post">
    <?php if (!isset($_SESSION['user'])) { ?>
        <label for="user">Username: </label>
        <input type="text" id="user" name="user" placeholder="Username"/>
    <?php } else {
        echo $_SESSION['user'] ?>
        <input type="submit" id="logout" name="logout" value="Logout"/>
        <input type="text" id="number" name="number" placeholder="1 - 100"/>
        <?php echo $tooltip;
    } ?>
    <input type="submit" value="Submit"/>
</form>

</body>
</html>