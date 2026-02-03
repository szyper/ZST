<?php
    function generateList(array $data){
        echo "<ul>";
            foreach ($data as $value) {
                echo "<li>$value</li>";
            }
        echo "</ul>";
    }

    function generateListType(array $data, $type = "ul"){
        echo "<$type>";
            foreach ($data as $value) {
                echo "<li>$value</li>";
            }
        echo "</$type>";
    }