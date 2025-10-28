<?php
    include_once "init.php";
    // print_r($_POST);

    // Array ( [id] => 4 [first_name] => Anna [last_name] => Pawlak [email] => ap@o2.pl11 )

    $id = $conn->real_escape_string($_POST['id']);
    $first_name = $conn->real_escape_string($_POST['first_name']);
    $last_name = $conn->real_escape_string($_POST['last_name']);
    $email = $conn->real_escape_string($_POST['email']);
    //$email = "nowy@o2.pl";

    // echo htmlspecialchars($first_name);

    // sprawdzamy, czy ten email należy już do innego użytkownika
    $check = $conn->query("SELECT * FROM users WHERE email = '$email' AND id != $id");
    if ($check && $check->num_rows > 0) {
        $_SESSION['message'] = "Błąd: adres email już istnieje";
        $conn->close();
        header("location: edit.php?id=" . urlencode($id));
        exit;
    }

    $sql = "UPDATE `users` SET `first_name` = '$first_name', `last_name` = '$last_name', `email` = '$email' WHERE `users`.`id` = $id;";

    if ($conn->query($sql) === TRUE) {
        $_SESSION['message'] = "Aktualizacja użytkownika zakończona sukcesem";
    }else{
        $_SESSION['message'] = "Błąd: nie zaktualizowano użytkownika (" . $conn->error . ")";
    }

    $conn->close();
    header("location: index.php");
?>