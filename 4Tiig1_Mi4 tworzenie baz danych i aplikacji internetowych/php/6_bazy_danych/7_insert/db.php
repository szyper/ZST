<?php
    $conn = mysqli_connect("localhost", "root", "", "school");

    if (!$conn) {
        die("Błąd połączenia: " . mysqli_error($conn));
    }