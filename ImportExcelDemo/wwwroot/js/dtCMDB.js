var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/sample/GetCMDB",
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
                "data": "cmdbID",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href = "/DisplayCMDB/Edit?id=${data}" class= "btn btn-success text-white" style = "cussor:pointer; width:50px;" >
                                    Edit
                                </a>     
                                <a href = "/DisplayCMDB/Delete?id=${data}" class= "btn btn-danger text-white" style = "cussor:pointer; width:75px;" >
                                    Delete
                                </a>                                
                            </div> `;
                }, /*"width": "25%"*/
            }, 
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
            'colvis','copy', 'csv', 'excel', 'pdf', 'print'
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