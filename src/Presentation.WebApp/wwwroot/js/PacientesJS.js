
$('#tablaPacientesListar').DataTable({
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


$('#tablaPacientesBorrar').DataTable({
    "ordering": true,
    "searching": true,
    "lengthChange": true,
    "pageLenght": 10,
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


const eliminarPaciente = (paciente) => {
    console.log(paciente.hash.replace('#', ''));
    alertify.confirm('Cancelar cita', 'A continuación se eliminará este paciente, desea continuar?',
        function () {


            $.ajax({
                url: location.origin + "/Pacientes/Delete", // Url
                data: {
                    id: paciente.hash.replace('#', '')
                    // ...
                },
                async: false,
                type: "post"  // Verbo HTTP
            })
                // Se ejecuta si todo fue bien.
                .done(function (result) {
                    if (result != null) {
                        alertify.success('El paciente se eliminó correctamente');
                        listarPacientes();
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


const detallePaciente = (paciente) => {
    
    console.log(paciente.hash.replace('#', ''));
    $.ajax({
        type: "post",
        url: location.origin + "/Pacientes/Details",
        data: {
            id: paciente.hash.replace('#', '')

        },
        dataType: "json",
        async: false,
        success: (response) => {
            console.log(response.nombre);

            document.querySelector("#fotoPaciente").src = response.fotografia;

            document.querySelector("#datosPaciente").innerHTML =
                `<tbody>
                    <tr>
                        <td>Nombre: ${response.nombre}</td>
                    </tr>
                    <tr>
                        <td>Edad: ${response.edad}</td>
                    </tr>
                    <tr>
                        <td>Número de celular: ${response.telefonoM}</td>
                    </tr>
                    <tr>
                        <td>Curp: ${response.curp}</td>
                    </tr>
                    <tr>
                        <td>Correo: ${response.correo}</td>
                    </tr>
                     <tr>
                        <td>Sexo: ${response.sexo}</td>
                    </tr>
                    <tr>
                        <td>Profesión: ${response.nombreProfesion}</td>
                    </tr>
                    <tr>
                        <td>Tipo de sangre: ${response.tipoSangreN}</td>
                    </tr>
                    <tr>
                        <td>Estado civil: ${response.estadoCivilN}</td>
                    </tr>

                </tbody>`;

            $('#modalDetalle').modal('show')
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}

function listarPacientes() {


    $.ajax({
        type: "POST",
        url: location.origin + "/Pacientes/ListarPacientes",
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

    $('#tablaPacientesBorrar').DataTable().clear().destroy();


    $('#tablaPacientesBorrar').DataTable({
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

        data: response,
        columns: [
            
            { 'data': 'nombre' },
            { 'data': 'correo' },
            { 'data': 'edad' },
            { 'data': 'expediente' },
            { 'data': 'telefonoM' },
            { 'data': 'expediente' },
            {
                mRender: function (data, type, row) {
                    return '<a class="btn btn-danger" onclick="eliminarPaciente(this)" href="#' + row.id + '"> Borrar</a><a href="Edit/' + row.id + '" class="btn btn-primary m-1">Editar</a>'
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