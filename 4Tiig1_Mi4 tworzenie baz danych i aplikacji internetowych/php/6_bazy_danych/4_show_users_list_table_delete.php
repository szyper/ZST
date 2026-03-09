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

            // usuwanie rekordu
            if (isset($_GET['delete_id'])) {
                $delete_query = $_GET["delete_id"];
                $delete_query = "DELETE FROM users WHERE `users`.`id` = $delete_query";
                mysqli_query($conn, $delete_query);

                if (mysqli_affected_rows($conn) > 0) {
                    echo "<p>Rekord został usunięty</p>";
                } else {
                    echo "<p>Nie udało się usunąć rekordu</p>";
                }
            }

            // pobieranie użytkowników
            $query = "SELECT * FROM users";
            $result = mysqli_query($conn, $query);
            
            if ($result && mysqli_num_rows($result) > 0) {


                echo "<table>";
                    echo "<tr><th>Id</th><th>Imię</th><th>Nazwisko</th><th>Data urodzenia</th><th>Akcja</th></tr>";
                      while ($row = mysqli_fetch_assoc($result)){
                          $id = $row['id'];
                          $firstName = $row['first_name'];
                          $lastName = $row['last_name'];
                          $birthady = $row['birthday'];
                          echo "<tr>";
                            echo "<td>" . $row['id'] . "</td>";
                          echo "<td>$firstName</td>";
                          echo "<td>$lastName</td>";
                          echo "<td>$birthady</td>";
                          echo "<td><a href='4_show_users_list_table_delete.php?delete_id=$id'>Usuń</a></td>";
                          echo "</tr>";
                      }
//                    echo "<tr><th>ID</th><td>$user[id]</td></tr>";
//                    echo "<tr><th>Imię</th><td>$user[first_name]</td></tr>";
//                    echo "<tr><th>Nazwisko</th><td>$user[last_name]</td></tr>";
//                    echo "<tr><th>Data urodzenia</th><td>$user[birthday]</td></tr>";
                echo "</table>";
            } else {
                echo "Nie znaleziono użytkownika";
            }

        mysqli_close($conn);
    ?>
    
</body>
</html>