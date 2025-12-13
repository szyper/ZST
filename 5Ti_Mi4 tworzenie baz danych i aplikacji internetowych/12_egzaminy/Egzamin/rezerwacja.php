<?php
    // połączenie z db
    $host = 'localhost';
    $user = 'root';
    $pass = '';
    $dbname = 'baza';

    $conn = mysqli_connect($host, $user, $pass, $dbname);

    if (!$conn) {
        die('Błąd połączenia z bazą: '. mysqli_connect_error());
    }

    $data = isset($_POST['data']) ? $_POST['data'] : '';
    $ilosc = isset($_POST['ilosc']) ? $_POST['ilosc'] : null;
    $telefon = isset($_POST['telefon']) ? $_POST['telefon'] : '';

    // echo $data, $ilosc, $telefon;

    $sql = "INSERT INTO `rezerwacje` (`data_rez`, `liczba_osob`, `telefon`) VALUES ('$data', '$ilosc', '$telefon');";

    $result = mysqli_query($conn, $sql);

    if ($result) {
        echo "Dodano rezerwację do bazy";
    } else {
        echo "Błąd: " . mysqli_error($conn);
    }

    mysqli_close($conn);