function PayPalService() {

    this.pagoMembresiaEstandar = function (vMembresia, costo) {
        var contenedoresEstandar = ['#btnPayPalEstandar', '#btnPayPalAmpliarEstandar'];

        contenedoresEstandar.forEach(function (contenedor, index) {
            paypal.Button.render({
                // Configuración de los keys de prueba y de producción de Paypal
                env: 'sandbox',
                client: {
                    sandbox: 'AdBR9YXW-9rlG2EIviB4k8Z3atEXd_XWB5kZwOi5-BHgoOKnwH0vUoXgU3gB-rOi7ZGqFkJ0paE7fhQz',
                    production: 'EPwPXKi-sRlD7JtUkJovsKsw9PaNSS3OscyhVFmB7jKzlO6XRh61xr5-OzsIMcWaoaTsshLz4EW8onR7'
                },
                // Customización del botón mostrado
                style: {
                    size: 'medium',
                    shape: 'rect',
                    color: 'blue',
                    layout: 'horizontal',
                    label: 'pay',
                },
                // Habilitar la posibilidad del pago instantaneo (esto es opcional)
                commit: true,

                // Configuración del pago
                payment: function (data, actions) {
                    return actions.payment.create({
                        transactions: [{
                            amount: {
                                total: costo,
                                currency: 'USD'
                            }
                        }]
                    });
                },
                // Ejecutar el pago
                onAuthorize: function (data, actions) {
                    return actions.payment.execute().then(function () {
                        // Mostrar mensaje de confirmacion!
                        vMembresia.UpdateEstandar();
                    });
                }
            }, contenedor);
        });
        
    }
}
