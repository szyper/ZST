console.log("Skrypt zewnętrzny");

var lastName = "Nowak";
let firstName = "Tomasz";
const age = 20;

console.log("Imię: ",firstName,", nazwisko: ",lastName,", wiek: ",age," lat");

let text = "Janusz"; //string
let num = 20;
let log = false;

// alert(log);

document.writeln("Imię i nazwisko: ",firstName," ",lastName);

// konkatenacja
document.writeln("<br>Imię i nazwisko: " + firstName + " " + lastName)

// template string
document.writeln(`<br>Imię i nazwisko: ${firstName} ${lastName}<hr>`);

// zmienne liczbowo-tekstowe
let a = 10;
let b = "8";
document.writeln(a + b); // 108 (+ traktuje tekst jako łączenie)
document.writeln(a - b); // 2 (- wymusza konwersjęna liczbę)

let i = "10";
let j = 5;
let k = true;
let l = false;

document.writeln(i + j); // "105" (tekst + liczba -> tekst)
document.writeln(j + i); // "510" (liczba + tekst -> tekst)
document.writeln(j + k); // 6 (5 + true -> 5 + 1 -> 6)
document.writeln(j + l); // 5 (5 + false -> 5 + 0 -> 5)

document.writeln(true); // true
console.log(true); // true
console.log(false); // false

document.writeln("<br>");

// inne operacje
document.writeln("10" - 4); // 6 -> tekst zmieniono na liczbę
document.writeln("10" * 4); // 40 -> tekst zmieniono na liczbę
document.writeln("10" / 4); // 2.5 -> tekst zmieniono na liczbę
document.writeln("10d" / 4); // NaN -> "10d" nie da się zamienić na liczbę

// kolejność operacji i łączenie wielu typów danych
document.writeln("<br>");
document.writeln(10 + 20 + "30"); // "3030" -> (10 + 20) + "30" -> 30 + "30" -> 3030
document.writeln(10 + "30" + 20); // "103020" -> (10 + "30") + 20 -> "1030" + 20 -> "103020"
document.writeln("30" + 10 + 20); // "301020" -> "30" + 10 + 20 -> "3010" + 20 -> 301020






