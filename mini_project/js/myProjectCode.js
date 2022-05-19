function validateAllFields() {
    var isValid = validateField1();
    if (isValid == true)
        isValid = validateField2();
    if (!isValid)
        idIsValid.innerHTML = "Not valid";
    return isValid;
}

function validateField1() {
    var length = idField1.value.length;
    if (length >= 2)
        return true;
    else
        return false;
}

function validateField2() {
    var length = idField2.value.length;
    if (length >= 5)
        return true;
    else
        return false;
}