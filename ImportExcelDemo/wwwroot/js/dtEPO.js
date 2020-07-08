var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetEPO",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX" : true,
        "columns": [
            { "data": "epoID" },
            { "data": "managedState"},
            { "data": "systemName" },
            { "data": "tags" },
            { "data": "ipAddress" },
            { "data": "userName" },
            { "data": "lastCommunication"},
        ],

        //Modal
        responsive: {
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
        },

        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        dom: 'Plfr<t>ip', 

        "width":"100%",
    });
}