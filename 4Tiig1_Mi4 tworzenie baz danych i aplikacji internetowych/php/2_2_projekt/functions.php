<?php
    function showCar($car){
        $brand = ucfirst(strtolower($car['brand']));
        $model = ucfirst(strtolower($car['model']));
        return "Marka: $brand, model: $model, kolor: {$car['color']}";
    }

