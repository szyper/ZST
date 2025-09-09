<?php

	// echo "<pre>";
	// 	print_r($_POST);
	// echo "</pre>";

	if ($_SERVER["REQUEST_METHOD"] === "POST") {
		$firstName = $_POST['name'] ?? '';
		$email = isset($_POST['email']) ? $_POST['email'] : '';
		$message = $_POST['message'] ?? '';
		$gender = isset($_POST['gender']) ? $_POST['gender'] : 'Nie wybrano';
		$hobbies = isset($_POST['hobbies']) ? $_POST['hobbies'] : [];
		$country = isset($_POST['country']) && $_POST['country'] !== '' ? $_POST['country'] : 'nie wybrano';
		$textColor = isset($_POST['textColor']) ? $_POST['textColor'] : "#000000";


		//echo $firstName."<br>".$_POST['email'];
		echo "<hr>$firstName<br>$_POST[email]<br>Wiadomość: $message<br>";
		echo "Płeć: " . $gender . "<br>";
		if (!empty($hobbies)) {
			echo "Zainteresowania: " . implode(", ", $hobbies) . "<br>";
		}else{
			echo "Zainteresowania: brak<br>";
		}

		echo "Kraj: " . $country . "<br>";

		echo "Wybrany kolor: ";
		echo "<span style='color: $textColor'>Wybrany kolor</span><br>";
		echo "Wybrany kolor (hex): " . $textColor . "<br>";
	} else {
		echo "Wypełnij formularz";
	}	
	
	
?>