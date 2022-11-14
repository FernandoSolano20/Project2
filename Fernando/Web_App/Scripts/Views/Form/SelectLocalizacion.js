var selectsLocalizacion = function (provincia, containerCanton, containerDistrito, isEmpresa = false) {
    var url = "Localizacion/";
    var idEmpresa = isEmpresa ? "-empresa" : "";
    var nameEmpresa = isEmpresa ? "Empresa" : "";
    var ctrlActions = new ControlActions();
    provincia.addEventListener("change", function (event) {
        event.preventDefault();
        var selectDis = createSelect("Buscar", "drp-distrito" + idEmpresa, "Distrito", "drpDistrito" + nameEmpresa, true);
        containerDistrito.innerHTML = "";
        containerDistrito.className = containerDistrito.className.replace("has-error", "");
        selectDis.crearDropDown([], containerDistrito, "Distrito");
        ctrlActions.GetToApi(url + "ObtenerCantones?provincia=" + provincia.value, function (response) {
            var select = createSelect("Buscar", "drp-canton"+idEmpresa, "Canton", "drpCanton"+nameEmpresa);
            containerCanton.innerHTML = "";
            containerCanton.className = containerCanton.className.replace("has-error", "");
            select.crearDropDown(response, containerCanton, "Canton");
            select.addEventListener("change", function (event) {
                ctrlActions.GetToApi(url + "ObtenerDistritos?provincia=" + provincia.value + "&canton=" + select.value,
                    function (response) {
                        var selectDist = createSelect("Buscar", "drp-distrito" + idEmpresa, "Distrito", "drpDistrito" + nameEmpresa);
                        containerDistrito.innerHTML = "";
                        containerDistrito.className = containerDistrito.className.replace("has-error", "");
                        selectDist.crearDropDown(response, containerDistrito, "Distrito");
                    });
            });
        });
    });
}