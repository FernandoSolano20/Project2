
function Listar() {

    this.tblUsuarioId = 'tblUsuario';
    this.service = 'Usuario';
    this.updateStatusAction = 'UpdateStatus';

    this.deleteModalId = 'deleteModal';
    this.statusModalId = 'statusModal';

    this.ctrlActions = new ControlActions();
    this.identificadores = ["Identificacion", "Nombre"];

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuarioId, false, this.ctrlActions.ButtonOptions.ModifyDeleteEdit);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, true);
    }

    this.Delete = function () {

        var usuario = {};
        usuario = this.ctrlActions.GetSelectedRow(this.tblUsuarioId);
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var listar = new Listar();

            $('#' + listar.deleteModalId).modal('hide');
            ctrl.FillTable(listar.service, listar.tblUsuarioId, true);

        });

    }

    this.UpdateStatus = function () {

        var usuario = {};

        usuario = this.ctrlActions.GetSelectedRow(this.tblUsuarioId);

        if (usuario.Estado == "ACT") {
            usuario.Estado = "DES";
        }
        else {
            usuario.Estado = "ACT";
        }

        //Hace el post al create
        var serviceURL = `${this.service}/${this.updateStatusAction}`;

        this.ctrlActions.PutToAPI(serviceURL, usuario, this.identificadores, function () {
            var ctrl = new ControlActions();
            var listar = new Listar();

            $('#' + listar.statusModalId).modal('hide');
            ctrl.FillTable(listar.service, listar.tblTipoTrabajoId, true);

        });
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('deleteModal', data);
        this.ctrlActions.BindFields('statusModal', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var listar = new Listar();
    listar.RetrieveAll();

});

