$(document).ready(function () {

    //#region Limpieadores y validadores
    let clear = () => {
        $('samp').hide();
        $('input').val('');
        $('input').removeClass("error")
        $('input').removeAttr('disabled');
    }

    let isValid = (valid, id) => {
        valid ? $(id).removeClass("error") : $(id).addClass("error");
        valid ? $(id + 'invalid').hide() : $(id + 'invalid').show();
    }

    function isEmpty(str) {
        return (!str || str.length === 0);
    }

    let enviar = () => {
        $('input').attr('disabled', 'disabled');
        alert("Datos enviados. Nos pondremos en contacto... vos espera nomas ;)");
    }
    //#endregion

    //#region  Disparadores

    $('#btnEnviar').click(function (e) {
        e.preventDefault();

        isEmpty($('#inpNombre').val()) ? isValid(false, '#inpNombre') : isValid(true, '#inpNombre');
        isEmpty($('#inpApellido').val()) ? isValid(false, '#inpApellido') : isValid(true, '#inpApellido');
        isEmpty($('#inpEdad').val()) ? isValid(false, '#inpEdad') : isValid(true, '#inpEdad');

        if (!isEmpty($('#inpNombre').val()) &&
            !isEmpty($('#inpApellido').val()) &&
            !isEmpty($('#inpEdad').val())) enviar();

    });


    $('#btnLimpiar').click(function (e) {
        e.preventDefault();
        clear();
    });

    //#endregion

    clear();

    let formularioPrincipal = $('#frmContacto');
    $(formularioPrincipal).width(formularioPrincipal.height());


});
