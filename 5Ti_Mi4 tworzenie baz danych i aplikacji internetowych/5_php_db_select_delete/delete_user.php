<?php
    require_once('./config.php');

    $mysqli = new mysqli($host, $user, $pass, $db_name);

    if ($mysqli->connect_error) {
        die("Błąd połączenia: " . $mysqli->connect_error);
    }

    $id = $_GET['delete_user_id'];

    $sql = "DELETE FROM users WHERE `users`.`id` = $id";

    $result = $mysqli->query($sql);

    header("location: ./index.php?result_delete_user=1");
?>