﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetCMDB",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,

        "columns": [
            { "data": "cmdbID" },
            { "data": "cdTag" },
            { "data": "org" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "serialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "status" },
            { "data": "classType" },
            { "data": "acquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" },
            //Adding buttons for editing and deleting
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href = "/DisplayCMDB/Edit?id=${data}" class= "btn btn-success text-white" style = "cussor:pointer; width:100px;" >
                                    <i class="far fa-edit"></i> Edit     
                                <a href = "/DisplayCMDB/Delete?id=${data}" class= "btn btn-danger text-white" style = "cussor:pointer; width:100px;" >
                                    <i class="far fa-edit"></i> Delete 
                                
                    </div> `;
                }, "width": "30%"
            }, 
        ],
        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        dom: 'Pfrtip', 
        "width": "100%",

       
    });
}