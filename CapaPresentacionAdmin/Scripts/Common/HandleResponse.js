const HandleResponse = {
    Form: (response, Request) => {
        $(".modal-body").LoadingOverlay("hide");
        if (response.mensaje == '') {
            if (response.Id > 0) {
                FilaTableUpdate(Request, response.Id)
            } else {
                FilaTableCreate(Request)
            }            
            $("#FormModal").modal("hide");
        }
        else {
            $("#mensajeError").text(response.mensaje);
            $("#mensajeError").show();
        }
    },
    FilaTableCreate: (Request) => {
        tabladata.row.add(Request).draw(false);
    },
    FilaTableUpdate: (Request, Id) => {
        var fila = $('#fila-' + Id)
        var filaSeleccionada = $(fila).closest("tr");
        tabladata.row(filaSeleccionada).data(Request).draw(false);
        filaSeleccionada = null;
    }
}

export default HandleResponse;