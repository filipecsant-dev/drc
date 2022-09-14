$(document).ready(function () {
    var url_root = window.location.protocol + "//" + window.location.host;

    $('#table').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/pt-BR.json",
        },
        "pageLength": 6,
        "bLengthChange": false
    });

});