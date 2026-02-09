<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Generator tabeli</title>
    <style>
        table {
            border-collapse: collapse;
            margin-top: 20px;
        }

        td, th {
            border: 1px solid #333;
            padding: 8px;
            text-align: center;
        }
    </style>
</head>
<body>
    <h2>Generator tabeli</h2>
    <form method="post">
        <label>Podaj liczbę wierszy:</label>
        <input type="number" name="rows" min="1" required>
        <button type="submit">Generuj</button>
    </form>
    <?php
    if (isset($_POST['rows'])) {
        // echo $_POST['rows'];
        $rows = intval($_POST['rows']);
        // echo $rows;

        if ($rows > 0) {
            echo "<table>";
                echo "<tr><th>L.p.</th><th>Losowa liczba</th><th>Kwadrat liczby</th></tr>";
                for ($i=1; $i <= $rows ; $i++) {
                    $rand = rand(1, 100);
                    echo "<tr>";
                        echo "<td>$i</td>";
                        echo "<td>$rand</td>";
                        echo "<td>".$rand * $rand."</td>";
                    echo "</tr>";
                }
            echo "</table>";
        } else {
            echo "<p>Podaj poprawną liczbę wierszy</p>";
        }
    }
    ?>
</body>
</html>