<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Użytkownicy</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        ul {
            list-style-type: disc;
            padding-left: 20px;
        }

        li {
            margin-bottom: 8px;
        }
    </style>
</head>
<body>
    <h1>Użytkownicy</h1>
    <?php
        $conn = mysqli_connect("localhost", "root", "", "4ti_szkola");
        
        $query = "SELECT * FROM `users` ORDER BY last_name ASC;";

        $result = mysqli_query($conn, $query);

        if (mysqli_num_rows($result) > 0) {
            echo "<ul>";
                while($row = mysqli_fetch_assoc($result)){
                        $id = $row["id"];
                        $firstName = $row["first_name"];
                        $lastName = $row["last_name"];
                        $birthday = $row["birthday"];
                    echo "<li>";
                        echo "ID: $id - $firstName $lastName (ur. $birthday)";
                    echo "</li>";
                }
            echo "</ul>";
        } else {
            echo "<p>Brak danych w tabeli users</p>";
        }
        mysqli_close($conn);
    ?>
</body>
</html>