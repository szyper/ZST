<?php
    require_once "connect.php";

    $result = $conn->query("SELECT * FROM users ORDER BY id DESC");

    $conn->close();
?>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lista użytkowników</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <h2>Lista użytkowników</h2>
    <table>
        <tr>
            <th>ID</th>
            <th>Imię</th>
            <th>Nazwisko</th>
            <th>Email</th>
            <th>Data utworzenia</th>
            <th>Akcja</th>
        </tr>
        <?php while($row = $result->fetch_assoc()): ?>
            <tr>
                <td><?php echo $row["id"]; ?></td>
                <td><?php echo $row["first_name"]; ?></td>
                <td><?php echo $row["last_name"]; ?></td>
                <td><?php echo $row["email"]; ?></td>
                <td><?php echo $row["created_at"]; ?></td>
                <td><a href="edit.php?id=<?php echo $row['id'] ?>" class="button">Edytuj</a></td>
            </tr>
        <?php endwhile; ?>
    </table><br>
    <a href="index.php">Strona główna</a>
</body>
</html>