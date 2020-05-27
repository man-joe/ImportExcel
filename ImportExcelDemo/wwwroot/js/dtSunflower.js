var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetSun",
            "serverSide": true,
            // "url": PlaySpace/?handler=List

            //dataSrc: "",
            //contentType: "application/json",
            "dataType": "json"
        },
    /*    "responsive": {
            "details": {
                "display": $.fn.dataTable.Responsive.display.modal({
                    "header": function (row) {
                        var data = row.data();
                        return 'Details for ' + data[0] + ' ' + data[1];
                    }
                }),
                "renderer": $.fn.dataTable.Responsive.renderer.tableAll()
            }
        },*/

        "scrollX" : true,
        "columns": [
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
            { "data": "responsibiltyDate" },
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
        "width":"100%",
    });
}