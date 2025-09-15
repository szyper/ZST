<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        table, tr, th, td {
            border: solid 1px grey;
            border-collapse: collapse;
            padding: 10px;
        }
    </style>
</head>
<body>
    <?php
    require_once('./config.php');

    $mysqli = new mysqli($host, $user, $pass, $db_name);

    if ($mysqli->connect_error) {
        die("Błąd połączenia: " . $mysqli->connect_error);
    }

    $sql = "SELECT * FROM `users`;";

    $result = $mysqli->query($sql);

    echo $result->num_rows."<hr>";

    if ($result->num_rows > 0) {
        echo "<table><tr><th>Id</th><th>Imię</th><th>Email</th></tr>";
        while($row = $result->fetch_assoc()){
            echo "<tr><td>".$row["id"]."</td><td>".$row["firstName"]."</td><td>".$row["email"]."</td></tr>";
    }
    echo "</table>";
    }else{
        echo "Brak danych w tabeli użytkownicy";
    }

    
    $mysqli->close();
?>
</body>
</html>
