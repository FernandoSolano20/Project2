let regexText = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+(\s*[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*)*[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$/;
let regexTextNumber = /^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]+(\s*[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]*)*[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]+$/;
let regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
let regexPassport = /^[A-Z0-9<]{9}[0-9]{1}[A-Z]{3}[0-9]{7}[A-Z]{1}[0-9]{7}[A-Z0-9<]{14}[0-9]{2}$/;

let validarNumeros = function(valor) {
    var response = {};
    if (!(noVacio(valor).result)) {
        return false;
    }
    else if (isNaN(valor)) {
        response.message = "Solo debe tener números.";
        response.result = false;
        return response;
    }
    else if (valor < 0) {
        response.message = "Debe ser números positivos.";
        response.result = false;
        return response;
    }
    response.message = "Cumple con el formato.";
    response.result = true;
    return response;
}

let validarTexto = function (valor) {
    var response = {};
    if (!regexText.test(valor)) {
        response.message = "Solo debe tener letras.";
        response.result = false;
        return response;
    }
    response.message = "Cumple con el formato.";
    response.result = true;
    return response;
}

let validarTextoNumero = function (valor) {
    var response = {};
    if (!regexTextNumber.test(valor)) {
        response.message = "Solo debe tener letras o números.";
        response.result = false;
        return response;
    }
    response.message = "Cumple con el formato.";
    response.result = true;
    return response;
}

let noVacio = function (valor) {
    if (valor == "") {
        response.message = "Rellene el campo."
        response.result = false;
        return response;
    }
    response.message = "Cumple con el formato.";
    response.result = true;
    return response;
}

let validarCorreo = function (valor) {
    if (!noVacio(valor).result) {
        response.message = "Rellene el campo.";
        response.result = false;
        return response;
    }
    else if (!regexEmail.test(valor)) {
        response.message = "El correo no cumple el formato.";
        response.result = false;
        return response;
    }
    else {
        response.message = "Cumple con el formato.";
        response.result = true;
        return response;
    }
}

let validarRadio = function (elementos) {
    for (let i = 0; i < elementos.length; i++) {
        if (elementos[i].checked) {
            response.message = "Cumple con el formato.";
            response.result = true;
            return response;
        }
    }
    response.message = "Campo requerido.";
    response.result = false;
    return response;
}

//let validarFotos = function (elementos) {
//    let fileName = elementos.value,
//        idxDot = fileName.lastIndexOf(".") + 1,
//        extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
//    if (!(["jpg", "jpeg", "png"].includes(extFile))) {
//        elementos.alert.innerText = "Seleccione un archivo de tipo imagen."
//        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
//        elementos.input.className = elementos.input.className.replace("inputError", "");
//        elementos.input.className = elementos.input.className + " inputError";
//        return false;
//    }
//    else {
//        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
//        //elementos.alert.className = elementos.alert.className + " alertHidden";
//        elementos.alert.innerText = "La imagen esta guardada."
//        elementos.input.className = elementos.input.className.replace("inputError", "");
//        return true;
//    }
//}

let validarSelect = function (elementos) {
    if (elementos.value == "") {
        elementos.alert.innerText = "Seleccione una opción."
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.input.className = elementos.input.className.replace("selectError", "");
        elementos.input.className = elementos.input.className + " selectError";
        return false;
    }
    else {
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.input.className = elementos.input.className.replace("selectError", "");
        elementos.alert.className = elementos.alert.className + " alertHidden";
        return true;
    }
}

//let validarPass = function () {
//    let elementPass1 = {
//        value: passInput1.value,
//        alert: passAlert1,
//        input: passInput1
//    }

//    let elementPass2 = {
//        value: passInput2.value,
//        alert: passAlert1,
//        input: passInput2
//    }

//    if (!noVacio(elementPass1) | !noVacio(elementPass2)) {
//        return false;
//    }
//    else if (elementPass1.value !== elementPass2.value) {
//        elementPass1.alert.innerText = "Las contraseñas no coiciden."
//        elementPass1.alert.className = elementPass1.alert.className.replace("alertHidden", "");
//        elementPass1.input.className = elementPass1.input.className.replace("inputError", "");
//        elementPass1.input.className = elementPass1.input.className + " inputError";
//        elementPass2.input.className = elementPass2.input.className.replace("inputError", "");
//        elementPass2.input.className = elementPass2.input.className + " inputError";
//        return false;
//    }
//    else {
//        elementPass1.alert.className = elementPass1.alert.className.replace("alertHidden", "");
//        elementPass1.input.className = elementPass1.input.className.replace("inputError", "");
//        elementPass1.alert.className = elementPass1.alert.className + " alertHidden";
//        elementPass2.input.className = elementPass2.input.className.replace("inputError", "");
//        return true;
//    }
//}

let validarFecha = function (elementos) {
    let nacimento = new Date(elementos.value);
    nacimento = new Date(nacimento.getUTCFullYear() + "-" + (nacimento.getUTCMonth() + 1) + "-" + nacimento.getUTCDate());
    if (nacimento == 'Invalid Date') {
        elementos.alert.innerText = "Seleccione una fecha."
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.input.className = elementos.input.className.replace("inputError", "");
        elementos.input.className = elementos.input.className + " inputError";
        return false;
    }
    else {
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.alert.className = elementos.alert.className + " alertHidden";
        elementos.input.className = elementos.input.className.replace("inputError", "");
        return true;
    }
}

let validarFechaMayorActual = function (elementos) {
    let nacimento = new Date(elementos.value);
    nacimento = new Date(nacimento.getUTCFullYear() + "-" + (nacimento.getUTCMonth() + 1) + "-" + nacimento.getUTCDate());
    if (nacimento > new Date()) {
        elementos.alert.innerText = "Seleccione una fecha menor a la actual."
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.input.className = elementos.input.className.replace("inputError", "");
        elementos.input.className = elementos.input.className + " inputError";
        return false;
    }
    else {
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.alert.className = elementos.alert.className + " alertHidden";
        elementos.input.className = elementos.input.className.replace("inputError", "");
        return true;
    }
}

let validarFechaMenorActualFech = function (elementos) {
    let nacimento = new Date(elementos.value);
    nacimento = new Date(nacimento.getUTCFullYear() + "-" + (nacimento.getUTCMonth() + 1) + "-" + nacimento.getUTCDate());
    if (nacimento < new Date()) {
        elementos.alert.innerText = "Seleccione una fecha menor a la actual."
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.input.className = elementos.input.className.replace("inputError", "");
        elementos.input.className = elementos.input.className + " inputError";
        return false;
    }
    else {
        elementos.alert.className = elementos.alert.className.replace("alertHidden", "");
        elementos.alert.className = elementos.alert.className + " alertHidden";
        elementos.input.className = elementos.input.className.replace("inputError", "");
        return true;
    }
}

//let validarMapa = function () {
//    if (markers.length === 0) {
//        mapaAlert.className = mapaAlert.className.replace("alertHidden", "");
//        return true;
//    }
//    else {
//        mapaAlert.className = mapaAlert.className.replace("alertHidden", "");
//        mapaAlert.className = mapaAlert.className + " alertHidden";
//        return false;
//    }
//}