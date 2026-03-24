<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Egzamin</title>
</head>
<body>
    <?php
        $conn = mysqli_connect("localhost", "root", "", "szkolenia");

        if (!$conn) {
            die("Błąd połączenia: " . mysqli_connect_error());
        }

        // skrypt 1
        $sql = "SELECT kod, nazwa, cena FROM `kursy` ORDER BY cena;";
        $result = mysqli_query($conn, $sql);
        
        echo "<table border='1'><tr><th>Zdjęcie</th><th>Nazwa</th><th>Cena</th><th>Akcja</th></tr>";
        
        //dane
        while ($row = mysqli_fetch_assoc($result)) {
            echo "<tr>";
            echo "<td><img src='".$row['kod'].".jpg' alt='kurs'></td>";
            echo "<td>".$row['nazwa']."</td>";
            echo "<td>".$row['cena']."</td>";
            echo "<td><a href='?edit=".$row['kod']."'>Edytuj</a></td>";
            echo "</tr>";
        }
        echo "</table>";

        // skrypt 2
        $sql = "SELECT nazwa FROM `kursy`;";
        $result = mysqli_query($conn, $sql);

        echo "<form method='post'>";
            echo "<input type='text' name='firstName'><br><br>";
            echo "<input type='text' name='lastName'><br><br>";
            echo "<input type='number' name='age'><br><br>";
            echo "<select name='kurs'>";
            while ($row = mysqli_fetch_assoc($result)) {
                echo "<option value='".$row['nazwa']."'>".$row['nazwa']."</option>";
            }
            echo "</select><br><br>";
            echo "<input type='submit' value='Dodaj dane'><br><br>";
        echo "</form>";

        // skrypt 3
        if (!empty($_POST['firstName']) && !empty($_POST['lastName']) && !empty($_POST['age'])) {
            $firstName = $_POST['firstName'];
            $lastName = $_POST['lastName'];
            $age = $_POST['age'];

            $sql = "INSERT INTO `uczestnicy` (`id_uczestnika`, `imie`, `nazwisko`, `wiek`) VALUES ('', '$firstName ', '$lastName', '$age');";

            if (mysqli_query($conn, $sql)) {
                echo "<p>Dane uczestnika $firstName $lastName zostały dodane</p>";
            }

        } else {
            echo "<p>Wprowadź wszystkie dane</p>";
        }

        // aktualizacja rekordu
        if (isset($_GET['edit'])) {
            $id = $_GET['edit'];

            $sql = "SELECT * FROM kursy WHERE kod=$id";
            $result = mysqli_query($conn, $sql);
            $kurs = mysqli_fetch_assoc($result);
        }

        if (isset($kurs)) {
            echo "<h4>Edytuj kurs o id=".$kurs['kod']."</h4>";
            echo "<form method='post'>";
            echo "<input type='text' name='kod' value='".$kurs['kod']."' hidden>";
            echo "<input type='text' name='nazwa' value='".$kurs['nazwa']."'><br><br>";
            echo "<input type='number' name='cena' value='".$kurs['cena']."'><br><br>";
            echo "<input type='number' name='max_liczba_miejsc' value='".$kurs['max_liczba_miejsc']."'><br><br>";
            
            echo "<input type='submit' name='update' value='Zapisz zmiany'><br><br>";
        echo "</form>";
        }

        if (isset($_POST['update'])) {
            // print_r($_POST);
            $id = $_POST['kod'];
            $nazwa = $_POST['nazwa'];
            $cena = $_POST['cena'];
            $maxLiczbaMiejsc = $_POST['max_liczba_miejsc'];

            $sql = "UPDATE `kursy` SET `nazwa`='$nazwa',`cena`='$cena',`max_liczba_miejsc`='$maxLiczbaMiejsc' WHERE kod=$id";

            if (mysqli_query($conn, $sql)) {
                echo "<p>Kurs został zaktualizowany</p>";y
            }
        }
    ?>  
    
          
        
    
</body>
</html>