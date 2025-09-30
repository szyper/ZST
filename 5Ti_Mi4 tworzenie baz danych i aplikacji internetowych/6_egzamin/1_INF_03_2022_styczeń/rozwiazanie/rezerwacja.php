<?php
    // dane do logowania
    $host = "localhost";
    $user = "root";
    $pass = "";
    $dbname = "baza";

    // połączenie z bazą danych
    $conn = mysqli_connect($host, $user, $pass, $dbname);

    // sprawdzenie połączenia
    if (!$conn) {
        die("Błąd połączenia z bazą danych: " . mysqli_connect_error());
    }

    //print_r($_POST);

    // pobranie danych z formularza
    $data_rez = $_POST['data'];
    $liczba_osob = $_POST['ilosc_osob'];
    $telefon = $_POST['telefon'];

    // zapytanie SQL
    $sql = "INSERT INTO `rezerwacje` (`data_rez`, `liczba_osob`, `telefon`) VALUES ('$data_rez', '$liczba_osob', '$telefon');";

    // wykonanie zapytania
    if (mysqli_query($conn, $sql)) {
        echo "Rezerwacja została zapisana poprawnie";
    } else {
        echo "Błąd: " . mysqli_error($conn); 
    }

    mysqli_close($conn);
?>