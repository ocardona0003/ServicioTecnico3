//funcion cuando el documento este completamente inicializado
var loop = 0;
$(document).ready(function () {
    $(".fecha").datepicker();  
    $('.dropdown-search').select2();
    $('#check_in').datepicker().on("change keyup paste", function (e) {
        ActualizaPartialView();
    });
    $('#check_out').datepicker().on("change keyup paste", function (e) {
        ActualizaPartialView();
    });
    $('#usuarioFiltro').select2().on("change", function (e) {  
        ActualizaPartialView();
    });
    if (loop === 0) {
        cargarMotivosVisita();
        cargarEstadoBoletas();
        cargarUsuarios(); 
        cargarTiposIncidencias();
        loop = loop + 1;
    }    
});
//funciones para cambiar el modo de las fechas del datepicker
//$.datepicker.regional['es'] = {
//    closeText: 'Cerrar',
//    prevText: '< Ant',
//    nextText: 'Sig >',
//    currentText: 'Hoy',
//    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
//    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
//    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
//    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
//    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
//    weekHeader: 'Sm',
//    dateFormat: 'dd/mm/yy',
//    firstDay: 1,
//    isRTL: false,
//    showMonthAfterYear: false,
//    yearSuffix: ''
//};
//$.datepicker.setDefaults($.datepicker.regional['es']);
//$(function () {
//    $(".fecha").datepicker();
//});

function ActualizaPartialView() {  
    
    var check_in = $('#check_in').val();    
    var check_out = $('#check_out').val();    
    var usr = $("#usuarioFiltro").select2("val");    
    var parts = check_in.split('/');
    check_in = parts[1] + '/' + parts[0] + '/' + parts[2];
    parts = check_out.split('/');
    check_out = parts[1] + '/' + parts[0] + '/' + parts[2];   
    if (usr === null) {
        usr = UserID;
    }    
    $("#partialView_GetList").load('/BoletaVisita/_GetList/?fechaIni=' + check_in + '&fechaFin=' + check_out + "&usuario=" + usr);
    
}


////////date time picker
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

//funcion para llenar el motivo de visita
function cargarMotivosVisita() {
    
    $.get(
        '/BoletaVisita/getMotivosVisita'
    ) 
        .done(function (data) {            
            $.each(data, function (i, row) {
                var $option = $('<option>');
                $option.val(row.id);
                $option.html(row.nombre);
                $('#motivoVisita').append($option);
            });
        })
        .fail(function (data) {
            console.log('error !!!');
        }
        );
} 

//funcion para llenar el estado de la boleta de visita tecnica
function cargarEstadoBoletas() {

    $.get(
        '/BoletaVisita/getEstadosBoletaVisita'
    )
        .done(function (data) {            
            $.each(data, function (i, row) {
                var $option = $('<option>');
                $option.val(row.id);
                $option.html(row.nombre);
                $('#estado').append($option);
            });
        })
        .fail(function (data) {
            console.log('error !!!');
        }
        );
} 


//funcion para llenar el estado de la boleta de visita tecnica
function cargarUsuarios() {
    $.get(
        '/BoletaVisita/getUsuarios'
    )
        .done(function (data) {            
            $.each(data, function (i, row) {
                var $option = $('<option>');
                $option.val(row.id);
                $option.html(row.nombreCompleto);               
                //console.log(row.id, row.nombreCompleto );     
                $('.dropdown-usuarios').append($option);                  
            });
            $('.dropdown-usuarios').val(UserID).trigger('change');
        })
        .fail(function (data) {
            console.log('error !!!');
        }
        );
} 


//funcion para llenar los tipos de incidencias
function cargarTiposIncidencias(id, tipo) {
    $.get(
        '/BoletaVisita/getTiposIncidencias'
    )
        .done(function (data) {            
            $.each(data, function (i, row) {
                var $option = $('<option>');
                $option.val(row.id_tipo_incidencia);
                $option.html(row.nombre_tipo_incidencia);
                //console.log(row.id_tipo_incidencia, row.nombre_tipo_incidencia );     
                $('.dropdown-tiposincidencias').append($option);
            });    
            $('#TiposIncidencias_' + id).val(tipo).trigger('change');
        })
        .fail(function (data) {
            console.log('error !!!');
        }
        );
} 



