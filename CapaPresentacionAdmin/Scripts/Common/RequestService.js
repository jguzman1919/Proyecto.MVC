const RequestService = {
    Make: (Request, Url, Method, Type = "post") => {
        jQuery.ajax({
            url: Url,
            type: Type,
            data: JSON.stringify(Request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                Method(response, Request);
            },
            error: function (error) {
                $(".modal-body").LoadingOverlay("hide");
                $("#mensajeError").text("Error ajax");
                $("#mensajeError").show();
            },
            beforeSend: function () {
                $(".modal-body").LoadingOverlay("show", {
                    imageResizefactor: 2,
                    text: "Cargando...",
                    size: 14
                })
            }
        });
    }
}

export default RequestService;