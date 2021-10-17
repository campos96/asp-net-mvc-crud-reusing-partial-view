$('.datepicker').each(function (index, input) {
    $(input).datepicker({
        format: "mm/dd/yyyy"
    });
});

$('table').each(function (index, table) {
    $(table).dataTable({
        "dom": "<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
    });
});

$('.select2').each(function (index, input) {
    $(input).select2();
});