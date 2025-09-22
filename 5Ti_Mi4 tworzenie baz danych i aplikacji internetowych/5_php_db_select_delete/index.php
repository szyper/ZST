<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        /* table, tr, th, td {
            border: solid 1px grey;
            border-collapse: collapse;
            padding: 10px;
        } */
    </style>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <?php
    require_once('./config.php');

    function calculateAge($birthDate){
        $dateOfBirth = new DateTime($birthDate); //data urodzenia
        $currentDate = new DateTime(); //dzisiejsza data
        $age = $currentDate->diff($dateOfBirth)->y; //różnica w latach
        return $age;
    }

    $mysqli = new mysqli($host, $user, $pass, $db_name);

    if ($mysqli->connect_error) {
        die("Błąd połączenia: " . $mysqli->connect_error);
    }

    $sql = "SELECT id, firstName, email, birth_date, gender, description FROM `users`;";

    $result = $mysqli->query($sql);

    echo $result->num_rows."<hr>";

    if ($result->num_rows > 0) {
        echo "<h2>Lista użytkowników:</h2>";
        echo "<table>
        <tr>
        <th>Id</th>
        <th>Imię</th>
        <th>Email</th>
        <th>Data urodzenia</th>
        <th>Wiek</th>
        <th>Płeć</th>
        <th>Opis</th>
        </tr>";
        while($row = $result->fetch_assoc()){
            echo "<tr><td>".
            $row["id"]."</td><td>".
            $row["firstName"]."</td><td>".
            $row["email"]."</td><td>".
            $row["birth_date"]."</td><td>".
            calculateAge($row["birth_date"])."</td><td>".
            $row["gender"]."</td><td>".
            $row["description"]."</td><td>".
            "<a href=\"?user_id=$row[id]\">Szczegóły</a> ".
            "<a href=\"?delete_user_id=$row[id]\">Usuń</a>".
            "</tr>";
    }
    echo "</table>";
    }else{
        echo "Brak danych w tabeli użytkownicy";
    }
    
    if (isset($_GET['user_id'])) {
        $id = $_GET['user_id'];

        // zapytanie do bazy danych
        $sql = "SELECT * FROM  users WHERE id = $id";
        $result = $mysqli->query($sql);

        if ($result->num_rows > 0) {
            $user = $result->fetch_assoc();
            ?>
                <h3>Szczegółowe informacje o <?php echo $user['firstName']." ".$user['lastName']?></h3>
                <table>
                    <tr>
                        <th>Imię</th>
                        <th>Nazwisko</th>
                        <th>Data urodzenia</th>
                        <th>Płeć</th>
                        <th>Opis</th>
                    </tr>
                    <tr>
                        <td><?php echo $user['firstName'] ?></td>
                        <td><?php echo $user['lastName'] ?></td>
                        <td><?php echo $user['birth_date'] ?></td>
                        <td><?php echo $user['gender'] ?></td>
                        <td><?php echo $user['description'] ?></td>
                    </tr>
                </table>
                <br><a href="./">Ukryj formularz</a>
            <?php
        }

    }

    if (isset($_GET['delete_user_id'])) {
        header("location: ./delete_user.php?delete_user_id=$_GET[delete_user_id]");
    }


    $mysqli->close();
?>
</body>
</html>
