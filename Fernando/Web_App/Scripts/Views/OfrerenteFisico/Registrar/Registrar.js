function RegistrarOferenteFisico() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();
    this.createFormId = "form-oferete-fisico";
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

        if (document.getElementById("form-empresa").children.length !== 0) {
            empresa = ctrlActions.GetDataForm("form-empresa");
            empresa.Longitud = "" + markers[indexEmpresa].marker.position.lng();
            empresa.Latitud = "" + markers[indexEmpresa].marker.position.lat();
        } else {
            empresa.Cedula = entidad.Identificacion;
            empresa.NombreComercial = entidad.Nombre + " " + entidad.PrimerApellido;
            empresa.Provincia = entidad.Provincia;
            empresa.Canton = entidad.Canton;
            empresa.Distrito = entidad.Distrito;
            empresa.Direccion = entidad.Direccion;
            empresa.TipoMembresia = entidad.TipoMembresia;
            empresa.IdRepresentante = entidad.Identificacion;
            empresa.FechaCreacion = "1-1-0001";
            empresa.Longitud = entidad.Longitud;
            empresa.Latitud = entidad.Latitud;
        }
        empresa.Tipo = "Oferente Físico";
        empresa.TipoMembresia = entidad.TipoMembresia;
        empresa.IdRepresentante = entidad.Identificacion;

        this.ctrlActions.PostToAPI(this.service + "/OferenteFisico",
            {
                usuario: entidad,
                empresa: empresa
            }, function () {
                alert("Success");
            });
    }

    this.CreateFormEmpresa = function() {
        this.ctrlActions.GetToServer("Empresa/Registrar", function (response) {
            $("#form-empresa").append(response);
        });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var registrar = new RegistrarOferenteFisico();

    var checkboxEmpresa = document.getElementById("tieneEmpresa");
    if (checkboxEmpresa) {
        checkboxEmpresa.addEventListener("change", function() {
            if (this.checked) {
                registrar.CreateFormEmpresa();
            } else {
                $("#form-empresa").html('');
            }
        });
    }

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

    $('.mdb-select.validate').materialSelect({
        validate: true,
        labels: {
            validFeedback: 'Correct choice',
            invalidFeedback: 'Wrong choice'
        }
    });
    $('.datepicker').pickadate({
        format: 'mm-dd-yyyy',
        max: new Date()
    });
});

