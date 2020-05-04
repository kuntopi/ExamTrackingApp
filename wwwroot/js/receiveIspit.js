"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (isp) {
    var test = document.createElement("p");
    test.textContent = "teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest";
    document.getElementById("test").appendChild(test);

    var encodedMsg = isp;
    var tdBrIndeksa = document.createElement("td");
    tdBrIndeksa.textContent = isp.brIndeksa;
    var tdPredmet = document.createElement("td");
    tdPredmet.textContent = isp.predmet;
    var tdOcena = document.createElement("td");
    tdOcena.textContent = isp.ocena;
    var tdDatum = document.createElement("td");
    tdDatum.textContent = isp.datum;
    var tdEdits = document.createElement("td");
    tdEdits.id = "tdEdits";
    document.getElementById("newIspit").appendChild(tdBrIndeksa);
    document.getElementById("newIspit").appendChild(tdPredmet);
    document.getElementById("newIspit").appendChild(tdOcena);
    document.getElementById("newIspit").appendChild(tdDatum);
    document.getElementById("newIspit").appendChild(tdEdits);
    document.getElementById("tdEdits").innerHTML = "<a href=\" /Ispit/Edit/26\">Edit</a> | <a href = \"/Ispit/Details/26\" > Details</a> | <a href=\"/Ispit/Delete/26\">Delete</a>";

});

connection.start().catch(function (err) {
    return console.error(err.toString());
});