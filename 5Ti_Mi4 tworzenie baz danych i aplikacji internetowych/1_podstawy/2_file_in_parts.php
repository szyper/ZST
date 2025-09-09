<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h4>Początek</h4>
    <!-- dodanie zawartości pliku data.php -->

    <?php
    // include => dołączenie
    // require => wymagane
        // include("data.php");
        // include_once("data.php");
        // require("data.php");
        // //require_once("data1.php");
    
        // require_once("function.php");

        // show();


        require_once("./data.php");
        require_once("./function.php");

        show();
        showMessage("To jest komunikat od użytkownika");

        $x = 10;
        $y = 20;
        echo "<p>Suma $x i $y = ". sum(10, 20) . "</p>";
        echo "Liczba elementów w liście: ". count($fruits);
        //generateList($fruits);

        echo "<h4>Lista owoców (oryginalna)</h4>";
        generateList($fruits);

        echo "<h4>Lista owoców (posortowana niemalejąco)</h4>";
        sortArray($fruits, "asc");

        echo "<h4>Lista owoców (posortowana nierosnąco)</h4>";
        sortArray($fruits, "desc");
        sortArray($fruits);

    ?>
    <h4>Koniec</h4>


</body>
</html>