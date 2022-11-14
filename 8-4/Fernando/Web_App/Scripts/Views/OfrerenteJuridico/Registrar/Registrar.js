function RegistrarOferenteJuridico() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.createFormId = "form-oferete-juridico";
    this.formOferente = "main";
    this.empresa = "form-empresa";

    this.Create = function () {
        var entidad = {};
        var empresa = {};
        entidad = this.ctrlActions.GetDataForm(this.formOferente);
        var indexOferente, indexEmpresa;
        if (markers[0].txtMap === "Oferente") {
            indexOferente = 0;
            indexEmpresa = 1;
        } else {
            indexEmpresa = 0;
            indexOferente = 1;
        }
        entidad.Longitud = "" + markers[indexOferente].marker.position.lng();
        entidad.Latitud = "" + markers[indexOferente].marker.position.lat();
        empresa = this.ctrlActions.GetDataForm("form-empresa");
        empresa.Longitud = "" + markers[indexEmpresa].marker.position.lng();
        empresa.Latitud = "" + markers[indexEmpresa].marker.position.lat();
        empresa.Tipo = "Oferente Jurídico";
        empresa.TipoMembresia = entidad.TipoMembresia;
        empresa.IdRepresentante = entidad.Identificacion;

        this.ctrlActions.PostToAPI(this.service + "/OferenteJuridico",
            {
                usuario: entidad,
                empresa: empresa
            }, "Identificacion,Nombre", function () {
                alert("Success");
            });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    function initOferenteMap(timeToLoad) {
        setTimeout(function () {
            timeToLoad--;
            if (typeof google !== "undefined") {
                initMap(document.querySelector("#main #map"),
                    document.getElementById("borrar-marker"),
                    "Oferente");
            } else {
                initOferenteMap(timeToLoad);
            }
        },100);
    }

    initOferenteMap(100);

    var identificaciones = document.querySelectorAll("input[name='identificacion']");
    identificaciones.forEach(ele => {
        ele.addEventListener("click", function () {
            if (this.type === "radio") {
                var inputId = document.getElementById("id");
                inputId.name = "id" + this.id;
                inputId.removeAttribute("disabled");
                var labelId = document.querySelector("label[for='id']");
                labelId.innerText = this.value;
                labelId.className = labelId.className.replace("disabled", ""); 
            }
        });
    });


    var provincia = document.getElementById("drp-provincia");
    var canton = document.querySelector("[data-container-drp-canton]");
    var distrito = document.querySelector("[data-container-drp-distrito]");
    selectsLocalizacion(provincia, canton, distrito);

    $('#main .mdb-select.validate').materialSelect({
        validate: true,
        labels: {
            validFeedback: 'Correct choice',
            invalidFeedback: 'Wrong choice'
        }
    });
    $('#main .datepicker').pickadate({
        format: 'mm-dd-yyyy',
        max: new Date()
    });
});

