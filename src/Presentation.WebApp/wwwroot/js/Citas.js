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
		scrollCollapse: true,
		scroller: true,
		async: false,
		"serverSide": true,
		"filter": true,
		"ajax": {
			"url": "/Citas/ListarCitas",
			"type": "POST",
			"datatype": "json"
		},
		columns: [

			{ 'data': 'nombrePaciente' },
			{ 'data': 'estatusCita' },
			{ 'data': 'areaAtencion' },
			{ 'data': 'fecha' },
			{
				mRender: function (data, type, row) {
					return '<a href="#' + row.id + '" class="btn btn-danger m-1" onclick="eliminar(this)"><i class="material-icons">&#xe888;</i></a><a data-bs-toggle="modal" data-bs-target="#modalCita" data-bs-whatever="mdo"  href="#' + row.id + '" class="btn btn-info m-1" onclick="detalleCita(this)"><i class="material-icons">&#xe873;</i></a><a class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#modalCita" data-bs-whatever="mdo" onclick="editarCita(this)" href="#' + row.id + '"><i style="font-size: 28px" class="fas">&#xf044;</i></a >'
				}
			}
		],
		dom: 'Bfrtip',
		buttons: [
			{

				text: '<i class="fas fa-file-pdf"></i> Generar reporte',
				titleAttr: 'generarReporte',
				className: 'btn-import',
				action: function (e, dt, node, config) {

					window.open('/Citas/GenerarReporte', '_blank');
				}

			}

		],
		"language": {
			"url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json",
		}
	});


}

generarTablaCitas();

const eliminar = (idCitaElimiar) => {

	alertify.confirm('Cancelar cita', 'A continuación cancelará esta cita, desea continuar?',
		() => {
			let data = {
				id: idCitaElimiar.hash.replace('#', '')
			};
			consumirMetodoAccion("/Citas/CancelarCita", false, 'post', data, (result) => {
				if (result != null) {
					alertify.success('La cita se canceló correctamente');
					$('#citasTabla').DataTable().ajax.reload();
				}
			});
		}, () => { alertify.error('No se canceló la cita') }

	).set('labels', { ok: 'Sí', cancel: 'No' });
}


const detalleCita = (cita) => {

	consumirMetodoAccion("/Citas/DetalleCita", false, "post", { id: cita.hash.replace('#', '') }, (result) => {

		if (result != null) {
			document.querySelector("#modalTitleCita").innerHTML = "Detalle - Cita";
			document.querySelector("#modalBodyCita").innerHTML = result;

		}

	});

}

const editarCita = (cita) => {

	let textValidacion = document.querySelector("#validacionFormularioEditarCita");
	//textValidacion.innerHTML = '';

	consumirMetodoAccion("/Citas/DetalleCitaEditar", false, "POST", {
		id: cita.hash.replace('#', '')

	}, (result) => {
		if (result != null) {

			document.querySelector("#modalBodyCita").innerHTML = result;
			document.querySelector("#modalTitleCita").innerHTML = "Editar - Cita";


		}
	});


}

const enviarCitaEditada = function () {

	let datosCorrectos = true;
	let fecha = document.querySelector("#Fecha");

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
	dataCita.idEstaus = document.querySelector("#estatus").value;
	dataCita.idArea = document.querySelector("#areatencion").value;
	dataCita.fecha = document.querySelector("#Fecha").value;
	dataCita.observaciones = document.querySelector("#observaciones").value;

	if (datosCorrectos) {

		let data = { id: document.querySelector("#Id").value, dataCita };

		consumirMetodoAccion("/Citas/EditarCita", false, 'post', data, () => {
			$('#modalCita').modal('hide');
			$('#citasTabla').DataTable().ajax.reload();
			alertify.success('La cita se edito correctamente');
		}, error);


		
	}

}

const error = () => {
	window.location.href = "/Citas/Error"
}