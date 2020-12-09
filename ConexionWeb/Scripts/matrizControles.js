function MostrarSeccionDesdeCheckBox(nombreSeccion, element) {
    if ($(element).is(':checked')) {
        $("." + nombreSeccion).show();
    } else {
        $("." + nombreSeccion).hide();
    }
}

function OcultarSecciones() {
    $(".controlSOX").hide();
    $(".compartidoTercero").hide(); 
    $(".calidadEvidencia").hide();
    $(".controlCompensatorio").hide();
}

$(document).ready(function () {
    OcultarSecciones();
})