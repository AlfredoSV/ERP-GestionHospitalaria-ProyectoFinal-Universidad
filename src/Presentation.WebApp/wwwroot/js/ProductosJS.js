

$('#tablaProductosListar').DataTable({
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



$('#tablaProductosListarDetail').DataTable({
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



const eliminarProducto = (producto) => {
    console.log(producto.hash);
    alertify.confirm('Cancelar cita', 'A continuación se eliminará este producto, desea continuar?',
        function () {


            $.ajax({
                url: location.origin + "/Productos/Delete", // Url
                data: {
                    id: producto.hash.replace('#', '')
                    // ...
                },
                async: false,
                type: "post"  // Verbo HTTP
            })
                // Se ejecuta si todo fue bien.
                .done(function (result) {
                    if (result != null) {
                        alertify.success('El producto se eliminó correctamente');
                        listarProductos();
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



const detalleProducto = (producto) => {
    $.ajax({
        url: location.origin + "/Productos/Details", // Url
        data: {
            id: producto.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {

                document.querySelector("#fotoProducto").src = result.foto;
                document.querySelector("#datosProducto").innerHTML =
                    `<tbody >
                        <tr><td class="p-1">Identificador del producto:</td><td class="p-2"><strong>${result.id}</strong></td></tr>
                        <tr><td class="p-1">Nombre del producto:</td><td class="p-2"><strong>${result.nombre}</strong></td></tr>
                        <tr><td class="p-1">Descripcion del producto:</td><td class="p-2"><strong>${result.descripcion}</strong></td></tr>
                        <tr><td class="p-1">Tipo de producto:</td><td class="p-2"><strong>${result.nombreTipo}</strong></td></tr>
                        <tr><td class="p-1">Precio del producto:</td><td class="p-2"><strong>$${result.precio}</strong></td></tr>
                        <tr><td class="p-1">Cantidad del producto en almacen:</td><td class="p-2"><strong>${result.cantidad}</strong></td></tr>
                    </tbody>`

                $('#modalDetalleProducto').modal('show')

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

const editarProducto = (producto) => {

    $.ajax({
        url: location.origin + "/Productos/Details", // Url
        data: {
            id: producto.hash.replace('#', '')
            // ...
        },
        async: false,
        type: "post"  // Verbo HTTP
    })
        // Se ejecuta si todo fue bien.
        .done(function (result) {
            if (result != null) {

                //alert(result.id);
               
                document.querySelector("#identificadorproducto").value = result.id;
                document.querySelector("#nombreProducto").value = result.nombre;
                document.querySelector("#descripcionProducto").value = result.descripcion;
               
                $("#tipoProducto option[value='" + result.idTipoProducto + "']").attr("selected", true);
                document.querySelector("#cantidadProducto").value = result.cantidad;
                document.querySelector("#precioProducto").value = result.precio;
                let divError = document.querySelector("#validacionFormularioEditarProducto");
                divError.innerHTML = '';


                
                $('#modalEditarProducto').modal('show')
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


const enviarProductoEvitado = () => {

    console.log(document.querySelector("#identificadorproducto").value)
    console.log(document.querySelector("#nombreProducto").value)
    console.log(document.querySelector("#descripcionProducto").value)

    console.log(document.querySelector("#tipoProducto").value)
    console.log(document.querySelector("#cantidadProducto").value)


    console.log(document.querySelector("#precioProducto").value)
    console.log(document.querySelector("#nuevaFotografiaProducto").value)

    let seValido = true;
  
    let divError = document.querySelector("#validacionFormularioEditarProducto");
    divError.innerHTML = '';
    if (document.querySelector("#nombreProducto").value.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo nombre del producto es requerido</li>";
    }
    if (document.querySelector("#descripcionProducto").value.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo descripcion del producto es requerido</li>";
    }
    if (document.querySelector("#cantidadProducto").value.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo cantidad del producto es requerido</li>";
    }
    if (document.querySelector("#precioProducto").value.trim() == '') {
        seValido = false;
        divError.innerHTML += "<li>El campo precio del producto es requerido</li>";
    }

    if (seValido) {
        var fileInput = document.getElementById('nuevaFotografiaProducto');

        var form = $('#formEditarProducto')[0];


        var formData = new FormData(form);


        formData.append("foto", fileInput.files[0]);
        formData.append("id", document.querySelector("#identificadorproducto").value);
        formData.append("nombre", document.querySelector("#nombreProducto").value);
        formData.append("descripcion", document.querySelector("#descripcionProducto").value);

        formData.append("idTipoProducto", document.querySelector("#tipoProducto").value);
        formData.append("cantidad", document.querySelector("#cantidadProducto").value);
        formData.append("precio", document.querySelector("#precioProducto").value);


        $.ajax({
            type: "POST",
            url: location.origin + "/Productos/Edit",
            data: formData,
            contentType: false,
            processData: false,
            success: () => {
                $('#modalEditarProducto').modal('hide');
                listarProductos();
            },
            failure: function (response) {

            },
            error: function (response) {

            }
        });
    }
 
   




}


function listarProductos() {


    $.ajax({
        type: "POST",
        url: location.origin + "/Productos/ListarProductos",
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

    $('#tablaProductosListar').DataTable().clear().destroy();


    $('#tablaProductosListar').DataTable({
        "ordering": true,
        "searching": true,
        "lengthChange": true,
        "pageLenght": 10,
        processing: true,

        deferRender: true,
        scrollY: 500,
        scrollCollapse: true,
        scroller: true,
        async: true,

        data: response,
        columns: [
            { 'data': 'nombre' },
            { 'data': 'descripcion' },
            { 'data': 'nombreTipo' },
            { 'data': 'precio' },
            { 'data': 'cantidad' },           
            {
                mRender: function (data, type, row) {
                    return '<a href="#' + row.id + '" class="btn btn-danger m-1" onclick="eliminarProducto(this)">Eliminar</a><a class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="mdo" onclick="editarProducto(this)" href="#' + row.id + '">Editar</a >'
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

