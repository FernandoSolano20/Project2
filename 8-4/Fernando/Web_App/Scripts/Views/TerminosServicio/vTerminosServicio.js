function vTerminosServicio() {

	this.tblTerminosServicioId = 'tblTerminoServicio';
	this.service = 'TerminosServicio';
	this.updateStatusAction = 'UpdateStatus';

	this.editFormId = 'editModalForm';
	this.createFormId = 'createModalForm';

	this.editModalId = 'editModal';
	this.createModalId = 'createModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["Titulo"];

	//Traer toda la información
	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblTerminosServicioId, false, this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}

	//Recargar la tabla
	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblTerminosServicioId, true);
	}

	//Create
	this.Create = function () {
		var terminosServicioData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			terminosServicioData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al API
			this.ctrlActions.PostToAPI(this.service, terminosServicioData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var terminosServicio = new vTerminosServicio();

				$('#' + terminosServicio.createModalId).modal('hide');
				terminosServicio.CleanInsert();
				ctrl.FillTable(terminosServicio.service, terminosServicio.tblTerminosServicioId, true);
			});
		}
	}

	//Update
	this.Update = function () {

		var terminosServicioData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {

			terminosServicioData = this.ctrlActions.GetDataForm(this.editFormId);
			//Hace el put al API
			this.ctrlActions.PutToAPI(this.service, terminosServicioData, this.identificadores, function () {
				var ctrl = new ControlActions();
				var terminosServicio = new vTerminosServicio();

				$('#' + terminosServicio.editModalId).modal('hide');
				terminosServicio.CleanUpdate();
				ctrl.FillTable(terminosServicio.service, terminosServicio.tblTerminosServicioId, true);
			});
		}
	}

	//Delete
	this.Delete = function () {

		var terminosServicioData = {};
		terminosServicioData = this.ctrlActions.GetSelectedRow(this.tblTerminosServicioId);
		//Hace el delete al API
		this.ctrlActions.DeleteToAPI(this.service, terminosServicioData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var terminosServicio = new vTerminosServicio();

			$('#' + terminosServicio.deleteModalId).modal('hide');
			ctrl.FillTable(terminosServicio.service, terminosServicio.tblTerminosServicioId, true);
		});
	}

	//UpdateStatus
	this.UpdateStatus = function () {

		var terminosServicioData = {};

		terminosServicioData = this.ctrlActions.GetSelectedRow(this.tblTerminosServicioId);

		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, terminosServicioData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var terminosServicio = new vTerminosServicio();

			$('#' + terminosServicio.statusModalId).modal('hide');
			ctrl.FillTable(terminosServicio.service, terminosServicio.tblTerminosServicioId, true);
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

	var terminosServicio = new vTerminosServicio();
	terminosServicio.RetrieveAll();

});
