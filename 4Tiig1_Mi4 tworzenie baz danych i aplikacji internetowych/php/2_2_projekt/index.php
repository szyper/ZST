<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Samochody</title>
</head>
<body>
    <h3>Samochody</h3>
    <?php
        require_once "cars.php";
        require_once "functions.php";
        // print_r($cars);
        // echo $cars[0]["brand"];

        foreach ($cars as $car) {
            // print_r($car);
            // echo "<br>";
            echo showCar($car)."<br>";
        }

        $totalCars = count($cars);
        echo "Łączna liczba samochodów: $totalCars";

        // dodać samochód w formularzu do tablicy cars
    ?>
</body>
</html>