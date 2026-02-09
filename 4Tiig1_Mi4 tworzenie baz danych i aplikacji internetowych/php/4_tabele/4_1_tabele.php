<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tabela w PHP</title>
    <style>
        table {
            border-collapse: collapse;
            width: 50%;
        }

        td, th {
            border: 1px solid black;
            padding: 8px;
            text-align: center;
        }

        th {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <h2>Przykładowa tabela</h2>

    <?php
        echo "<table>";
            echo "<tr><th>ID</th><th>Imię</th><th>Wiek</th></tr>";
            echo "<tr><td>1</td><td>Franek</td><td>4</td></tr>";
            echo "<tr><td>2</td><td>Anna</td><td>14</td></tr>";
            echo "<tr><td>3</td><td>Paweł</td><td>24</td></tr>";
        echo "</table>";
    ?>
    <br><hr><br>
    <?php
        $students = [
            ["id" => 1, "name" => "Franek", "major" => "Informatyka"],
            ["id" => 2, "name" => "Anna", "major" => "Matematyka"],
            ["id" => 3, "name" => "Krystyna", "major" => "Informatyka"],
            ["id" => 4, "name" => "Paweł", "major" => "Informatyka"],
        ];
    ?>
    <table>
        <tr>
            <th>ID</th>
            <th>Imię</th>
            <th>Kierunek</th>
        </tr>
        <tr>
            <?php
                foreach ($students as $student) {
                    echo "<tr>";
                        echo "<td>$student[id]</td>";
                        echo "<td>$student[name]</td>";
                        echo "<td>$student[major]</td>";
                    echo "</tr>";
                }
            ?>
        </tr>
    </table>
</body>
</html>