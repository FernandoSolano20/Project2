
function ControlActions() {

	/*
	 * Objeto para obtener y manejar los distintos tipos de usuarios en la plataforma
	 Se utiliza para mostrar informacion dependiendo del usuario seleccionado
	 Utilizado en la tabla para determinar los botones de accion que hay que mostrar
	 */

	this.UserClasses = {
		Administrator : "ADMINISTRATOR"
	};

	/*
	 URL del WEB_API. Se utiliza para hacer las consultas necesarias al backend
	 */

    this.URL_API = "https://localhost:44347/api/";

    this.URL_SERVER = "https://localhost:44306/";

	/**
	 * /Funcion para agregar el Servicio o el Controlador al que tiene que llegar el
	 * API para obtener la informacion necesaria.
	 * Ej: https://localhost:44347/api/TipoTrabajo
	 * @param {string} service Nombre del controlador del API
	 * Retorna la concatenacion de la URL con el Controlador especificado
	 */

	this.GetUrlApiService = function (service) {
		return this.URL_API + service;
    }

    this.GetUrlServerService = function (service) {
        return this.URL_SERVER + service;
    }

	/**
	 * / Recibe el id de la tabla y retorna el atributo de ColumnsDataName
	    Esto para permitir relacionarlo con los inputs necesarios de cada columna
		Este dato es asignado a la hora de crear la tabla con el CtrlModel
	 * @param {string} tableId Id de la tabla con el dato de ColumnsDataName
	 * Retorna el atributo ColumnsDataName de la tabla
	 */
	this.GetTableColumsDataName = function (tableId) {
		var val = $('#' + tableId).attr("ColumnsDataName");

		return val;
	}

	/**
	 * /Metodo que rellena la tabla con la informacion proveniente de la base de datos
	 * @param {string} service Controlador necesario del API
	 * @param {string} tableId ID de la tabla del HTML donde se va a mostrar la informacion
	 * @param {bool} refresh Define si hay que cargar por completo la tabla o solo refrescar la informacion
	 * @param {string} userClass Parametro proveniente de esta clase (ControlActions), en donde se especifica el usuario que esta pidiendo ver la informacion de la tabla, por lo que se puede modificar la informacion que es desplegada
	 */
	this.FillTable = function (service, tableId, refresh, userClass) {

		if (!refresh) {
			//Obtiene las columnas de la tabla
			columns = this.GetTableColumsDataName(tableId).split(',');
			var arrayColumnsData = [];

			//Ciclo foreach que añade los títulos de las columnas a la tabla
			$.each(columns, function (index, value) {
				var obj = {};
				obj.data = value;
				arrayColumnsData.push(obj);
			});

			//Condicional que determina los botones de accion por agregar si el usuario es Administrador.  Agregar Editar, eliminar y activar/desactivar
			if (userClass === this.UserClasses.Administrator) {

				var actionColumn = {};
				actionColumn.data = null;
				actionColumn.className = "text-center";
				actionColumn.defaultContent = '<a href="#" data-toggle="modal" data-target="#editModal"><i class="far fa-edit fa-lg"></i></a> <a href="#" data-toggle="modal" data-target="#deleteModal"><i class="far fa-trash-alt fa-lg"></i></a> <a href="#" data-toggle="modal" data-target="#statusModal"><i class="far fa-eye fa-lg"></i></a>';

				arrayColumnsData.push(actionColumn);
			}
			
			//Se hace la consulta al API y se carga la informacion a la tabla
			$('#' + tableId).DataTable({
				"processing": true,
				"ajax": {
					"url": this.GetUrlApiService(service),
					dataSrc: 'Data'
				},
				"columns": arrayColumnsData
			});
		} else {
			//RECARGA LA TABLA
			$('#' + tableId).DataTable().ajax.reload();
		}

	}

	/**
	 * /Obtiene la informacion del Session Storage que fue almacenada con el ID de la tabla
	 * Estos datos fueron guardados en formato JSON. Este almacenamiento se hace en el Ctrl html al seleccionar una fila
	 * Se hace un parse de este string para obtener un objeto
	 * @param {string} tableId Id de la tabla de donde proviene el dato. El dato fue guardo en session storage con el id de la tabla concatenado con _selected
	 * Retorna un objeto con la informacion parseada
	 */
	this.GetSelectedRow = function (tableId) {
		var sessionData = sessionStorage.getItem(tableId + '_selected');
		var dataObject = JSON.parse(sessionData);
		return dataObject;
	};

	/**
	 * /Se relacionan los datos de la fila seleccionada en la tabla con los inputs o elementos HTML necesarios
	 * @param {string} formId Id del form donde se van a mostrar los datos
	 * @param {object} data Objeto con los campos y los valores de la fila seleccionada
	 */
	this.BindFields = function (formId, data) {
        $('#' + formId + ' *').filter(':input').each(function (input) {
			var columnDataName = $(this).attr("ColumnDataName");
			this.value = data[columnDataName];

			if ($(this).get(0).tagName === "SPAN")
				this.innerHTML = data[columnDataName];
		});
	}

	/**
	 * /Se obtienen los valores digitados en un formulario
	 * @param {string} formId Id del formulario HTML del que se ocupa extraer la informacion
	 * Retorna un objeto con los campos y valores de los inputs
	 */
	this.GetDataForm = function (formId) {
		var data = {};

		$('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (!columnDataName) return;
            if (this.type === "radio") {
                if (this.checked)
                    data[columnDataName] = this.value;
            } else {
                data[columnDataName] = this.value;
            }
        });

		return data;
	}

	/**
	 * /Metodo que verifica que todos los campos de un formulario esten llenos
	 * Si no es el caso, añade la clase red-border, para marcar el input en rojo
	 * Se retorna un bool en verdadero si hay error y en falso si todos los campos estan llenos
	 * @param {any} formId
	 */
	this.ValidateDataForm = function (formId) {
		var error = false;
		$('#' + formId + ' *').filter(':input').each(function (input) {
			var inputValue = this.value;

			if (inputValue === "") {
				$(this).addClass("red-border");
				error = true;
			}
			else {
				$(this).removeClass("red-border");
			}
		});
		return error;
	}

	/**
	 * /Metodo que limpia los campos de un form determinado
	 * Ademas, elimina la clase "red-border", la cual es asignada a inputs que fueron enviados vacios anterimormente
	 * @param {string} formId Id del form del cual se deben limpiar los campos
	 */
	this.CleanDataForm = function (formId) {

		$('#' + formId + ' *').filter(':input').each(function (input) {
			$(this).val("");
			$(this).removeClass("red-border");
		});

	}
	/**
	 * /Funcion que activa el contenedor con el mensaje de respuesta del servidor. Ya sea un error o el mensaje de aprobacion
	 * @param {char} type Tipo de mensaje a mostrar, ya sea E de error o I de informacion
	 * @param {string} message Mensaje proveniente del servidor
	 * Finalmente muestra el mensaje en pantalla ejecutando la funcion .show() sobre el contenedor
	 */
	this.ShowMessage = function (type, message) {
		if (type == 'E') {
			$("#alert_container").removeClass("alert alert-success alert-dismissable")
			$("#alert_container").addClass("alert alert-danger alert-dismissable");
			$("#alert_message").text(message);
		} else if (type == 'I') {
			$("#alert_container").removeClass("alert alert-danger alert-dismissable")
			$("#alert_container").addClass("alert alert-success alert-dismissable");
			$("#alert_message").text(message);
		}
		$('.alert').show();
	};

	/**
	 * /Funcion que ejecuta una accion HTTP POST mediante JQuery al API
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {object} data Objeto con los datos que se deben enviar al servidor
	 * @param {any} callback Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */

	this.PostToAPI = function (service, data, callback) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			callback();
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
	};

	/**
	 * /Funcion que ejecuta una accion HTTP PUT mediante JQuery al API
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {object} data Objeto con los datos que se deben enviar al servidor
	 * @param {any} callback Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */

	this.PutToAPI = function (service, data, callback) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			callback();
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
	};

	/**
	 * /Funcion que ejecuta una accion HTTP DELETE mediante JQuery al API
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {object} data Objeto con los datos que se deben enviar al servidor
	 * @param {any} callback Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */

	this.DeleteToAPI = function (service, data, callback) {
		var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			callback();
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
	};

	/**
	 * /Funcion que ejecuta una accion HTTP GET mediante JQuery al API
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {any} callbackFunction Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */
	this.GetToApi = function (service, callbackFunction) {
		var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            callbackFunction(response.Data);
		});
    }

    /**
	 * /Funcion que ejecuta una accion HTTP GET mediante JQuery al Server
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {any} callbackFunction Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */
    this.GetToServer = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlServerService(service), function (response) {
            callbackFunction(response);
        });
    }

	/**
	 * /Funcion que ejecuta una accion HTTP GET por ID mediante JQuery al API
	 * @param {string} service Nombre del controlador al que se debe hacer el request
	 * @param {string} route Nombre de la accion a la que se debe hacer el llamado
	 * @param {string} data Informacion que debe ser enviada para poder hacer el request
	 * @param {any} callbackFunction Funcion que se debe ejecutar al finalizar el envio de datos. Usualmente se utiliza para refrescar la informacion
	 * Finalmente muestra por pantalla en mensaje retornado por el servidor con la funcion ShowMessage()
	 */

	this.GetToApiId = function (service, route, data, callbackFunction) {
		var url = this.formatGetURL(service, route, data);

		var jqxhr = $.get(url, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
			callbackFunction(response.Data);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
	}

	/**
	 * /Funcion que permite dar formato a una URL. Se agregan los parametros que sean necesarios
	 * @param {any} service Nombre del controlador al que se debe llegar
	 * @param {any} route Nombre de la accion en el controlador a ejecutar
	 * @param {any} data Informacion que debe ser enviada al servidor
	 * Retorna la URL con el formato de parametro con los campos del objeto data
	 */
	this.formatGetURL = function (service, route, data) {
		//Add the simbol to start receiving parameters to the url
		var url = this.GetUrlApiService(service) + `/${route}?`;
		//Variable to store the loop position
		var index = 0;
		//Amount of attributes contained in the object received
		var objectSize = Object.keys(data).length;

		$.each(data, function (name, value) {

			url = url.concat(name + '=' + value);

			//We add the & simbol only if is not the last parameter
			if (index < objectSize - 1) {
				url = url.concat('&');
			}

			index++;
		});

		return url;

	}
}

//Funciones de JQuery utilizadas en casos particulares. Solo se deben utilizar si las funciones anteriores no cumples con el objetivo
//Custom jquery actions
$.put = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'PUT',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}

$.delete = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'DELETE',
		success: callback,
		data: JSON.stringify(data),
		contentType: 'application/json'
	});
}
