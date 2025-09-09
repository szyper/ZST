<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PHP - zajęcia 1</title>
</head>
<body>
    <?php
        $firstName = "Janusz";
        $lastName = "Nowak";
        echo "Imię: $firstName<br>";
        echo 'Imię: $firstName<hr>';

        //heredoc
        echo <<< DATA
            Imię: $firstName<br>
            Nazwisko: $lastName
            <hr>
DATA;

    //echo phpinfo(); //PHP Version 8.2.12

//nowdoc
echo <<< 'DATA'
            Imię: $firstName<br>
            Nazwisko: $lastName
            <hr>
DATA;
    ?>
</body>
</html>