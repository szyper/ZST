<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tabele</title>
</head>
<body>
    <?php
        $users = [
            ["username" => "admin", "password" => "1234", "age" => 30],
            ["username" => "test", "password" => "abcd", "age" => 20]
        ];

        echo "<table border='1'>";
            echo "<tr><th>Login</th><th>Hasło</th></tr>";
            foreach ($users as $user) {
                echo "<tr>";
                    echo "<td>".$user["username"]."</td>";
                    echo "<td>".$user["password"]."</td>";
                echo "</tr>";
            }
        echo "</table>";
    ?>
</body>
</html>