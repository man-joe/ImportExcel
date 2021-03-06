﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/sample/GetCMDB_Sunflower",
            "type": "GET",            
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,

        "columns": [
            { "data": "cmdbID" }, // position 0
            { "data": "cdTag" },
            { "data": "org" },
            { "data": "hostName" },
            { "data": "location" },
            { "data": "floor" },
            { "data": "room" },
            { "data": "ipAddress" },
            { "data": "subnetMask" },
            { "data": "macAddress" },
            { "data": "cmdB_Manufacturer" },
            { "data": "cmdB_Model" },
            { "data": "cmdB_SerialNumber" },
            { "data": "operatingSystem" },
            { "data": "adUser" },
            { "data": "sunflowerUser" },
            { "data": "cmdB_Status" },
            { "data": "classType" },
            { "data": "cmdB_AcquisitionDate" },
            { "data": "warrantyEndDate" },
            { "data": "custodian" },
            { "data": "comments" },
            { "data": "inventoriedBy" },
            { "data": "inventoryDate" },
            { "data": "lastScan" },
            { "data": "modifiedBy" },
            { "data": "modified" },
            { "data": "sunID" },
            { "data": "barcodeNum" },
            { "data": "status" },
            { "data": "officialName" },
            { "data": "manufacturer" },
            { "data": "model" },
            { "data": "modelName" },
            { "data": "serialNumber" },
            { "data": "assetValue" },
            { "data": "effectiveDate" },
            { "data": "custArea" },
            { "data": "bureauOrRegion" },
            { "data": "propertyContact" },
            { "data": "currentUser" },
            { "data": "fedSupplyGroup" },
            { "data": "utilizationCode" },
            { "data": "assetCondition" },
            { "data": "conditionDescription" },
            { "data": "physicalInventoryDate" },
            { "data": "acquisitionDate" },
            { "data": "responsibilityDate" },
            { "data": "site" },
            { "data": "stlv1" },
            { "data": "stlv2" },
            { "data": "stlv3" },
            { "data": "mailStop" },
            { "data": "gps1" },
            { "data": "gps2" },
            { "data": "gps3" },
            { "data": "resolutionDate" },
            { "data": "resolution" },
            { "data": "finalEvent" },
            { "data": "datetime" },
            { "data": "finalEventUserDefinedLabel01" },
            { "data": "finalEventUserField01" }
        ],
        //Search Panes
        searchPanes: {
            cascadePanes: true,
            controls: true,
            layout: 'columns-5',
            columns: [2,3,4,5,6] // find which columns to filter, more than 10 slows down the page
        },
        //Buttons
        buttons: [
            'colvis','copy', 'csv', 'excel', 'print'
        ],
        dom: 'PBlfrtip',

        "width": "100%",

       
    });
}