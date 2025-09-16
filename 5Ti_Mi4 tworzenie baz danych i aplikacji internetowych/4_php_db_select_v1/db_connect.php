<?php
    require_once('./config.php');

    $mysqli = new mysqli($host, $user, $pass, $db_name);

    if ($mysqli->connect_error) {
        die("Błąd połączenia: " . $mysqli->connect_error);
    }
?>