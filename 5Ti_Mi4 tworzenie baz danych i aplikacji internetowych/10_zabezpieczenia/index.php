<?php
    include_once "init.php";
    $message = '';
    if (isset($_SESSION['message'])) {
        $message = $_SESSION['message'];
        unset($_SESSION['message']);
    }
?>
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Strona główna</title>
    <style>
        .message {
            display: inline-block;
            padding: 10px 20px;
            margin-bottom: 15px;
            border-radius: 5px;
        }

        .error {
            background-color: #f8d7da;
            color: #842029;
        }

        .success {
            background-color: #d1e7dd;
            color: #0f5132;
        }
    </style>
</head>
<body>
    <h1>Zarządzanie użytkownikami</h1>
    <?php
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
    ?>
    <br>
    <a href="form.php" class="button">Dodaj użytkownika</a>
    <a href="users.php" class="button">Pokaż użytkowników</a>
</body>
</html>