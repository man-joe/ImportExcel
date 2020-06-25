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
            { "data": "changed" },
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
        ]
    });
}