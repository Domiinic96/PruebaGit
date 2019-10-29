
$(function () {
    $("TelefonosCia").on('input', function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    })
});


$("#cancelar").on('click', function () {

    $("#NombreCia").val("");// = "";
    $("#NombreClte").val("");
    $("#ApellidoClte").val("");
    $("#Direccion").val("");
    $("#CiudadCia").val("");
    $("#SectorCia").val("");
    $("#RncCia").val("");
    $("#TelefonosCia").val("");
    $("#FaxCia").val("");
    $("#EmailCia").val("");
    $("#WebCia").val("");

});

var ver = $("#estatus").val();



$("#TelefonosCia").keypress(function ValidarNumeros(e) {
    key = e.keyCode || e.Which;

    teclado = String.fromCharCode(key);
    TelefonosCia = "1234567890-";
    especiales = "8-37-38-46";

    TecladoEspecial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            TecladoEspecial = true
        }


    }

    if (teclado.length > 10) {
        return false;

    }

    if (TelefonosCia.indexOf(teclado) == -1 && !TecladoEspecial) {
        return false;
    }
});


$("#RncCia").keypress(function ValidarNumeros(e) {
    key = e.keyCode || e.Which;

    teclado = String.fromCharCode(key);
    RncCia = "1234567890-";
    especiales = "8-37-38-46";

    TecladoEspecial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            TecladoEspecial = true
        }


    }

    if (RncCia.indexOf(teclado) == -1 && !TecladoEspecial) {
        return false;
    }
});

$("#FaxCia").keypress(function ValidarNumeros(e) {
    key = e.keyCode || e.Which;

    teclado = String.fromCharCode(key);
    FaxCia = "1234567890-";
    especiales = "8-37-38-46";

    TecladoEspecial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            TecladoEspecial = true
        }


    }

    if (FaxCia.indexOf(teclado) == -1 && !TecladoEspecial) {
        return false;
    }
});

$("#NombreClte").keypress(function ValidarNumeros(e) {
    key = e.keyCode || e.Which;

    teclado = String.fromCharCode(key);
    NombreCia = "aAbBcCdDeEfFgGhHiIkJkKlLmMnNñÑoOpPqQrRsStTuUvVwWxXyYzZ ";
    especiales = "8-37-38-46";

    TecladoEspecial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            TecladoEspecial = true
        }


    }
    if (NombreCia.indexOf(teclado) == -1 && !TecladoEspecial) {
        return false;

    }
});
$("#ApellidoClte").keypress(function ValidarNumeros(e) {
    key = e.keyCode || e.Which;

    teclado = String.fromCharCode(key);
    ApellidoClte = "aAbBcCdDeEfFgGhHiIkJkKlLmMnNñÑoOpPqQrRsStTuUvVwWxXyYzZ ";
    especiales = "8-37-38-46";

    TecladoEspecial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            TecladoEspecial = true
        }


    }



    if (ApellidoClte.indexOf(teclado) == -1 && !TecladoEspecial) {
        return false;
    }
});