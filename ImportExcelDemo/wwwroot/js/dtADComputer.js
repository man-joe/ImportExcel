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
        ]
    });
}