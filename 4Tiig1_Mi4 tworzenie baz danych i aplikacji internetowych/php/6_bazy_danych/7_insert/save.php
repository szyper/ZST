<?php
    // print_r($_POST);
    require_once 'db.php';
    
    if (!empty($_POST['first_name']) && !empty($_POST['last_name']) &&!empty($_POST['email']) && !empty($_POST['birthday'])) {
        $first_name = $_POST['first_name'];
        $last_name = $_POST['last_name'];
        $email = $_POST['email'];
        $birthday = $_POST['birthday'];

        $created_at = date("Y-m-d H:i:s");

        // echo $created_at;

        $sql = "INSERT INTO `students` (`first_name`, `last_name`, `email`, `birthday`, `created_at`) VALUES ('$first_name', '$last_name', '$email', '$birthday', '$created_at');";

        if (mysqli_query($conn, $sql)) {
            echo "Prawidłowo dodano użytkownika";
        } else {
            echo "Nie udało się dodać użytkownika<br>";
            echo "Błąd: " . mysqli_error($conn);
        }
        
        mysqli_close($conn);

    } else {
        echo "<h4>Wypełnij wszystkie pola!</h4>";
    }