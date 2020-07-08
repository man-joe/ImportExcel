var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "type": "GET",
            "url": "/api/sample/GetAD_User",
            "serverSide": true,
            "dataType": "json"
        },
        "scrollX": true,

        "columns": [
            { "data": "adUserId" },
            { "data": "programOffice" },
            { "data": "cacExemptionReason" },
            { "data": "smartCardRequired" },
            { "data": "userEmailAddress" },
            { "data": "employeeType" },
            { "data": "samAccountName" },
            { "data": "description" },
            { "data": "userPrincipalName" },
            { "data": "accountDisabled" },
            { "data": "passwordDoesNotExpire" },
            { "data": "passwordCannotChange" },
            { "data": "passwordExpired" },
            { "data": "accountLockedOut" },
            { "data": "cacExtendedInfo" },
            { "data": "uac" },
            { "data": "userName" },
            { "data": "dn" },
            { "data": "created" },
            { "data": "changed" }
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
            'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'
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