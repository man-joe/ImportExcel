﻿var dataTable;

$(document).ready(function () {
    loadList();
    highlight();
});

/* experimenting with coloring columns...
function highlight() {
    var table = dataTable.DataTable();

    $('#DT_Load').on('mouseenter', 'td', function () {
        var colIdx = table.cell(this).index().column;
        
        $(table.cells().nodes()).removeClass('highlight');
        $(table.column(colIdx).nodes()).addClass('highlight');
    },
    */

 function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetADComputer_CMDB",
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
            'colvis', 'copy', 'csv', 'excel', 'print'
        ],
        dom: 'PBlfrtip',

        "width": "100%",
    });
}