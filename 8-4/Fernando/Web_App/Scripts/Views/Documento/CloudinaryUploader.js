$(function () {
    let imagenUrl = '';

    $.cloudinary.config({ cloud_name: 'grupo-bejuco', api_key: '983523113131392' });

    let btnSubir = $('#btnCreateDocument');
    let btnActualizar = $('#btnEditDocument');

    btnSubir.on('click', function (e) {

        cloudinary.openUploadWidget({ cloud_name: 'grupo-bejuco', upload_preset: 'grupo-bejuco', tags: ['document'] },
            function (error, result) {
                if (error) console.log(error);

                let id = result[0].public_id;
                imagenUrl = 'https://res.cloudinary.com/grupo-bejuco/image/upload/' + id;
                console.log(imagenUrl);
                $('#txtCreateURL').val(imagenUrl);
            });
    });

    btnActualizar.on('click', function (e) {

        cloudinary.openUploadWidget({ cloud_name: 'grupo-bejuco', upload_preset: 'grupo-bejuco', tags: ['document'] },
            function (error, result) {
                if (error) console.log(error);

                let id = result[0].public_id;
                imagenUrl = 'https://res.cloudinary.com/grupo-bejuco/image/upload/' + id;
                console.log(imagenUrl);
                $('#txtEditURL').val(imagenUrl);
            });
    });
})