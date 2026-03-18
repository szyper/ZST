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

        table, tr, td, th {
            border: solid 1px grey;
            border-collapse: collapse;
            padding: 10px;
            text-align: left;
        } 

        a {
            text-decoration: none;
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
                        echo "<li><a href='3_show_users_list_table.php?id=$id'>$firstName $lastName</a></li>";
                }
            echo "</ul>";
        } else {
            echo "<p>Brak danych w tabeli users</p>";
        }

        if (isset($_GET['id'])){
            $id = intval($_GET['id']);
            
            $query = "SELECT * FROM users WHERE id = $id";
            $result = mysqli_query($conn, $query);
            
            if ($result && mysqli_num_rows($result) > 0) {
                $user = mysqli_fetch_assoc($result);

                echo "<h2>Szczegóły użytkownika</h2>";
                echo "<table>";
                    echo "<tr><th>ID</th><td>$user[id]</td></tr>";
                    echo "<tr><th>Imię</th><td>$user[first_name]</td></tr>";
                    echo "<tr><th>Nazwisko</th><td>$user[last_name]</td></tr>";
                    echo "<tr><th>Data urodzenia</th><td>$user[birthday]</td></tr>";
                echo "</table>";
            } else {
                echo "Nie znaleziono użytkownika";
            }
        }

        // skrypt_1

        

        mysqli_close($conn);
    ?>
    
</body>
</html>