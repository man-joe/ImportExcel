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
            //Adding Buttons editing and deleting
            {
                
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href = "/DisplayEPO/Update?id=${data}" class= "btn btn-success text-white" style = "cussor:pointer; width:100px;" >
                                    <i class="far fa-edit"></i> Edit                           
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('/api/EPO/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                    </div> `;
                }, "width": "30%"
            }, 
        ],
        //Search Panes
        searchPanes: {
            cascadePanes: true
        },
        dom: 'Pfrtip', 

        "width":"100%",
    });
}