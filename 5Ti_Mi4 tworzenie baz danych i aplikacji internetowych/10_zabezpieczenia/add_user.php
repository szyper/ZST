<?php
    include_once "init.php";

    // if ($conn->connect_errno) {
    //     die("Błąd połączenia z bazą danych: ". $conn->connect_error);
    // }

    $first_name = $_POST['first_name'] ?? '';
    $last_name = $_POST['last_name'] ?? '';
    $email = $_POST['email'] ?? '';

    // zabezpieczenie

    $sql = "INSERT INTO `users` (`first_name`, `last_name`, `email`) VALUES ('$first_name', '$last_name', '$email');";
    //$sql = "SELECT * FROM users";

    echo $conn->connect_errno;


    //$conn->query($sql);

    if ($conn->query($sql)) {
        echo "Prawidłowo dodano użytkownika<br>";
        echo "<a href='form.php'>Dodaj użytkownika</a>";
    }else{
        echo "Błąd: " . $conn->error;
    }
    
    $conn->close();
?>