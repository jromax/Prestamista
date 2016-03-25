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

    //$.ajax({
    //    type: "GET",
    //    url: "Departamentos/RegistrarDepartamentoModal",
    //    data: "{}",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (msg) {
    //        // Replace the div's content with the page method's return.
    //        debugger;
    //    }
    //});

    //$("#modal-content").load("/Departamentos/RegistrarDepartamentoModal");
    //$('#modalBs').modal('show');

    $('#modalBs .modal-content').load('Departamentos/RegistrarDepartamentoModal', function (e) {
        $('#modal').modal('show');
    });
    //Utils.showModalBs("/Departamentos/RegistrarDepartamentoModal", "modal-lg");

    ////$("#window").data("kendoWindow").open();
    //var window = $("#window").data("kendoWindow");
    //window.refresh({
    //    url: '/Departamentos/RegistrarDepartamentoModal'
    //});
    ////window.content("RegistrarDepartamentoModal/Departamentos");
    //window.center();
    //window.open();
}

function onClose(ev) {
    $('#grid').data('kendoGrid').dataSource.read();
}

function OnSuccess(res) {
    debugger;
}
