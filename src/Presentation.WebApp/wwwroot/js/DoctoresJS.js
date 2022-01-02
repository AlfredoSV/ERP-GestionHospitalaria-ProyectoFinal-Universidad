
$('#tablaDoctoresListar').DataTable({
    "ordering": true,
    "searching": true,
    "lengthChange": true,
    "pageLength": 10,
    processing: true,

    deferRender: true,
    scrollY: 500,
    scrollCollapse: true,
    scroller: true,
    async: false,
    dom: 'Bfrtip',
    buttons: [
        {
            extend: 'copyHtml5',
            text: '<i class="far fa-copy"></i> Copiar',
            titleAttr: 'Copy',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'excelHtml5',
            text: '<i class="fas fa-table"></i> Excel',
            titleAttr: 'Excel',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'csvHtml5',
            text: '<i class="fas fa-file-csv"></i> CVS',
            titleAttr: 'CSV',
            className: 'btn-import', exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            titleAttr: 'PDF',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }

        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Imprimir',
            titleAttr: 'print',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }

        }

    ],
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
    }
});

const detalleDoctor = (doctor) => {
    $.ajax({
        url: location.origin + "/Doctores/Details", // Url
        data: {
            id: doctor.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {
                document.querySelector("#fotoDoctor").src = result.foto;
                document.querySelector("#datosDoctor").innerHTML =
                    `<tbody >
                        <tr><td class="p-1">Identificador del paciente:</td><td class="p-2"><strong>${result.id}</strong></td></tr>
                        <tr><td class="p-1">Nombre del doctor:</td><td class="p-2"><strong>${result.nombre} ${result.apellidop}</strong></td></tr>
                        <tr><td class="p-1">Especialidad:</td><td class="p-2"><strong>${result.especialidad}</strong></td></tr>
                        <tr><td class="p-1">Correo:</td><td class="p-1"><strong>${result.correo}</strong></td></tr>
                        <tr><td class="p-1">Edad:</td><td class="p-1"><strong>${result.edad}</strong></td></tr>
                    </tbody>`

                $('#modalDetalleDoctor').modal('show')


            }
            else {
            }
        })
        // Se ejecuta si se produjo un error.
        .fail(function (xhr, status, error) {

        })
        // Hacer algo siempre, haya sido exitosa o no.
        .always(function () {

        });
}


$('#tablaDoctoresBorrar').DataTable({
    "ordering": true,
    "searching": true,
    "lengthChange": true,
    "pageLength": 10,
    processing: true,

    deferRender: true,
    scrollY: 500,
    scrollCollapse: true,
    scroller: true,
    async: false,
    dom: 'Bfrtip',
    buttons: [
        {
            extend: 'copyHtml5',
            text: '<i class="far fa-copy"></i> Copiar',
            titleAttr: 'Copy',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'excelHtml5',
            text: '<i class="fas fa-table"></i> Excel',
            titleAttr: 'Excel',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'csvHtml5',
            text: '<i class="fas fa-file-csv"></i> CVS',
            titleAttr: 'CSV',
            className: 'btn-import', exportOptions: {
                columns: [0, 1, 2, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            titleAttr: 'PDF',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }

        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Imprimir',
            titleAttr: 'print',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 4]
            }

        }

    ],
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
    }
});

const eliminarDoctor=(doctor) => {
    
    alertify.confirm('Cancelar cita', 'A continuación se eliminará a este doctor, desea continuar?',
        function () {


            $.ajax({
                url: location.origin + "/Doctores/Delete", // Url
                data: {
                    id: doctor.hash.replace('#', '')
                    // ...
                },
                async: false,
                type: "post"  // Verbo HTTP
            })
                // Se ejecuta si todo fue bien.
                .done(function (result) {
                    if (result != null) {
                        alertify.success('El doctor se eliminó correctamente correctamente');
                        listarDoctores();
                    }
                    else {
                    }
                })
                // Se ejecuta si se produjo un error.
                .fail(function (xhr, status, error) {

                })
                // Hacer algo siempre, haya sido exitosa o no.
                .always(function () {

                });


        }
        , function () {
            /*alertify.error('Cancel') */
        }
    ).set('labels', { ok: 'Sí', cancel: 'No' });
}

const editarDoctor=(doctor) => {
    $.ajax({
        url: location.origin + "/Doctores/Details", // Url
        data: {
            id: doctor.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {

                //alert(result.id);
                document.querySelector("#fotoDoctor").src = result.foto;
                document.querySelector("#identificadordoctor").value = result.id;
                document.querySelector("#nombreDoctor").value = result.nombre;
              
                document.querySelector("#edadDoctor").value = result.edad;
                document.querySelector("#apellidoPDoctor").value = result.apellidop;
                document.querySelector("#apellidoMDoctor").value = result.apellidoM;
                document.querySelector("#correoDoctor").value = result.correo;
                document.querySelector("#telm").value = result.telefono;
                $("#areatencion option[value='" + result.idArea + "']").attr("selected", true);
                $("#estadoCivil option[value='" + result.idEstadoCivil + "']").attr("selected", true);



                $("#especialidad option:contains(" + result.especialidad + ")").attr('selected', true);

                /*
                document.querySelector("#cantidadProducto").value = result.cantidad;
                document.querySelector("#precioProducto").value = result.precio;
                let divError = document.querySelector("#validacionFormularioEditarProducto");
                divError.innerHTML = '';*/



                $('#editarDoctor').modal('show')
            }
            else {
            }
        })
        // Se ejecuta si se produjo un error.
        .fail(function (xhr, status, error) {

        })
        // Hacer algo siempre, haya sido exitosa o no.
        .always(function () {

        });


}

const enviarDoctorEditado=() => {


    let identificador = document.querySelector("#identificadordoctor").value;
    let nombre = document.querySelector("#nombreDoctor").value;

    let edad = document.querySelector("#edadDoctor").value;
    let apellidoP = document.querySelector("#apellidoPDoctor").value;
    let apellidoM = document.querySelector("#apellidoMDoctor").value;
    let correo = document.querySelector("#correoDoctor").value;
    let telMovil = document.querySelector("#telm").value;

    let areatencion = document.querySelector("#areatencion").value;
    let estadoCivil = document.querySelector("#estadoCivil").value;
    let especialidad = document.querySelector("#especialidad").value;

    let seValido = true;

    let divError = document.querySelector("#validacionFormularioEditarDoctor");
    divError.innerHTML = '';
    if (nombre.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo nombre nombre es requerido</li>";
    }
    if (edad.value < 0 || edad > 100 || edad.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo edad no se encuentra dentro del rango requerido</li>";
    }
    if (apellidoP.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo apellido paterno es requerido</li>";
    }
    if (apellidoM.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo apellido materno es requerido</li>";
    }

    if (correo.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo correo es requerido</li>";
    }
    if (telMovil.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo telefono móvil es requerido</li>";
    }


    if (seValido) {
        var fileInput = document.getElementById('nuevaFotografiaDoctor');

        var form = $('#formEditarDoctor')[0];


        var formData = new FormData(form);


        formData.append("foto", fileInput.files[0]);
        formData.append("id", identificador);
        formData.append("nombre", nombre);
        formData.append("apellidop", apellidoP);

        formData.append("apellidoM", apellidoM);
        formData.append("edad", edad);
        formData.append("direccion", "");
        formData.append("telefono", telMovil);
        formData.append("sexo", "");
        formData.append("correo", correo);
        formData.append("especialidad", especialidad);
        formData.append("idArea", areatencion);
        formData.append("idEstadoCivil", estadoCivil);

        $.ajax({
            type: "POST",
            url: location.origin + "/Doctores/Edit",
            data: formData,
            contentType: false,
            processData: false,
            success: () => {
                $('#editarDoctor').modal('hide');
                listarDoctores();
            },
            failure: function (response) {

            },
            error: function (response) {

            }
        });
    }







    
}


function listarDoctores() {


    $.ajax({
        type: "POST",
        url: location.origin + "/Doctores/ListarDoctores",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });

}

function OnSuccess(response) {

    $('#tablaDoctoresBorrar').DataTable().clear().destroy();


    $('#tablaDoctoresBorrar').DataTable({
        "ordering": true,
        "searching": true,
        "lengthChange": true,

        "pageLength": 10,
        processing: true,

        deferRender: true,
        scrollY: 500,
        scrollCollapse: true,
        scroller: true,
        async: true,

        data: response,
        columns: [
            
            { 'data': 'nombre' },
            { 'data': 'especialidad' },
            { 'data': 'telefono' },
            { 'data': 'nombre_Area' },
            { 'data': 'correo' },

            {
                mRender: function (data, type, row) {
                    return '<a href="#' + row.id + '" class="btn btn-danger m-1" onclick="eliminarDoctor(this)">Eliminar</a><a class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="mdo" onclick="editarDoctor(this)" href="#' + row.id + '">Editar</a >'
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'copyHtml5',
                text: '<i class="far fa-copy"></i> Copiar',
                titleAttr: 'Copy',
                className: 'btn-import',
                exportOptions: {
                    columns: [0, 1, 2, 4]
                }
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-table"></i> Excel',
                titleAttr: 'Excel',
                className: 'btn-import',
                exportOptions: {
                    columns: [0, 1, 2, 4]
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fas fa-file-csv"></i> CVS',
                titleAttr: 'CSV',
                className: 'btn-import', exportOptions: {
                    columns: [0, 1, 2, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> PDF',
                titleAttr: 'PDF',
                className: 'btn-import',
                exportOptions: {
                    columns: [0, 1, 2, 4]
                }

            },
            {
                extend: 'print',
                text: '<i class="fas fa-print"></i> Imprimir',
                titleAttr: 'print',
                className: 'btn-import',
                exportOptions: {
                    columns: [0, 1, 2, 4]
                }

            }

        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
        }
    });




}
