<?php
    function sayHello(){
        echo "Cześć";
    }

    sayHello();

    // funkcja z parametrami
    function greet($name){
        echo "Cześć $name";
    }
    echo "<br>";

    greet("Paweł");
    echo "<br>";

    // funkcja zwracająca wartość za pomocą return
    function add($a, $b){
        return $a + $b;
    }

    $result = add(4, 8);
    echo $result;
    echo "<br>";

    // parametry domyślne
    function welcome($name = "Gość"){
        echo "Witaj $name!";
    }

    welcome("Tomasz");
    echo "<br>";
    welcome();
    echo "<br>";


    // funkcja z tablicą
    function showCar($car){
        echo "<br>Marka: {$car['brand']}, model: {$car['model']}, kolor: {$car['color']}<br>";
    }

    $car = [
        "brand" => "BMW",
        "model" => "X5",
        "color" => "niebieski"
    ];

    showCar($car);

    // funkcje wbudowane
    // strlen() - zwraca liczbę bajtów a nie znaków w napisie
    // polskie znaki w UTF-8 zajmują 2 bajty
    // Do liczenia znaków używać mb_strlen()  - liczy znaki a nie bajty

    $text = "Janusz";

    $length = strlen($text);
    echo $text.": ".$length." znaków<br>";


    $text = "Paweł";
    echo $text.": ".$length." znaków<br>";

    echo $text.": ".mb_strlen($text)." znaków<br>";

    // count() - zlicza elementy w tablicy
    $cars = ["BMW", "Opel", "Ferrari"];

    echo count($cars);
    echo "<br>";

    // date()
    echo date("Y"); // 2026
    echo date("m"); // 02
    echo date("d"); // 02
    echo date("Y-m-d"); // 2026-02-02

    echo "<br>";
    echo date("d.m.Y H:i:s"); // 02.02.2026 09:47:08


    echo "<hr>test";


?>