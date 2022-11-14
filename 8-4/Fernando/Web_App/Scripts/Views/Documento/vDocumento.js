
function vDocumento() {

	this.tblDocumentoId = 'tblDocumento';
	this.service = 'Documento';
	this.PostDocumentRoute = 'DocumentoProveedor';
	this.updateStatusAction = 'UpdateStatus';
	this.getPerIDAction = 'ObtenerPorUsuario';

	this.createFormId = 'createModalForm';
	this.editFormId = 'editModalForm';

	this.createModalId = 'createModal';
	this.editModalId = 'editModal';
	this.deleteModalId = 'deleteModal';
	this.statusModalId = 'statusModal';

	this.ctrlActions = new ControlActions();
	this.identificadores = ["ID"];

	this.RetrievePerID = function () {
		var usuario = this.ctrlActions.GetLoggedUser();

		this.ctrlActions.FillTablePerID(this.service, this.getPerIDAction, usuario, this.tblDocumentoId, false, this.ctrlActions.ButtonOptions.ModifyDeleteStatus);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblDocumentoId, true);
	}

	this.CreateDocument = function () {
		var documentoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			documentoData = this.ctrlActions.GetDataForm(this.createFormId);
			//Se añade el propietario del documento
			documentoData['ID_Propietario'] = this.ctrlActions.GetLoggedUser().IdentificacionUsuario;
			//Se redirige al action de documento
			var service = this.service + "/" + this.PostDocumentRoute;
			this.ctrlActions.PostToAPI(service, documentoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var documento = new vDocumento();

				$('#' + documento.createModalId).modal('hide');
				documento.CleanInsert();
				ctrl.FillTable(documento.service, documento.tblDocumentoId, true);

			});
		}
	}

	this.UpdateDocument = function () {

		var documentoData = {};
		if (!this.ctrlActions.ValidateDataForm(this.editFormId)) {
			documentoData = this.ctrlActions.GetDataForm(this.editFormId);
			//Se añade el propietario del documento
			documentoData['ID_Propietario'] = this.ctrlActions.GetLoggedUser().IdentificacionUsuario;
			this.ctrlActions.PutToAPI(this.service, documentoData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var documento = new vDocumento();

				$('#' + documento.editModalId).modal('hide');
				documento.CleanInsert();
				ctrl.FillTable(documento.service, documento.tblDocumentoId, true);

			});
		}
	}


	this.Delete = function () {

		var documentoData = {};
		documentoData = this.ctrlActions.GetSelectedRow(this.tblDocumentoId);
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, documentoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var documento = new vDocumento();

			$('#' + documento.deleteModalId).modal('hide');
			ctrl.FillTable(documento.service, documento.tblDocumentoId, true);

		});

	}

	this.UpdateStatus = function () {

		var documentoData = {};

		documentoData = this.ctrlActions.GetSelectedRow(this.tblDocumentoId);
		//Hace el post al create
		var serviceURL = `${this.service}/${this.updateStatusAction}`;

		this.ctrlActions.PutToAPI(serviceURL, documentoData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var documento = new vDocumento();

			$('#' + documento.statusModalId).modal('hide');
			ctrl.FillTable(documento.service, documento.tblDocumentoId, true);

		});
	}

	this.CleanInsert = function () {
		this.ctrlActions.CleanDataForm(this.createFormId);
	}

	this.CleanUpdate = function () {
		this.ctrlActions.CleanDataForm(this.editFormId);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.editModalId, data);
		this.ctrlActions.BindFields(this.deleteModalId, data);
		this.ctrlActions.BindFields(this.statusModalId, data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var documento = new vDocumento();
	documento.RetrievePerID();

});

