const checkButton = document.getElementById("checkButton");
const result = document.getElementById("result");

checkButton.addEventListener("click", function(){
    // pobranie wartości z pól formularza
    const name = document.getElementById("name").value.trim();
    const age = document.getElementById("age").value.trim();

    // tablica na komunikaty o błędach
    let errors = [];

    // Walidacja imienia
    if (!validateName(name)) {
        errors.push("Imię musi składać się z liter i mieć minimum 3 znaki");
    }

    // walidacja wieku
    if (!validateAge(age)) {
        errors.push("Wiek musi być liczbą z zakresu 0-150");
    }

    if (errors.length > 0) {
        showErrors(errors);
    } else {
        showSuccess(name, age);
    }
});

/* ==== FUNKCJE ==== */

// sprawdzenie poprawności imienia
function validateName(name){
    const nameRegex = /^[a-zA-ZąćęłńóśżźĄĆĘŁŃÓŚŻŹ]{3,}$/;
    return nameRegex.test(name);
}

// sprawdzenie poprawności wieku
function validateAge(age){
    const ageNumber = Number(age);
    
    if (!/^\d+$/.test(age)) {
        return false;
    }

    if (ageNumber < 0 || ageNumber > 150) {
        return false;
    }
    return true;
} 

// wyświetlenie błędów
function showErrors(errors){
    result.innerHTML = errors.join("<br>");
    result.style.color = "red";
}
    
// wyświetlenie poprawnych danych
function showSuccess(name, age){
    result.innerHTML = `Imię: <b>${name}</b><br>Wiek: <b>${age}</b>`;
    result.style.color = "green";
}