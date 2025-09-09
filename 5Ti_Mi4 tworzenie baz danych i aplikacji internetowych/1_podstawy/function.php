<?php
    function show(){
        echo "Funkcja w PHP";
    }

    function showMessage($msg){
        echo "<p>$msg</p>";
    }

    function sum($a, $b){
        return $a + $b;
    }

    function generateList($array){
        echo "<ul>";
            foreach ($array as $fruit) {
                echo "<li>$fruit</li>";
            }
        echo "</ul>";
    }

    function sortArray($array, $order = "desc "){
        if ($order == "asc")
            sort($array); // sortowanie niemalejące 
        elseif ($order == "desc")
            rsort($array); // sortowanie nierosnące
    
        echo "<ul>";
            foreach ($array as $fruit) {
                echo "<li>$fruit</li>";
            }
        echo "</ul>";
    
    }
?>