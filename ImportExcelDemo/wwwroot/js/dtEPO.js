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