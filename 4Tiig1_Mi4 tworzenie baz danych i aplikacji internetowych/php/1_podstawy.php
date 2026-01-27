<?php
    // komentarz jednoliniowy

    /*
    komentarz 
    w wielu
    liniach
    */

    $name = "Janusz";
    $surname = 'Nowak';

    $isActive = true;

    /*
    operatory:
    arytmetyczne: +, -, *, /, %
    przypisania: =, +=, -=
    porównania: ==, ===, !=, !==, <, > 
    logiczne: &&, ||, !
    */

    // instrukcja warunkowa
    $age = 15;
    if ($age >= 18) {
        echo "Pełnoletni";
    } elseif ($age < 0){
        echo "Błędny wiek";
    } else {
        echo "Niepełnoletni";
    }
    echo "<br>";

    // pętle
    //while
    $i = 0;
    while ($i <= 10) {
        echo "$i ";
        $i++;
    }
    echo "<br>";

    // do while
    do {
        echo "$i ";
        $i--;

    } while ($i >= 0);
    echo "<br>";

    // for
    for ($i=1; $i <= 10 ; $i++) { 
        echo "$i ";
    }
    echo "<br>";

    // foreach
    $fruits = ["jabłko", "gruszka", "czereśnia"];
    foreach ($fruits as $fruit) {
        echo "$fruit ";
    }
    echo "<br>";

    foreach ($fruits as $key => $value) {
        echo "$key: $value<br>";
    }

    // tablica asocjacyjna
    // tablica samochodów
    $cars = ["brand" => "BMW", "model" => "X5", "color" => "czarny"];
    foreach ($cars as $car) {
        echo "$car ";
    }
    echo "<br>";

    $cars1 = [
        [
            "brand" => "BMW",
            "model" => "X5",
            "color" => "czarny"
        ],
        [
            "brand" => "Audi",
            "model" => "RS",
            "color" => "Szary"
        ]
    ];
    foreach ($cars1 as $car) {
        echo "Marka: ".$car["brand"].", model: ".$car["model"].", kolor: ".$car["color"]."<br>";
    }