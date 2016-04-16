function mostrarModal() { $('#modalBs').modal('show'); }

function alerta(result) {
    if (result.Mensaje == null && result.Transaccion == 1) {
        result.Mensaje = "Acción ejecutada satisfactoriamente";
    }
    if (result.Mensaje == null && result.Transaccion != 1) {
        result.Mensaje = "La transacción no se pudo completar, inténtelo nuevamente";
    }
    switch (result.Transaccion) {
        case 1: // Success
            swal("OK", result.Mensaje, "success");
            break;
        case 2: // Warning
            swal({
                title: "Advertencia",
                text: result.Mensaje,
                type: "warning",
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Aceptar",
                closeOnConfirm: true
                        });
            break;
        case 3:  // Errro        
            swal({
                title: "Error",
                text: result.Mensaje,
                type: "error",
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Aceptar",
                closeOnConfirm: true
            });
            break;
    }   
}

function notificacion(result) {
    var clase = '';
    if (result.Respuesta == "True") {
        result.Respuesta = true;
    }
    if (result.Respuesta == "False") {
        result.Respuesta = false;
    }
    switch (result.Respuesta) {
        case true:
            clase='growl-success';
            break;
        case false:
            clase = 'growl-danger';        
    }
    if (result.Mensaje == "") {
        result.Mensaje = "Acción ejecutada satisfactoriamente";
    }
    jQuery.gritter.add({
        title: "Notificación",
        text: result.Mensaje ,
        class_name: clase,
        image: '/Content/theme_chain/images/screen.png',//'images/screen.png',
        sticky: false,
        time: 2000
    });
}

$("#divNotificacion").hide();

var Utils = function () {
    "use strict"
    return {
        addGridDataItem: function (targetId, dataItem) {
            var grid = $(targetId).data("kendoGrid");
            grid.dataSource.add(dataItem);
        },
        removeGridDataItem: function (e, targetId) {
            e.preventDefault();
            var grid = $(targetId).data("kendoGrid");
            var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
            grid.dataSource.remove(dataItem);
        },
        getGridDataSource: function (targetId) {
            var grid = $(targetId).data("kendoGrid");
            var jsonData = jQuery.parseJSON(JSON.stringify(grid.dataSource.data()));
            return jsonData;
        },
        setGridDataSource: function (targetId, jsonData) {
            var grid = $(targetId).data("kendoGrid");
            grid.dataSource.data(jsonData);
        },        
        showModalBs: function (path, dataModalValue) {
            dataModalValue = typeof dataModalValue !== 'undefined' ? dataModalValue : ""; //default value

            modalBsContent.load(path, function (response, status, xhr) {
                switch (status) {
                    case "success":
                        modalBs.modal({ backdrop: 'static', keyboard: false }, 'show');

                        if (dataModalValue == "modal-lg") {
                            modalBs.find(".modal-dialog").addClass("modal-lg");
                        } else {
                            modalBs.find(".modal-dialog").removeClass("modal-lg");
                        }

                        onModalInit(); // Inicializa el popup
                        break;

                    case "error":
                        var message = "Error de ejecución: " + xhr.status + " " + xhr.statusText;
                        if (xhr.status == 403) $.msgbox(response, { type: 'error' });
                        else $.msgbox(message, { type: 'error' });
                        break;
                }
            });
        }
    };
}();

/* 01. Handles para oparaciones ajax con modales y formularios
---------------------------------------------  */
function handleAjaxModal() {
    console.log("((handleAjaxModal))");
    // Limpia los eventos asociados para elementos ya existentes, asi evita duplicación
    $("a[data-modal]").unbind("click");
    // Evita cachear las transaccione Ajax previas
    $.ajaxSetup({ cache: false });

    // Configura evento del link para aquellos para los que desean abrir popups
    $("a[data-modal]").on("click", function (e) {
        var dataModalValue = $(this).data("modal");

        modalBsContent.load(this.href, function (response, status, xhr) {
            switch (status) {
                case "success":
                    modalBs.modal({ backdrop: 'static', keyboard: false }, 'show');

                    if (dataModalValue == "modal-lg") {
                        modalBs.find(".modal-dialog").addClass("modal-lg");
                    } else {
                        modalBs.find(".modal-dialog").removeClass("modal-lg");
                    }

                    onModalInit(); // Inicializa el popup
                    break;

                case "error":
                    var message = "Error de ejecución: " + xhr.status + " " + xhr.statusText;
                    if (xhr.status == 403) $.msgbox(response, { type: 'error' });
                    else $.msgbox(message, { type: 'error' });
                    break;
            }

        });
        return false;
    });
}

function handleModalForm(modal, onSuccess) {
    modal.find('form').submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                onSuccess(result);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                var message = "Error de ejecución: " + textStatus + " " + errorThrown;
                $.msgbox(message, { type: 'error' });
                console.log("Error: ");
            }
        });
        return false;
    });
}

function handleAjaxForm(form, onSuccess) {
    form.submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                onSuccess(result);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                var message = "Error de ejecución: " + textStatus + " " + errorThrown;
                $.msgbox(message, { type: 'error' });
                console.log(message);
            }
        });
        return false;
    });
}

function alertaDiv(tipo, mensaje) {
    $("#divNotificacion").show();
    $("#divMensajeNotificacion").text(mensaje);
    switch (tipo) {
        case "success":
            $("#divNotificacion").attr('class', 'alert alert-success');
            break;
        case "warning":
            $("#divNotificacion").attr('class', 'alert alert-warning');
            break;
        case "danger":
            $("#divNotificacion").attr('class', 'alert alert-danger');
            break;
    }
    setTimeout(function () {
        $("#divNotificacion").hide();
    }, 6000);
    $('#danger').showBootstrapAlertDanger('Text "Danger" alert with close button and hide timout set to 4s.', Bootstrap.ContentType.Text, true, 4000);
}

//handleAjaxModal();