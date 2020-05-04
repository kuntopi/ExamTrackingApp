"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("submitButton").disabled = true;

connection.on("ReceiveMessage", function (isp) {
    var noviIspit = document.getElementById("noviIspit").value;
    if (noviIspit === "true") {
        noviIspit = "false";
    }
    else {
        var ispit = document.createElement("tr");
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
        document.getElementById("tdEdits").innerHTML = "<a href=\" /Ispit/Edit/" + isp.ispitId + "\">Edit</a> | <a href = \"/Ispit/Details/" + isp.ispitId + "\" > Details</a> | <a href=\"/Ispit/Delete/" + isp.ispitId + "\">Delete</a>";

    }
});

connection.start().then(sendMessage).catch(function (err) {
    return console.error(err.toString());
});

function sendMessage() {
    var noviIspit = document.getElementById("noviIspit").value;
    if (noviIspit === "true") {
        var br = document.getElementById("brIndeksa").value;
        var pr = document.getElementById("predmet").value;
        var oc = document.getElementById("ocena").value;
        var da = document.getElementById("datum").value;
        var id = document.getElementById("ispitId").value;
        var isp = {
            ispitId: id,
            brIndeksa: br,
            predmet: pr,
            ocena: oc,
            datum: da
        }
        connection.invoke("SendMessage", isp).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }
    else { }
}