var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetSCCM",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX" : true,
        "columns": [
            { "data": "sccmId" },
            { "data": "computerName"},
            { "data": "domainWorkGroup" },
            { "data": "siteName" },
            { "data": "topConsoleUser" },
            { "data": "operatingSystem" },
            { "data": "serialNumber" },
            { "data": "assetTag" },
            { "data": "manufacturer" },
            { "data": "releaseDate" },
            { "data": "biosVersion" },
            { "data": "model" },
            { "data": "memoryKBytes" },
            { "data": "processorGhz" },
            { "data": "diskSpaceMB" },
            { "data": "freeDiskSpaceMB" },
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

        "width":"100%",
    });
}