const generarTablaCitas = () => {

	document.querySelector("#theadCitasTabla").innerHTML = `<tr>
                    <th style = "width:10%" > Nombre paciente</th >
                        <th style="width:10%">Estatus cita</th>
                        <th style="width:10%">Área de atención</th>
                        <th style="width:10%">Hora y fecha cita</th>

                        <th style="width:50%">Acciones</th>
                    </tr > `;

	$('#citasTabla').DataTable({
		"ordering": true,
		"searching": true,
		"pageLength": 10,
		"processing": true,
		deferRender: true,
		scrollY: 500,
		"autoWidth": false,
		scrollCollapse: true,
		scroller: true,
		async: false,
		"serverSide": true,
		"filter": true,
		"ajax": {
			"url": "/Citas/ListarCitas",
			"type": "POST",
			"datatype": "json", error: function (jqXHR, ajaxOptions, thrownError) {
				window.location.href = "/Citas/Error"
			}
		},
		columns: [

			{ 'data': 'nombrePaciente' },
			{ 'data': 'estatusCita' },
			{ 'data': 'areaAtencion' },
			{ 'data': 'fecha' },
			{
				mRender: function (data, type, row) {
					return '<a href="#' + row.id + '" class="btn btn-danger btn-sm m-1" onclick="eliminar(this)"><i class="material-icons" style="font-size: 20px">&#xe888;</i></a><a data-bs-toggle="modal" data-bs-target="#modalCita" data-bs-whatever="mdo"  href="#' + row.id + '" class="btn btn-info m-1 btn-sm" onclick="detalleCita(this)"><i class="material-icons" style="font-size: 20px">&#xe873;</i></a><a class="btn btn-primary m-1 btn-sm" data-bs-toggle="modal" data-bs-target="#modalCita" data-bs-whatever="mdo" onclick="editarCita(this)" href="#' + row.id + '"><i style="font-size: 20px" class="fas">&#xf044;</i></a >'
				}
			}
		],
		dom: 'Bfrtip',
		buttons: [
			{

				text: '<i class="fas fa-file-pdf"></i> Generar reporte',
				className: 'btn btn- primary',
				action: function (e, dt, node, config) {

					window.open('/Citas/GenerarReporte', '_blank');
				}

			},
			{

				text: '<i class="fas fa-user-plus"></i> Crear nueva cita',
				titleAttr: 'generarReporte',
				className: 'btn-import',
				action: function (e, dt, node, config) {

					window.open('/Citas/CrearCita','_self');
				}

			}

		],
		"language": {
			"url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json",
		}
	});


}

const eliminar = (idCitaElimiar) => {

	alertify.confirm('Cancelar cita', 'A continuación cancelará esta cita, desea continuar?',
		() => {
			let data = {
				id: idCitaElimiar.hash.replace('#', '')
			};
			consumirMetodoAccion("/Citas/CancelarCita", false, 'delete', data, (result) => {
				if (result != null) {
					alertify.success('La cita se canceló correctamente');
					$('#citasTabla').DataTable().ajax.reload();
				}
			}, () => { alertify.error('Algo salio mal, favor de contactar con el administrador'); });
		}, () => { alertify.error('No se canceló la cita') }

	).set('labels', { ok: 'Sí', cancel: 'No' });
}

const detalleCita = (cita) => {

	consumirMetodoAccion("/Citas/DetalleCita", false, "post", { id: cita.hash.replace('#', '') }, (result) => {

		if (result != null) {
			document.querySelector("#modalTitleCita").innerHTML = "Detalle - Cita";
			document.querySelector("#modalBodyCita").innerHTML = result;

		}

	}, error);

}

const editarCita = (cita) => {

	consumirMetodoAccion("/Citas/DetalleCitaEditar", false, "POST", {
		id: cita.hash.replace('#', '')

	}, (result) => {
		if (result != null) {

			document.querySelector("#modalBodyCita").innerHTML = result;
			document.querySelector("#modalTitleCita").innerHTML = "Editar - Cita";


		}
	});


}

function enviarCitaEditada(result) {
	if (result.status == 204) {
		$("#modalCita").modal("hide");
		$('#citasTabla').DataTable().ajax.reload();
		alertify.success('La cita se edito correctamente');
	}

}

function error(result) {
	if (result.status == 500) {
		window.location.href = "/Citas/Error"
	}	
}

generarTablaCitas();