<?php
    include_once "init.php";
    $message = '';
    if (isset($_SESSION['message'])) {
        $message = $_SESSION['message'];
        unset($_SESSION['message']);
    }

    if ($message) {
        echo '<div class="message ';

        // sprawdzenie czy w treści komunikatu występuje słowo "Błąd"
        if (strpos($message, 'Błąd') !== false) {
            echo 'error';
        }else{
            echo 'success';
        }

        echo '">';
        echo htmlspecialchars($message);
        echo '</div>';
    }

    if (!isset($_GET['id']) || !is_numeric($_GET['id'])) {
        $_SESSION['message'] = 'Błąd: nieznany numer ID';
        header("location: users.php");
        exit;
    }

    $id = (int) $_GET['id'];

    $result = $conn->query("SELECT * FROM users WHERE id = $id");

    if ($result->num_rows === 0) {
        $_SESSION['message'] = "Błąd: nie znaleziono użytkownika";
        header("location: users.php");
        exit;
    }

    $user = $result->fetch_assoc();
    $conn->close();
?>

<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edycja użytkownika</title>
</head>
<body>
    <h2>Edycja użytkownika</h2>
    <form action="update.php" method="POST">
        <input type="hidden" name="id" value="<?= $user['id'] ?>">
        <label>Imię:</label><br>
        <input type="text" name="first_name"  value="<?= $user['first_name'] ?>" required><br><br>
        <label>Nazwisko: </label><br>
        <input type="text" name="last_name"  value="<?= $user['last_name'] ?>" required><br><br>
        <label>Email:</label><br>
        <input type="email" name="email" value="<?= $user['email'] ?>" required><br><br>
        <input type="submit" value="Aktualizuj użytkownika">        
    </form><br>

    <a href="users.php">Lista użytkowników</a>
</body>
</html>