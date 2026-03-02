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
            [
                "username" => "admin",
                "password" => password_hash("1234", PASSWORD_DEFAULT),
                "age" => 30
            ],
            [
                "username" => "test",
                "password" => password_hash("abcd", PASSWORD_DEFAULT), 
                "age" => 20
            ],
            [
                "username" => "argon",
                "password" => password_hash("abcd", PASSWORD_ARGON2ID), 
                "age" => 20
            ],
            [
                "username" => "bcrypt",
                "password" => password_hash("abcd", PASSWORD_BCRYPT), 
                "age" => 20
            ], 
            [
                "username" => "argon2i",
                "password" => password_hash("abcd", PASSWORD_ARGON2I), 
                "age" => 20
            ]
        ];

        echo "<table border='1'>";
            echo "<tr><th>Login</th><th>Hasło</th><th>Akcja</th></tr>";
            foreach ($users as $index => $user) {
                echo "<tr>";
                    // echo "<td>".$index."</td>";
                    echo "<td>".$user["username"]."</td>";
                    echo "<td>".$user["password"]."</td>";

                    echo "<td>
                            <form method='post'>
                              <input type='hidden' name='id' value='$index'>
                              <button type='submit'>Pokaż szczegóły</button>  
                            </form>
                        </td>";

                echo "</tr>";
            }
        echo "</table>";
    
        if (isset($_POST["id"])) {
            $id = $_POST["id"];
            $user = $users[$id];

            echo "<h3>Szczegóły użytkownika</h3>";
            // echo "Nazwa użytkownika: ".$users[$id]["username"]."<br>";
            echo "Nazwa użytkownika: ".$user["username"]."<br>";
            echo "Hasło: ".$user["password"]."<br>";

            $info = password_get_info($user["password"]);
            // print_r($info);
            echo "Algorytm: ".$info["algoName"]."<br>";

            echo "Wiek: ".$user["age"]."<br>";

        }
    ?>
    
</body>
</html>