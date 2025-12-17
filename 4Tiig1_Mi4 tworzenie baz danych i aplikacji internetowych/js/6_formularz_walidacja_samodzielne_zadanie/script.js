document.getElementById("checkButton").addEventListener("click", function(){
    // pobranie wartości z pól formularza
    const name = document.getElementById("name").value.trim();
    const age = document.getElementById("age").value.trim();
    const result = document.getElementById("result");

    // tablica na komunikaty o błędach
    let errors = [];

    // sprawdzenie imienia, tylko litery, minimum 3 znaki
    const nameRegex = /^[a-zA-ZąćęłńóśżźĄĆĘŁŃÓŚŻŹ]{3,}$/;

    if (!nameRegex.test(name)) {
        errors.push("Imię musi składać się z liter i mieć minimum 3 znaki");
    }

    // sprawdzenie wieku: liczba z zakresu 0-150
    const ageNumber = Number(age);

    if (!/^\d+$/.test(age) || ageNumber < 0 || ageNumber > 150) {
        errors.push("Wiek musi być liczbą z zakresu 0-150");
    }

    // wyświetlenie komunikatów
    if (errors.length > 0) {
        result.innerHTML = errors.join("<br>");
        result.style.color = "red";
    }else{
        result.innerHTML = `Imię: <b>${name}</b><br>Wiek: <b>${ageNumber}</b>`;
        result.style.color = "green";
    }
});