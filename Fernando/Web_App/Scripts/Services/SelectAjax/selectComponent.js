function createSelect(searchable, id, columnDataName, name,disabled = false) {
    var select = document.createElement("select");
    select.setAttribute("class", "mdb-select validate md-form");
    select.setAttribute("ColumnDataName", columnDataName);
    if (disabled) {
        select.setAttribute("disabled","true");
    }
    select.setAttribute("searchable", searchable);
    select.setAttribute("id", id);
    select.setAttribute("name", name);
    return select;
}

function createLabel(text) {
    var label = document.createElement("label");
    label.setAttribute("class", "mdb-main-label");
    label.innerText = text;
    return label;
}

Element.prototype.crearDropDown = function (response, container, labelText) {
    var select = this;
    $("#" + select.id).materialSelect({
        destroy: true
    });
    select.innerHTML = "";

    var option = document.createElement("option");
    option.setAttribute("disabled","true");
    option.innerText = "Escoga una opción";
    option.selected = true;
    option.value = "";
    select.appendChild(option);

    response.forEach(data => {
        var option = document.createElement("option");
        option.value = data;
        option.innerText = data;
        select.appendChild(option);
    });
    var label = createLabel(labelText);
    container.appendChild(select);
    container.appendChild(label);
    var p = document.createElement("p");
    p.setAttribute("class", "messages");
    container.appendChild(p);
    $("#" + select.id).materialSelect({
        validate: true,
        labels: {
            validFeedback: 'Correct choice',
            invalidFeedback: 'Wrong choice'
        }
    });
    
}