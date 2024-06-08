// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
//var DataTable = require('datatables.net');
//require('datatables.net-responsive');


let table = new DataTable('#dataTable', {
    // options
    ordering: false,
    info: false,
    responsive: true

});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.fixed-action-btn');
    var instances = M.FloatingActionButton.init(elems, {
        direction: 'left',
        hoverEnabled: false
    });
});

const saveButton = document.getElementById('saveButton');

document.getElementById('foto').addEventListener('change', function (e) {
    showThumbnail(this.files);
});

function showThumbnail(files) {
    if (files && files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            document.getElementById('thumbnail').src = e.target.result;
        };
        reader.readAsDataURL(files[0]);
        saveButton.disabled = false;
    }
}




