
function OferentesPendientes() {

    this.tbEntityId = 'tblOferente';
    this.service = 'Usuario';
    this.aceptarAction = 'Aceptar';

    this.aceptarModalId = 'aceptarModal';
    this.rechazarModalId = 'rechazarModal';

    this.ctrlActions = new ControlActions();
    this.identificadores = ["Identificacion", "Nombre"];

    this.RetrieveAll = function () {
        var url = this.service + "/OferentesPendientes";
        var customActionColumn = [];

        var actionColumnAceptar = {};
        actionColumnAceptar.data = null;
        actionColumnAceptar.className = "text-center";
        actionColumnAceptar.defaultContent = '<a href="#" data-toggle="modal" data-target="#aceptarModal"><i class="fas fa-user-check"></i></a>';

        customActionColumn.push(actionColumnAceptar);

        var actionColumnRechazar = {};
        actionColumnRechazar.data = null;
        actionColumnRechazar.className = "text-center";
        actionColumnRechazar.defaultContent = '<a href="#" data-toggle="modal" data-target="#rechazarModal"><i class="fas fa-user-times"></i></a>';

        customActionColumn.push(actionColumnRechazar);

        this.ctrlActions.FillTable(url, this.tbEntityId, false, "", customActionColumn);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + "", this.tblTipoTrabajoId, true);
    }

    this.Rechazar = function () {

        var usuario = {};
        usuario = this.ctrlActions.GetSelectedRow(this.tbEntityId);
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var view = new OferentesPendientes();

            $('#' + view.rechazarModalId).modal('hide');
            var url = view.service + "/OferentesPendientes";
            ctrl.FillTable(url, view.tbEntityId, true);

        });

    }

    this.Aceptar = function () {

        var usuario = {};

        usuario = this.ctrlActions.GetSelectedRow(this.tblUsuarioId);
        usuario.Estado = "DESYNOPAGO";
        //Hace el post al create
        var serviceURL = `${this.service}/${this.aceptarAction}`;

        this.ctrlActions.PutToAPI(serviceURL, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var view = new OferentesPendientes();

            var url = "Membresia/PostMembresiaRegular";
            var membresaiRegular = {
                Tipo: "Regular",
                Costo: document.getElementById("normal"),
                ID_Empresa: usuario.IdEmpresa
            }

            ctrl.ctrlActions.PostToAPI(url, membresaiRegular, "",
                function (response) {
                    alert("Cambiada");
                    window.redirect("/");
                });

            var membresiaPremium = {
                Tipo: "Premium",
                Costo: document.getElementById("premium"),
                ID_Empresa: usuario.IdEmpresa
            }
            ctrl.ctrlActions.PostToAPI("Contrasenna", membresiaPremium, "",
                function (response) {
                    alert("Cambiada");
                    window.redirect("/");
                });

            var fi = {
                Tipo: "FI",
                Fecha: new Date(Date.now()),
                Estado: "ACT",
                Costo: document.getElementById("fi"),
                ID_Empresa: usuario.IdEmpresa
            }
            ctrl.ctrlActions.PostToAPI("Contrasenna", fi, "",
                function (response) {
                    alert("Cambiada");
                    window.redirect("/");
                });


            $('#' + view.aceptarModalId).modal('hide');


            var url = view.service + "/OferentesPendientes";
            ctrl.FillTable(url, view.tbEntityId, true);

        });
    }

    this.CleanUpdate = function () {
        this.ctrlActions.CleanDataForm("aceptarModal-form");
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('rechazarModal', data);
        var btnSave = document.getElementById("btnSave");
        btnSave.setAttribute("data-user",data.Identificacion);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var view = new OferentesPendientes();
    view.RetrieveAll();

});

