<?php
    mysqli_report(MYSQLI_REPORT_OFF);
    // mysqli_report(MYSQLI_REPORT_ERROR | MYSQLI_REPORT_STRICT);
    // mysqli_report(MYSQLI_REPORT_ALL);
    // połączenie z bazą danych
    // mysqli_connect(serwer, uzytkownik, haslo, nazwa_bazy)
    $polaczenie = mysqli_connect("localhost", "root", "", "4ti_szkola");

    // print_r($polaczenie);

    // sprawdzenie połączenia
    if (!$polaczenie) {
        // die("Błąd: ");
        die("Błąd: " .mysqli_connect_error());
    }

    // zapytanie do bazy danych
    $zapytanie = "SELECT * FROM `users`;";
    $wynik = mysqli_query($polaczenie, $zapytanie);

    // sprawdzenie czy zapytanie się wykonało
    if (!$wynik) {
        die("Błąd zapytania: ".mysqli_error($polaczenie));
    }

    // sprawdzenie liczby wierszy
    if (mysqli_num_rows($wynik) > 0) {
        // pobieranie kolejnych wierszy
        while ($wiersz = mysqli_fetch_array($wynik)){
            echo "ID: ".$wiersz["id"]."<br>";
            echo "Imię: ".$wiersz["first_name"]."<br>";
            echo "Nazwisko: ".$wiersz["last_name"]."<br>";
            echo "Data urodzenia: ".$wiersz["birthday"]."<br>";
            echo "<hr>";
        }
    } else {
        echo "Brak danych w tabeli users";
    }

    // zamknięcie połączenia
    mysqli_close($polaczenie);
?>