function Login() {

    this.service = 'Usuario';
    this.createFormId = "change-pass-form";
    this.ctrlActions = new ControlActions();

    this.Login = function () {
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;

        this.ctrlActions.GetToApi("Usuario/IniciarSesion?email=" + email + "&contrasenna=" + password,
            function(response) {
                sessionStorage.setItem("Id", response[0].Identificacion);
                var roles = [];
                for (var i = 1; i < response.length; i++) {
                    roles.push(response[i].Nombre);
                }
                sessionStorage.setItem("Roles", JSON.stringify(roles));
                if (response[0].Estado == "CAMBCONTRA") {
                    $('#change-pass').modal('toggle');
                }
            });
    }

    this.CleanUpdate = function () {
        this.ctrlActions.CleanDataForm(this.createFormId);
    }

    this.ChangePass = function() {
        if (!this.ctrlActions.ValidateDataForm(this.createFormId)) {
            var contrasenna = $("#contrasenna");
            var repetirContrasenna = $("#repetir-contrasenna");
            if (contrasenna.val() == repetirContrasenna.val()) {
                contrasenna.removeClass("red-border");
                repetirContrasenna.removeClass("red-border");
                var contrasenna = {};
                contrasenna = this.ctrlActions.GetDataForm(this.createFormId);
                contrasenna.IdUsuario = sessionStorage.getItem("Id");

                this.ctrlActions.PostToAPI("Contrasenna", contrasenna, "",
                    function (response) {
                        alert("Cambiada");
                        window.redirect("/");
                    });
            } else {
                contrasenna.addClass("red-border");
                repetirContrasenna.addClass("red-border");
            }
        }
    }

    this.ForgetPass = function () {
        var email = document.getElementById("email-forgot").value;
        var usuario = {};
        usuario.email = email;

        this.ctrlActions.PostToAPI("Usuario/RecuperarClave", usuario, "",
            function (response) {
                console.log(response);
            });
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var login = new Login();
    document.getElementById("login").addEventListener("click",login.Login);
});

