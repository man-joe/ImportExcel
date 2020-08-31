var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetECMO",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,
        "columns": [
            { "data": "ecmoID" },
            { "data": "computerName" },
            { "data": "noaaAssetTag" },
            { "data": "userName" },
            { "data": "noaaSerialNumber" },
            { "data": "ipAddress" },
            { "data": "ipAndMacAddress" },
            { "data": "os" },
            { "data": "cpu" },
            { "data": "lastReportTime" },
            { "data": "bios" },
        ],

        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        //Buttons
        buttons: [
            'colvis', 'copy', 'csv', 'excel', 'print'
        ],
        dom: 'PBlfrtip',

        "width": "100%",
    });
}