const checkButton = document.getElementById("checkButton");
const result = document.getElementById("result");

checkButton.addEventListener("click", function(){
    const name = document.getElementById("name").value.trim();
    const age = document.getElementById("age").value.trim();

    let errors = [];

    if (!validateName(name)) {
        errors.push("Imię musi się składać z liter i mieć minimum 3 znaki");
    }

});

function validateName(name){
    const nameRegex = /^[a-zA-ZąćęłńóśżźĄĆĘŁŃÓŚŻŹ]{3,}$/;
    return nameRegex.test(name);
}

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