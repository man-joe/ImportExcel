var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable( {
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetAD_Computer",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,     
        
        "columns": [
            { "data": "adComputerId" },
            { "data": "adComputerName" },
            { "data": "programOffice" },
            { "data": "osType" },
            { "data": "osVersion" },
            { "data": "servicePack" },
            { "data": "created" },
            { "data": "changed" },
            { "data": "uac" },
            { "data": "accountDisabled" },
            { "data": "smartCardRequired" },
            { "data": "description" },
            { "data": "dn" },
        ],
        //Search Panes
        searchPanes: {
            cascadePanes: true,
            controls: true,
            layout: 'columns-5',
            columns: [2, 3, 4, 5, 6] // find which columns to filter, more than 10 slows down the page
        },
        //Buttons
        buttons: [
            'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'
        ],

        /*responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        var data = row.data();
                        return 'Details for ' + data[0] + ' ' + data[1];
                    }
                }),
                renderer: $.fn.dataTable.Responsive.renderer.tableAll()
            }
        },*/

        dom: 'PBlfrtip',

        "width": "100%",
    });
}