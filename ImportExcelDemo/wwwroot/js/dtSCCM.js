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

        //Modal
       /* responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        var data = row.data();
                        return 'Details for ' + data[0] + ' ' + data[1];
                    }
                }),
                renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                    tableClass: 'table'
                })
            }
        },*/

        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        dom: 'Plfr<t>ip', 

        "width":"100%",
    });
}