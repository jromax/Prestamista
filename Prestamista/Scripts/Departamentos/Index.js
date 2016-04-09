//var modal = $("#RegistrarDepartamento");
//var modalBsContent = $('#RegistrarDepartamento').find(".modal-content");
var modalBs = $('#modalBs');
var modalBsContent = $('#modalBs').find(".modal-content");

function cambiarEstado(id, EstadoActual) {
    var nuevoEst = 0;
    var mensaje = "Registro activado";
    if (EstadoActual == 0) {
        nuevoEst= 1;
        mensaje = "Registro desactivado";
    }    
    $.confirm({
        title: 'Confirma modificación de estado' ,
        content: 'Realmente desea continuar',
        confirm: function () {
            $.post("/Departamentos/UpdEstadoDepartamento", { Id: id, NuevoEstado: nuevoEst },
            function (result) {                
                alerta(result);
                $('#grid').data('kendoGrid').dataSource.read();
            });
        },
        cancel: function () {
            alerta("Resultado", "Operación Cancelada por el usuario", "warning");
        },
        confirmButtonClass: 'btn-info',
        cancelButtonClass: 'btn-danger',
        confirmButton: 'Si',
        cancelButton: 'NO'
    });       
    return false;
}

function iniciarModalRegistro() {
    $(".modal-content").load("/Departamentos/RegistrarDepartamentoModalFrm");
    cerrarModal();
}

function onClose(ev) {
    $('#grid').data('kendoGrid').dataSource.read();
}

function OnSuccess(res) {
    if (res.Respuesta = true) {
        $('.modal').modal('hide');
        $('#grid').data('kendoGrid').dataSource.read();
        alerta(res);
    }
    
}
