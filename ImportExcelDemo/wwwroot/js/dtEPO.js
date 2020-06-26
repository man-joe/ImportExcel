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
            // "url": PlaySpace/?handler=List

            //dataSrc: "",
            //contentType: "application/json",
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
        ],
        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        dom: 'Plfrtip', 

        "width":"100%",
    });
}