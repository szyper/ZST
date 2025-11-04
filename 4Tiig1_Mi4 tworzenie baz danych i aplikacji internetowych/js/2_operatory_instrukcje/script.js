let x = 20;
let y = 3;

// operatory arytmetyczne
console.log("x + y = ", x + y); // 23
console.log("x - y = ", x - y); // 17
console.log("x * y = ", x * y); // 60
console.log("x / y = ", x / y); // 6.666666666666667
console.log("x % y = ", x % y); // 2 (reszta z dzielenia)
console.log("x ** y = ", x ** y); // 8000 (potęgowanie)

// operatory inkrementacji i dekrementacji
let z = 5;
console.log("z = ", z);
console.log("z++ = ", z++); // wypisze 5, następnie zmieni na 6
console.log("z = ", z); // 6
console.log("++z = ", ++z); // wypisze 7
console.log("--z = ", --z); // wypisze 6
console.log("z-- = ", z--); // wypisze 6, następnie zmieni na 5
console.log("z = ", z); // 5

x = 5;
console.log(x); // 5
console.log(x++); // 5
console.log(++x); // 7
console.log(x--); // 7
console.log(x); // 6
console.log(--x); // 5
console.log(x++); // 5
console.log(x); // 6

x = 10;
console.log(x++); // 10
console.log(++x + x++); // 24  
console.log(x-- - --x); // 2 
console.log(x); // 11
console.log(x++ + ++x); // 24

console.log("Końcowa wartość x = ", x); // 13

// operatory porównania
let a = 10;
let b = "10";

console.log(a == b); // true -> porównanie wartości
console.log(a === b); // fale -> porównanie wartości i typów
console.log(a != b); // false 
console.log(a !== b); // true 
console.log(a > 5); // true 
console.log(a <= 10); // true 
console.log(b <= 10); // true 

// operatory logiczne
let age = 18;
let hasID = true;

console.log(age >= 18 && hasID); // true (AND => i)
console.log(age >= 18 || hasID); // true (OR => lub)
console.log(!hasID); // false (negacja)

// instrukcje warunkowe if, else if, else
let temperature = 22;

if (temperature > 30) {
    console.log("Bardzo gorąco");
} else if (temperature >= 20){
    console.log("Ciepło");
} else{
    console.log("Chłodno");
}

// operator warunkowy
let isStudent = true;
let message = isStudent ? "Masz zniżkę" : "Brak zniżki";
console.log(message);



