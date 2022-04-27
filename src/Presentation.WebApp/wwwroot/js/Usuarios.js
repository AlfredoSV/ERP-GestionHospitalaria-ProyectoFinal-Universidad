$('#tablaUsuariosListar').DataTable({
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
                columns: [0, 1, 2, 3]
            }
        },
        {
            extend: 'excelHtml5',
            text: '<i class="fas fa-table"></i> Excel',
            titleAttr: 'Excel',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 3]
            }
        },
        {
            extend: 'csvHtml5',
            text: '<i class="fas fa-file-csv"></i> CVS',
            titleAttr: 'CSV',
            className: 'btn-import', exportOptions: {
                columns: [0, 1, 2, 3]
            }
        },
        {
            extend: 'pdfHtml5',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            titleAttr: 'PDF',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 3]
            }

        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Imprimir',
            titleAttr: 'print',
            className: 'btn-import',
            exportOptions: {
                columns: [0, 1, 2, 3]
            }

        }

    ],
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json"
    }
});




const asignarRol = (usuario) => {


    document.querySelector("#usuario").value = usuario.hash.replace('#', '').split("-")[0];

    document.querySelector("#rolActual").value = usuario.hash.replace('#', '').split("-")[1].replace("%20", " ");


    $('#modalRol').modal('show')

}

const actualizarRol = () => {

    

    $.ajax({
        url: location.origin + "/Usuarios/ActualizarRol",
        data: {
            rol: document.querySelector("#nuevoRol").value

        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            $('#modalRol').modal('hide');
            alertify.success('El rol se actualizó correctamente');
            setTimeout(function () { window.location.reload(); }, 2000);

        })
        // Se ejecuta si se produjo un error.
        .fail(function (xhr, status, error) {
            $('#modalRol').modal('hide');
            alertify.error('El rol se no actualizó correctamente');
        })
        // Hacer algo siempre, haya sido exitosa o no.
        .always(function () {

        });


}
