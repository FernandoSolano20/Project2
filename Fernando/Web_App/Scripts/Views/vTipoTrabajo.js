
function vTipoTrabajo() {

	this.tblTipoTrabajoId = 'tblTipoTrabajo';
	this.service = 'TipoTrabajo';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.columns = "ID,Nombre,Estado,Accion";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, false, this.ctrlActions.UserClasses.Administrator);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, true);
	}

	this.Create = function () {
		var tipoTrabajoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			tipoTrabajoData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.service, tipoTrabajoData, function () {

				var ctrl = new ControlActions();
				var tipoTrabajo = new vTipoTrabajo();

				$('#' + tipoTrabajo.createModalId).modal('hide');
				tipoTrabajo.CleanInsert();
				ctrl.FillTable(tipoTrabajo.service, tipoTrabajo.tblTipoTrabajoId, true);

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
				var tipoTrabajo = new vTipoTrabajo();

				$('#' + tipoTrabajo.editModalId).modal('hide');
				tipoTrabajo.CleanUpdate();
				ctrl.FillTable(tipoTrabajo.service, tipoTrabajo.tblTipoTrabajoId, true);

			});

		}
	}

	this.Delete = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetSelectedRow(this.tblTipoTrabajoId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, tipoTrabajoData, function () {
			var ctrl = new ControlActions();
			var tipoTrabajo = new vTipoTrabajo();

			$('#' + tipoTrabajo.deleteModalId).modal('hide');
			ctrl.FillTable(tipoTrabajo.service, tipoTrabajo.tblTipoTrabajoId, true);

		});

	}

	this.UpdateStatus = function () {

		var tipoTrabajoData = {};

		tipoTrabajoData = this.ctrlActions.GetSelectedRow(this.tblTipoTrabajoId);
		//Hace el post al create
		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, tipoTrabajoData, function () {
			var ctrl = new ControlActions();
			var tipoTrabajo = new vTipoTrabajo();

			$('#' + tipoTrabajo.statusModalId).modal('hide');
			ctrl.FillTable(tipoTrabajo.service, tipoTrabajo.tblTipoTrabajoId, true);

		});


	}

	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('editModal', data);
		this.ctrlActions.BindFields('deleteModal', data);
		this.ctrlActions.BindFields('statusModal', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var tipoTrabajo = new vTipoTrabajo();
	tipoTrabajo.RetrieveAll();

});

