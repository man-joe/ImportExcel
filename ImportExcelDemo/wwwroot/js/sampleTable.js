var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetCMDB",
            "serverSide": true,
            // "url": PlaySpace/?handler=List

            //dataSrc: "",
            //contentType: "application/json",
            "dataType": "json"
        },
        "scrollX": true,
        "columnDefs": [
          /*  {
                "targets": [0], //Hide CmdbID
                "visible": false,
                "searchable": false
            }*/


           /* {
                "targets": [18], // Aquisition Date - Changed format
                "render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss', 'MM/DD/YYYY')
            },
*/
         /*   {
                "targets": [19],
                "render": $.fn.dataTable.render.moment("YYYY-MM-DD HH:mm:ss", "MM/DD/YYYY")
            }*/



        ],

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
            { "data": "modified" }
        ],
        "width":"100%",
    });
}