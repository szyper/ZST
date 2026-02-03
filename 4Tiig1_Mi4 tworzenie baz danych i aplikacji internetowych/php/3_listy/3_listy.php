<?php
    $fruits = ["Jabłko", "Banan", "Pomelo"];

    echo "<ul>";
        echo "<li>$fruits[0]</li>";
    echo "</ul>";

    echo "<ul>";
        foreach ($fruits as $fruit) {
            echo "<li>$fruit</li>";
        }
    echo "</ul>";

    echo "<ol>";
        foreach ($fruits as $fruit) {
            echo "<li>$fruit</li>";
        }
    echo "</ol>";

    // lista z kluczem i wartością (tablica asocjacyjna)
    $user = [
        "firstName" => "Janusz",
        "lastName" => "Nowak",
        "age" => 30
    ];

    echo "<ul>";
        foreach ($user as $key => $value) {
            echo "<li>$key: $value</li>";
        }
    echo "</ul>";

    require_once "functions.php";

    generateList(["PHP", "Python", "C#"]);
    generateListType(["PHP", "Python", "C#", "Java"]);
    generateListType(["PHP", "Python", "C#", "Java"], "ol");
  ?>