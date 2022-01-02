



/////////////////////////////

(function () {
    'use strict'
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    tooltipTriggerList.forEach(function (tooltipTriggerEl) {
        new bootstrap.Tooltip(tooltipTriggerEl)
    })
})();

///////

//http://www.nikolay.rocks/2015-10-29-rainbows-generator-in-javascript
function interpolateColors(steps) {
    var data = new Array(steps);
    var frequency = 2 * Math.PI / steps;
    var redFrequency = frequency; //1.666;
    var grnFrequency = frequency; //2.666;
    var bluFrequency = frequency; //3.666;
    var phase1 = 0; //0
    var phase2 = 2; //2
    var phase3 = 4; //4
    var center = 128;
    var width = 127;
    for (var i = 0; i < steps; ++i) {
        var r = Math.sin(redFrequency * i + phase1) * width + center;
        var g = Math.sin(grnFrequency * i + phase2) * width + center;
        var b = Math.sin(bluFrequency * i + phase3) * width + center;
        r /= 255.0, g /= 255.0, b /= 255.0;
        var max = Math.max(r, g, b), min = Math.min(r, g, b);
        var h, s, l = (max + min) / 2.0;
        if (max == min) {
            h = s = 0.0;
        } else {
            var d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            switch (max) {
                case r: h = (g - b) / d + (g < b ? 6.0 : 0.0); break;
                case g: h = (b - r) / d + 2; break;
                case b: h = (r - g) / d + 4; break;
            }
            h /= 6.0;
        }
        data[i] = 'hsl(' + ((h * 100 + 0.5) | 0) + ',' + ((s * 100 + 0.5) | 0) + '%,' + ((l * 100 + 0.5) | 0) + '%)';
    }
    return data;
}


//////////////////////////////


function dataTables(table) {
    var table = $(table).DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                autoFilter: true,
                sheetName: 'Ventas'
            },
            {
                extend: 'pdfHtml5',
                orientation: 'landscape',
                pageSize: 'LEGAL'
            },
            'print',
            'colvis'
        ],
        lengthChange: false,
        scrollX: true,
        searchable: false,
        info: false,
        language: {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            oAria: {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });
    table.buttons().container().appendTo('#btn-toolbar .col-md-6:eq(0)');
}

//////////////////////////////////

function details(controller, id) {
    $('#detailsModal').modal('show');
    $.ajax("/" + controller + "/Details/" + id)
        .done(function (data) {
            $("#detallesModalContent").html(data);
        });
}






$(document).ready(function () {


  
    $.ajax({
        type: "POST",
        url: location.origin + "/Citas/ListarCitas",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        async: false,
        failure: function (response) {
           
        },
        error: function (response) {
            
        }
    });

    
    
});

var exampleModal = document.getElementById('exampleModal')
exampleModal.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    // Extract info from data-bs-* attributes
    var recipient = button.getAttribute('data-bs-whatever')
    // If necessary, you could initiate an AJAX request here
    // and then do the updating in a callback.
    //
    // Update the modal's content.
    var modalTitle = exampleModal.querySelector('.modal-title')
    var modalBodyInput = exampleModal.querySelector('.modal-body input')

    //modalTitle.textContent = 'New message to ' + recipient
    modalBodyInput.value = recipient
})

function listarCitas() {


    $.ajax({
        type: "POST",
        url: location.origin + "/Citas/ListarCitas",
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

    $('#citasTabla').DataTable().clear().destroy();
  
     
    $('#citasTabla').DataTable({
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
            { 'data': 'id' },
            { 'data': 'nombrePaciente' },
            { 'data': 'estatusCita' },
            { 'data': 'areaAtencion' },
            { 'data': 'fecha'},
            {
                mRender: function (data, type, row) {
                    return '<a href="#' + row.id + '" class="btn btn-danger m-1" onclick="eliminar(this)">Cancelar</a><a data-bs-toggle="modal" data-bs-target="#exampleModal2" data-bs-whatever="mdo"  href="#' + row.id + '" class="btn btn-info m-1" onclick="detalleCita(this)">Detalle</a><a class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="mdo" onclick="editarCita(this)" href="#' + row.id + '">Editar</a >'
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

const eliminar = (idCitaElimiar) => {
    console.log(idCitaElimiar.data);
    alertify.confirm('Cancelar cita', 'A continuación cancelará esta cita, desea continuar?',
        function () {
            
             
                $.ajax({
                    url: location.origin + "/Citas/CancelarCita", // Url
                    data: {
                        id: idCitaElimiar.hash.replace('#', '')
                        // ...
                    },
                    async: false,
                    type: "post"  // Verbo HTTP
                })
                    // Se ejecuta si todo fue bien.
                    .done(function (result) {
                        if (result != null) {
                            alertify.success('La cita se canceló correctamente');
                            listarCitas();
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


const detalleCita = (cita) => {
    
    $.ajax({
        url: location.origin + "/Citas/Details", // Url
        data: {
            id: cita.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {
                document.querySelector("#tablaDetalleCita").innerHTML =
                    `<tbody >
                        <tr><td class="p-1">Identificador del paciente:</td><td class="p-2"><strong>${result.id}</strong></td></tr>
                        <tr><td class="p-1">Nombre del paciente:</td><td class="p-2"><strong>${result.nombrePaciente}</strong></td></tr>
                        <tr><td class="p-1">Fecha de la cita:</td><td class="p-2"><strong>${new Date(result.fecha).toLocaleString()}</strong></td></tr>
                        <tr><td class="p-1"> Estatus de cita:</td><td class="p-1"><strong>${result.estatusCita}</strong></td></tr>
                        <tr><td class="p-1">Área de atención:</td><td class="p-1"><strong>${result.areaAtencion}</strong></td></tr>
                    </tbody>`

                
                
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

const editarCita = (cita) => {

    let textValidacion = document.querySelector("#validacionFormularioEditarCita");
    textValidacion.innerHTML = '';
    $.ajax({
        type: "GET",
        url: location.origin + "/Citas/CatalogoEstatus",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: (response) => {
            $("#estatus").find('option').remove();

            $(response).each(function (i, v) {
                $("#estatus").append('<option value="' + v.idEstatus + '">' + v.nombre_Estatus + '</option>');
            })
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });

    $.ajax({
        type: "GET",
        url: location.origin + "/Citas/CatalogoAreas",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: (response) => {
            $("#areatencion").find('option').remove();

            $(response).each(function (i, v) {
                $("#areatencion").append('<option value="' + v.id_Area + '">' + v.nombre_Area + '</option>');
            })
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });

    $.ajax({
        url: location.origin + "/Citas/Details", // Url
        data: {
            id: cita.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {
                document.querySelector("#identificadorcita").value = result.id;
                document.querySelector("#nombrePaciente").value = result.nombrePaciente;
                document.querySelector("#observaciones").value = result.observaciones;
                document.querySelector("#fecha").value = result.fecha;

                $("#areatencion option:contains(" + result.areaAtencion + ")").attr('selected', true);
                $("#estatus option:contains(" + result.estatusCita + ")").attr('selected', true);
               
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




const enviarCitaEditada = function () {
    let datosCorrectos = true;
    let fecha = document.querySelector("#fecha");
    
    let observaciones = document.querySelector("#observaciones");
    let textValidacion = document.querySelector("#validacionFormularioEditarCita");
    textValidacion.innerHTML = '';
    if (observaciones.value == '') {
        textValidacion.innerHTML = "<li>El campo Observaciones es requerido</li>";
        datosCorrectos = false;
    }
    if (fecha.value == '') {
        textValidacion.innerHTML += "<li>El campo Fecha es requerido</li>";
        datosCorrectos = false;
    }

    let dataCita = {};

    
    dataCita.pacienteid = null;
    dataCita.idEstaus= document.querySelector("#estatus").value;
    dataCita.idArea= document.querySelector("#areatencion").value;
    dataCita.fecha= document.querySelector("#fecha").value;
    dataCita.observaciones= document.querySelector("#observaciones").value;

    if (datosCorrectos) {
        $.ajax({
            type: "POST",
            url: location.origin + "/Citas/EditarCita",
            data: { id: document.querySelector("#identificadorcita").value, dataCita },
            async: false,
            dataType: "json",
            success: () => {
                $('#exampleModal').modal('hide');
            },
            failure: function (response) {
                
            },
            error: function (response) {
                
            }
        });

        $('#exampleModal').modal('hide');
        listarCitas();
    }

}