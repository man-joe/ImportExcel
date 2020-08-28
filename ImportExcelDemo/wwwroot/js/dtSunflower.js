var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable( {
        "ajax": {
            "url": "/api/sample/GetSun",
            "type": "GET",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,
        
        "columns": [
            { "data": "sunID" }, // position 0
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
            columns: [2, 4, 5, 11, 12] // find crucial columns to filter, more than 10 slows down the page
        },
        //Buttons
        buttons: [
            'colvis', 'copy', 'csv', 'excel', 'print'
        ],
        dom: 'PBlfrtip',

        "width":"100%",
    });
}