$(document).ready(function () {

    // inicio de scripts
    $('#frm').submit(function (e) {
        e.preventDefault();

        parametros = $(this).serialize();



        console.log('submit', parametros);
        $.post('/Access/Enter', parametros, function (data) {

            if (data == "1") {
                document.location.href = '/';
            } else {
                alert(data);
            }

        });

    });

});