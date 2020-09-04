//funcion cuando el documento este completamente inicializado
$(document).ready(function () {
    $("#fecha").datepicker();

    //$("#btnTareaDet").click(function (eve) {
    //    $("#modal-content").load("/Levantados/_ModalItemLevantado");
    //});
});

function MuestraTareaLev(lev) {
    var idLev = $("#id").val();
    var referencia = $("#referencia").val();
    //if (idLev != 0 && referencia != 0) {
    //    alert("Algunos campos no estan completados, corrija y guarde para obtener numero de Levantado, intente de nuevo");
    //    return;
    //}
    $("#modalLevDet").modal();
    $("#modal-content").load("/Levantados/_ModalItemLevantado/" + lev);
}

//funciones para cambiar el modo de las fechas del datepicker
$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '< Ant',
    nextText: 'Sig >',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};
$.datepicker.setDefaults($.datepicker.regional['es']);
$(function () {
    $(".fecha").datepicker();
});

//funcion para llenar la consulta de tienda
function BuscaTienda() {
    $("#modalBuscaTienda").modal();
    $.get("/Levantados/GetMarket", DataTienda);
}
function DataTienda(Lista) {
    var SetData2 = $("#SetDataModalBuscaTienda");
    SetData2.empty();
    for (var i = 0; i < Lista.length; i++) {
        var Data =
            "<tr id=\"" + Lista[i].id_tienda + "\" class=\"row_" + Lista[i].id_tienda + "\">" +
            "<td id=\"id_tienda\">" + Lista[i].id_tienda + "</td>" +
            "<td id=\"nombre_tiendaF\">" + Lista[i].nombre_tienda + "</td>" +
            "<td id=\"nombre_cliente\">" + Lista[i].nombre_cliente + "</td>" +
            "<td>" +
            "<div class=\"btn-group  btn-group-sm\">" +
            "<input type=\"button\" class=\"btn btn-success btn-xs editar\" value=\"Seleccionar\" onclick='SeleccionarTienda(\"" + Lista[i].id_tienda + "\", \"" + Lista[i].nombre_tienda + "\")'/>" +
            "</div>" +
            "</td>" +
            "</tr>";
        SetData2.append(Data);
    }
    $("#tableBuscaTienda").DataTable();
}
function SeleccionarTienda(val1, val2) {
    $("#idTienda").val(val1);
    $("#nombre_tienda").val(val2);
    $("#modalBuscaTienda").modal("toggle");
}
//funcion para llenar la busqueda de usuarios
function BuscaUsuario() {
    $("#modalBuscaUsuario").modal();
    $.get("/Levantados/GetUsers", DataUsuario);
}
function DataUsuario(Lista) {
    var SetData2 = $("#SetDataModalBuscaUsuario");
    SetData2.empty();
    for (var i = 0; i < Lista.length; i++) {
        var Data =
            "<tr id=\"" + Lista[i].id_usuario + "\" class=\"row_" + Lista[i].id_usuario + "\">" +
            "<td id=\"id_usuarioF\">" + Lista[i].id_usuario + "</td>" +
            "<td id=\"nombreF\">" + Lista[i].nombre + " " + Lista[i].apellido + "</td>" +
            "<td>" +
            "<div class=\"btn-group  btn-group-sm\">" +
            "<input type=\"button\" class=\"btn btn-success btn-xs editar\" value=\"Seleccionar\" onclick='SeleccionaUsuario(\"" + Lista[i].id_usuario + "\", \"" + Lista[i].nombre + " " + Lista[i].apellido + "\")'/>" +
            "</div>" +
            "</td>" +
            "</tr>";
        SetData2.append(Data);
    }
    $("#tableBuscaUsuario").DataTable();
}
function SeleccionaUsuario(val1, val2) {
    $("#idUsuario").val(val1);
    $("#usuario").val(val2);
    $("#modalBuscaUsuario").modal("toggle");
}

    //funcion para mostrar modal de manejo de levatnado detalle (tarea del levantado)



