<?php
    // tablica z dostępnymi imionami do losowania
    $names = [
        "Krystyna", "Janina", "Ola",
        "Tomasz", "Paweł", "Franek"
    ];

    // tablica na wylosowane wyniki
    $randomResult = [];

    // print_r($_POST);
    // echo "<br>";
    // var_dump($_POST);

    // sprawdzenie, czy formularz został wysłany
    // $_POST zmienna superglobalna
    if (isset($_POST["count"])) {
        // pobranie ilości elementów z formularza i rzutowanie nie int
        $count = (int)$_POST['count'];
        
        // zabezpieczenie wartości:
        // minimum 1
        // maksimum - liczba elementów w tablicy $names
        $count = max(1, min($count, count($names)));

        // losowe przetasowanie tablicy imion
        shuffle($names);

        // pobieranie pierwszych $count elementów z przetasowanej tablicy
        $randomResult = array_slice($names, 0, $count);
    }
?>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Losowa lista</title>
    <style>
        body { font-family: Arial; margin: 40px }
        form { margin-bottom: 20px; }
    </style>
</head>
<body>
    <h2>Generator losowej listy</h2>
    <form method="post">
        <label>
            Ile elementów wygenerować?
            <input type="number" name="count" min="1" max="10" required>
        </label>
        <button type="submit">Losuj</button>
    </form>
    <?php
        if (!empty($randomResult)) {
            echo "<h4>Wynik:</h4>";
            echo "<ul>";
            foreach ($randomResult as $name) {
                echo "<li>$name</li>";
            }
            echo "</ul>";
        }
    ?>
</body>
</html>