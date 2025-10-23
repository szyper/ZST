<?php
    session_start();

    $host = "localhost";
    $user = "root";
    $pass = "";
    $dbname = "5ti_insert";

    $conn = new mysqli($host, $user, $pass, $dbname);

    if ($conn->connect_error) {
        die("Błąd połączenia z bazą danych: " . $conn->connect_error);
    }
?>