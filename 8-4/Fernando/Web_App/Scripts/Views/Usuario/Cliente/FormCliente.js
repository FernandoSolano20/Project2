function FormCliente() {

    this.service = 'Usuario';
    this.ctrlActions = new ControlActions();

    this.Create = function () {
        var tipoTrabajoData = {};
        if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
            tipoTrabajoData = this.ctrlActions.GetDataForm(this.createFormId);
            //Hace el post al create
            this.ctrlActions.PostToAPI(this.service, tipoTrabajoData, function () {

                var ctrl = new ControlActions();
                var mntTipoTrabajo = new vMntTipoTrabajo();

                $('#' + mntTipoTrabajo.createModalId).modal('hide');
                mntTipoTrabajo.CleanInsert();
                ctrl.FillTable(mntTipoTrabajo.service, mntTipoTrabajo.tblTipoTrabajoId, true);

            });
        }
    }

    this.Update = function () {

        var tipoTrabajoData = {};
        if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

            tipoTrabajoData = this.ctrlActions.GetDataForm(this.editFormId);
            //Hace el post al create
            this.ctrlActions.PutToAPI(this.service, tipoTrabajoData, function () {
                var ctrl = new ControlActions();
                var mntTipoTrabajo = new vMntTipoTrabajo();

                $('#' + mntTipoTrabajo.editModalId).modal('hide');
                mntTipoTrabajo.CleanUpdate();
                ctrl.FillTable(mntTipoTrabajo.service, mntTipoTrabajo.tblTipoTrabajoId, true);

            });

        }
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
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
        format: 'dd-mm-yyyy',
        max: new Date()
    })
});

