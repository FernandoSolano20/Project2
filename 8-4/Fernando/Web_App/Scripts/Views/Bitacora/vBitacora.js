
function vBitacora() {

	this.tblBitacoraId = 'tblBitacora';
	this.service = 'Bitacora';

	this.ctrlActions = new ControlActions();

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblBitacoraId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblBitacoraId, true);
	}

	this.OnSelect = function () {

	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var bitacora = new vBitacora();
	bitacora.RetrieveAll();

});

