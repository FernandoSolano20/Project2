
function vMntTipoTrabajo() {

	this.tblTipoTrabajoId = 'tblTipoTrabajo';
	this.service = 'TipoTrabajo';
	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';
	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.ctrlActions = new ControlActions();
	this.columns = "ID,Nombre,Estado,Accion";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTipoTrabajoId, false, true);
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

	this.Delete = function () {

		var tipoTrabajoData = {};
		tipoTrabajoData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, tipoTrabajoData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('editModal', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var tipoTrabajo = new vMntTipoTrabajo();
	tipoTrabajo.RetrieveAll();

});

