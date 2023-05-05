/**
* Theme: Adminto Admin Template
* Author: Coderthemes
* Component: Datatable
* 
*/

var handleDataTableButtons = function () {
    "use strict";
    0 !== $("#datatable-buttons").length && $("#datatable-buttons").DataTable({
        dom: "Bfrtip",
        buttons: [{extend: "pdf", className: "btn-sm"}],
        responsive: !0
    })
}, TableManageButtons = function () {
    "use strict";
    return {
        init: function () {
            handleDataTableButtons()
        }
    }
}();