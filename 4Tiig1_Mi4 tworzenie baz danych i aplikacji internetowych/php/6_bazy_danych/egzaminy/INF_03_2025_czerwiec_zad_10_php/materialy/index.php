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
        
        echo "<table border='1'><tr><th>Zdjęcie</th><th>Nazwa</th><th>Cena</th></tr>";
        
        //dane
        while ($row = mysqli_fetch_assoc($result)) {
            echo "<tr>";
            echo "<td><img src='".$row['kod'].".jpg' alt='kurs'></td>";
            echo "<td>".$row['nazwa']."</td>";
            echo "<td>".$row['cena']."</td>";
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
    ?>  
    
            
        
    
</body>
</html>