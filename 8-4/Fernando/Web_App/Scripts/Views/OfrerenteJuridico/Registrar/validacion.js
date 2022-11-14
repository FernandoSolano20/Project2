var regexText = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+(\s*[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*)*[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$/;
var regexCedula = /^\d{9}$/;
var regexCedulaJuridica = /^\d{10}$/;
var regexResidente = /^\d{14}$/;
var regexTextNumber = /^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]+(\s*[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]*)*[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ,.()\s]+$/;
var regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
var regexPassport = /^[A-Z0-9<]{9}[0-9]{1}[A-Z]{3}[0-9]{7}[A-Z]{1}[0-9]{7}[A-Z0-9<]{14}[0-9]{2}$/;

(function () {
    // Before using it we must add the parse and format functions
    // Here is a sample implementation using moment.js

    validate.extend(validate.validators.datetime, {
        // The value is guaranteed not to be null or undefined but otherwise it
        // could be anything.
        parse: function (value, options) {
            return +moment.utc(value);
        },
        // Input is a unix timestamp
        format: function (value, options) {
            var format = options.dateOnly ? "YYYY-MM-DD" : "YYYY-MM-DD hh:mm:ss";
            return moment.utc(value).format(format);
        }
    });
    //validate.validators.length.wrongLength = "%{count}";
    //validate.validators.length.tooLong = "sadadaw %{count}"
    //validate.validators.length.tooShort = "ddsd %{count}"
    // These are the constraints used to validate the form
    function createConstraints() {
        var isFormEmpresa = !!document.getElementById("cedula-juridica");
        var constraints = {
            id: {
                presence: !!document.querySelector("input#id[name='id']"),
            },
            idcedula: {
                presence: !!document.querySelector("input#id[name='idcedula']"),
                format: {
                    pattern: regexCedula
                },
                length: {
                    is: 9
                }
            },
            idpasaporte: {
                presence: !!document.querySelector("input#id[name='idpasaporte']"),
                length: {
                    is: 44
                },
                format: {
                    pattern: regexPassport
                }
            },
            idresidente: {
                presence: !!document.querySelector("input#id[name='idresidente']"),
                length: {
                    is: 14
                },
                format: {
                    pattern: regexResidente
                }
            },
            nombre: {
                presence: true,
                format: {
                    pattern: regexText
                },
                length: {
                    maximum:100,
                    minimum: 3
                }
            },
            primerApellido: {
                presence: true,
                format: {
                    pattern: regexText
                },
                length: {
                    maximum: 100,
                    minimum: 3
                }
            },
            segundoApellido: {
                presence: false,
                format: {
                    pattern: regexText
                },
                length: {
                    maximum: 100,
                    minimum: 3
                }
            },
            drpProvincia: {
                presence: true
            },
            drpCanton: {
                presence: true
            },
            drpDistrito: {
                presence: true
            },
            drpDistrito: {
                presence: true
            },
            direccion: {
                presence: true,
                length: {
                    maximum: 100
                }
            },
            drpPais: {
                presence: true
            },
            fechaNacimiento: {
                presence: true
            },
            telefono: {
                presence: true,
                format: /^((?!#).)*$/
            },
            email: {
                presence: true,
                format: regexEmail,
                length: {
                    maximum: 150
                }
            },
            drpGenero: {
                presence: true,
            },
            drpMoneda: {
                presence: true,
            },
            drpLenguaje: {
                presence: true,
            },
            cedulaJuridica: {
                presence: true,
                format: {
                    pattern: regexCedulaJuridica
                },
                length: {
                    is: 10
                }
            },
            razonSocial: {
                presence: true,
                length: {
                    maximum: 100
                }
            },
            nombreComercial: {
                presence: true,
                length: {
                    maximum: 50
                }
            },
            drpProvinciaEmpresa: {
                presence: true,
            },
            drpCantonEmpresa: {
                presence: true,
            },
            drpDistritoEmpresa: {
                presence: true,
            },
            direccionEmpresa: {
                presence: true,
                length: {
                    maximum: 100
                }
            },
            fechaCreacion: {
                presence: true,
            },
            drpMembresia: {
                presence: true,
            }
        };
        return constraints;
    }


    // Hook up the form so we can prevent it from being posted
    var form = document.querySelector("form#form-oferete-juridico");
    form.addEventListener("submit", function (ev) {
        ev.preventDefault();
        handleFormSubmit(form);
    });

    // Hook up the inputs to validate on the fly
    var inputs = document.querySelectorAll("input, textarea, select")
    for (var i = 0; i < inputs.length; ++i) {
        inputs.item(i).addEventListener("change", function (ev) {
            var errors = validate(form, createConstraints()) || {};
            showErrorsForInput(this, errors[this.name]);
        });
    }

    function handleFormSubmit(form, input) {
        // validate the form against the constraints
        var errors = validate(form, createConstraints());
        // then we update the form to reflect the results
        showErrors(form, errors || {});
        if (!errors) {
            showSuccess();
        }
    }

    // Updates the inputs with the validation errors
    function showErrors(form, errors) {
        // We loop through all the inputs and show the errors for that input
        _.each(form.querySelectorAll("input[name], select[name]"), function (input) {
            // Since the errors can be null if no errors were found we need to handle
            // that
            showErrorsForInput(input, errors && errors[input.name]);
        });
    }

    // Shows the errors for a specific input
    function showErrorsForInput(input, errors) {
        // This is the root of the input
        var formGroup = closestParent(input.parentNode, "form-group")
            // Find where the error messages will be insert into
            , messages = formGroup.querySelector(".messages");
        // First we remove any old messages and resets the classes
        resetFormGroup(formGroup);
        // If we have errors
        if (errors) {
            // we first mark the group has having errors
            formGroup.classList.add("has-error");
            // then we append all the errors
            _.each(errors, function (error) {
                addError(messages, error);
            });
        } else {
            // otherwise we simply mark it as success
            formGroup.classList.add("has-success");
        }
    }

    // Recusively finds the closest parent that has the specified class
    function closestParent(child, className) {
        if (!child || child == document) {
            return null;
        }
        if (child.classList.contains(className)) {
            return child;
        } else {
            return closestParent(child.parentNode, className);
        }
    }

    function resetFormGroup(formGroup) {
        // Remove the success and error classes
        formGroup.classList.remove("has-error");
        formGroup.classList.remove("has-success");
        // and remove any old messages
        _.each(formGroup.querySelectorAll(".help-block.error"), function (el) {
            el.parentNode.removeChild(el);
        });
    }

    // Adds the specified error with the following markup
    // <p class="help-block error">[message]</p>
    function addError(messages, error) {
        var block = document.createElement("p");
        block.classList.add("help-block");
        block.classList.add("error");
        block.classList.add("text-danger");
        block.innerText = error.capitalize();
        messages.appendChild(block);
    }

    function showSuccess() {
        // We made it \:D/
        alert("Success!");
        var registrar = new RegistrarOferenteJuridico();
        registrar.Create();
    }
})();