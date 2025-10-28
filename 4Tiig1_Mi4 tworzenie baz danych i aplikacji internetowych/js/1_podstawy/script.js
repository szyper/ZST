//deklarowanie zmiennych
let firstName = "Franciszek"; // zmienna
var lastName = "nowak"; // zmienna (starszy sposób zapisu)
const age = 20; // stała

lastName = "Nowak";



console.log(firstName);
console.log("Imię: ",firstName,", nazwisko: ",lastName,", wiek: ",age," lat");

// typy danych
let text = "Janusz"; // string
let num = "Janusz"; // number
let log = "Janusz"; // boolean

// alert(firstName);

document.writeln("Imię i nazwisko: ",firstName," ",lastName);

// konkatenacja
document.writeln("<br>Imię i nazwisko: " + firstName + " " + lastName);

// template string
document.writeln(`<br>Imię i nazwisko: ${firstName} ${lastName}`);

// zmienna liczbowo-tekstowa
let a = 10;
let b = "8";
console.log(a + b); // 108 (+ traktuje tekst jako łączenie);
console.log(a - b); // 2 (- wymusza konwersję na liczbę);

// dodawanie różnych kombinacji

let i = "10";
let j = 5;
let k = true;
let l = false;

console.log(i + j); // "105" (tekst + liczba -> tekst)
console.log(j + i); // "510" (liczba + tekst -> tekst)
console.log(j + k); // 6 (5 + true -> 5 + 1 -> 6)
console.log(j + l); // 5 (5 + false -> 5 + 0 -> 5)

console.log(Number(true)); // 1
console.log(Number(false)); // 0

// inne operacje

console.log("10" - 4); // 6 -> tekst zamieniono na liczbę
console.log("10" * 4); // 40 -> tekst zamieniono na liczbę
console.log("10" / 4); // 2.5 -> tekst zamieniono na liczbę
console.log("10d" / 4); // NaN -> "10d" nie da się zamienić na liczbę

// kolejność operacji i łączenie wielu typów danych
console.log(10 + 20 + "30"); // "3030" -> (10 + 20) + "30" -> 30 + "30" -> 3030
console.log(10 + "30" + 20); // "103020" -> (10 + "30") + 20 -> "1030" + 20 -> 103020
console.log("30" + 10 + 20); // "301020" -> "30" + 10 + 20 -> "3010" + 20 -> 301020

// konwersja jawna
let c = "10.5";
let d = "5";

console.log(c + d); //10.55
console.log(Number(c) + Number(d)); //15.5
console.log(parseInt(c) + d); // 105
console.log(parseInt(c) + Number(d)); // 15
console.log(parseFloat(d)); // 5
console.log(parseFloat(c) + parseFloat(d)); // 15.5

// łączenie tekstu z różnymi typami
firstName = "Franciszek";
height = 180;
let student = true;

console.log("Mam na imię " + firstName + " i mam " + height + "cm");
console.log(`Mam na imię ${firstName} i mam ${height}cm`);
console.log("Czy jestem studentem? " + student); // Czy jestem studentem? true
console.log(`Typ zmiennej 'student': ${typeof student}`); // Typ zmiennej 'student': boolean
console.log(`Typ zmiennej 'student': ${typeof(student)}`); // Typ zmiennej 'student': boolean

// pułapki
console.log("5" + 1); // "51" -> tekst
console.log("5" - 1); // 4 -> liczba
console.log("5" * "2"); // 10 -> liczba
console.log("5" * "a"); // NaN -> błąd konwersji
console.log(1 + true); // 2 
console.log(1 + false); // 1 
console.log("true" + 1); // "true1" -> tekst

// konwersja liczby na tekst
let n = 123;
let t = String(n);
console.log(t);
console.log(typeof t); //string




