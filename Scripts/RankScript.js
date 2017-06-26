$(document).ready(function () {
    var uri = '/api/Users';


    $.getJSON(uri).done(function (array) {
        var table = document.getElementById("myTable");
        for (var i = 0; i < array.length; i++) {
            var row = table.insertRow(1);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            var cell4 = row.insertCell(3);
            cell1.innerHTML = array[i].Rank;
            cell2.innerHTML = array[i].UserName;
            cell3.innerHTML = array[i].Win;
            cell4.innerHTML = array[i].Loose;
        }

    })



});