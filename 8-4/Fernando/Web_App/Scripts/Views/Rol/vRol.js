
function vRol() {

	this.tblRolId = 'tblRol';
	this.service = 'Rol';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();

	this.identificadores = ["Id", "Nombre"];

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblRolId, false, this.ctrlActions.ButtonOptions.ModifyDelete);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblRolId, true);
	}

	this.Create = function () {
		var rolData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			rolData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.service, rolData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var rol = new vRol();

				$('#' + rol.createModalId).modal('hide');
				rol.CleanInsert();
				ctrl.FillTable(rol.service, rol.tblRolId, true);

			});
		}
	}
	this.Update = function () {

		var rolData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			rolData = this.ctrlActions.GetDataForm(this.editFormId);
			//Hace el post al create
			this.ctrlActions.PutToAPI(this.service, rolData, this.identificadores, function () {
				var ctrl = new ControlActions();
				var rol = new vRol();

				$('#' + rol.editModalId).modal('hide');
				rol.CleanUpdate();
				ctrl.FillTable(rol.service, rol.tblRolId, true);

			});

		}
	}

	this.Delete = function () {

		var rolData = {};
		rolData = this.ctrlActions.GetSelectedRow(this.tblRolId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, rolData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var rol = new vRol();

			$('#' + rol.deleteModalId).modal('hide');
			ctrl.FillTable(rol.service, rol.tblRolId, true);

		});

	}

	this.UpdateStatus = function () {

		var rolData = {};

		rolData = this.ctrlActions.GetSelectedRow(this.tblRolId);
		//Hace el post al create
		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, rolData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var rol = new vRol();

			$('#' + rol.statusModalId).modal('hide');
			ctrl.FillTable(rol.service, rol.tblRolId, true);

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

	var rol = new vRol();
	rol.RetrieveAll();

});

