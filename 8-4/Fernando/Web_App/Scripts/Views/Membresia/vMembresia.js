
function vMembresia() {

	this.service = 'Membresia';
	this.configuracionService = 'Configuracion';
	this.monedaService = 'Moneda/ObtenerMonedaValor';

	this.updateStatusAction = 'UpdateDate';
	this.getCurrentMembershipAction = 'MembresiaActual';

	this.txtCostoMembresiaEstandar = 'txtCostoEstandar';
	this.txtMonedaMembresiaEstandar = 'txtMonedaEstandar';

	this.membresiaEstandarModalId = 'membresiaEstandarModal';
	this.membresiaEstandarAmpliarModalId = 'membresiaEstandarAmpliarModal';
	this.membresiaPremiumModalId = 'membresiaPremiumModal';

	this.btnMostrarModalMembresiaEstandar = "btnAdquirirEstandar";

	this.identificadores = ['ID'];

	this.ctrlActions = new ControlActions();

	this.RetrieveMembership = function () {
		var user = this.ctrlActions.GetLoggedUser();
		this.ctrlActions.GetToApiId(this.service, this.getCurrentMembershipAction, user, function (membresiaData) {
			let membresia = new vMembresia();
			var IVA = { Parametro: "IVA" };

			membresia.ctrlActions.GetToApiId(membresia.configuracionService, "", IVA, function (impuestosData) {
				membresia.ConfigurarInformacionModal(membresiaData, impuestosData);
				membresia.ConfigurarBotonPago(membresiaData, impuestosData);
			})
			
			

		});
	}

	this.Create = function () {
		var membresiaData = {};
		if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
			membresiaData = this.ctrlActions.GetDataForm(this.createFormId);
			//Hace el post al create
			this.ctrlActions.PostToAPI(this.service, membresiaData, this.identificadores, function () {

				var ctrl = new ControlActions();
				var membresia = new vMembresia();

				$('#' + membresia.createModalId).modal('hide');
				membresia.CleanInsert();
				ctrl.FillTable(membresia.service, membresia.tblMembresiaId, true);

			});
		}
	}

	this.UpdateEstandar = function () {

		var membresiaData = {};

		membresiaData = { ID_Representante: this.ctrlActions.GetLoggedUser().IdentificacionUsuario }
		var service = `${this.service}/${this.updateStatusAction}`;
		//Hace el post al create
		this.ctrlActions.PutToAPI(service, membresiaData, this.identificadores, function () {
			var ctrl = new ControlActions();
			var membresia = new vMembresia();

			$('#' + membresia.membresiaEstandarModalId).modal('hide');
			$('#' + membresia.membresiaEstandarAmpliarModalId).modal('hide');
		});

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields(this.editModalId, data);
		this.ctrlActions.BindFields(this.deleteModalId, data);
		this.ctrlActions.BindFields(this.statusModalId, data);
	}

	this.ConfigurarInformacionModal = function (membresiaData, impuestosData) {
		let membresia = new vMembresia();

		if (membresia.MembresiaVigente(membresiaData)) {
			$('#' + membresia.btnMostrarModalMembresiaEstandar).attr('data-target', '#' + membresia.membresiaEstandarAmpliarModalId);
		}

		this.ctrlActions.GetToApi(this.monedaService, function (monedas) {
			let membresia = new vMembresia();
			var display = {};

			if (Boolean(membresiaData.Moneda) && Boolean(membresiaData.Costo) && Boolean(monedas)) {

				var tipoCambioUsuario = monedas[membresiaData.Moneda];
				var costoOriginalMembresia = membresiaData.Costo;
				var porcentajeImpuestos = impuestosData.Valor;

				var costoNeto = parseInt(tipoCambioUsuario * costoOriginalMembresia);
				var impuestos = parseInt(tipoCambioUsuario * (costoOriginalMembresia * porcentajeImpuestos));

				display.Moneda = membresiaData.Moneda;
				display.Costo = costoNeto + impuestos;

				membresia.ctrlActions.BindFields(membresia.membresiaEstandarModalId, display);
				membresia.ctrlActions.BindFields(membresia.membresiaEstandarAmpliarModalId, display);
			}
		});	
	}

	this.ConfigurarBotonPago = function (membresiaData, impuestosData) {

		if (Boolean(membresiaData.Costo)) {

			var costo = 0;
			var costoOriginalMembresia = membresiaData.Costo;
			var porcentajeImpuestos = impuestosData.Valor;

			var costoNeto = costoOriginalMembresia;
			var impuestos = costoOriginalMembresia * porcentajeImpuestos;

			costo = costoNeto + impuestos;

			var paypalService = new PayPalService();
			var membresia = new vMembresia();
			paypalService.pagoMembresiaEstandar(membresia, costo);
		}

	}

	this.MembresiaVigente = function (data) {
		if (Boolean(data.Fecha)) {
			return new Date(data.Fecha).valueOf() > new Date().valueOf();
		}
		return false;
	}
}
//ON DOCUMENT READY
$(document).ready(function () {

	var membresia = new vMembresia();
	membresia.RetrieveMembership();

});

