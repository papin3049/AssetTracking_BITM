$(document).ready(function () {
    $('.alert-autocloseable-success').hide();


    $('#autoclosable-btn-success').click(function () {
        $('#autoclosable-btn-success').prop("disabled", true);
        $('.alert-autocloseable-success').show();

        $('.alert-autocloseable-success').delay(5000).fadeOut("slow", function () {
            // Animation complete.
            $('#autoclosable-btn-success').prop("disabled", false);
        });
    });



});