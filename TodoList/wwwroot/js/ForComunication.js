function UpdateForm() {
    $.getJSON("/api/TodoTask/1", null, function (data) {
        for (var i = 0; i < data.length; i++) {
            var divrow = document.createElement('div');
            var divColomnOne = document.createElement('div');
            var divColomnTwo = document.createElement('div');
            var divGroupButton = document.createElement('div');

            divrow.classList.add("row");
            divColomnOne.classList.add("col-xs-12");
            divColomnOne.classList.add("col-sm-6");
            divColomnOne.classList.add("col-md-8");
            divColomnTwo.classList.add("col-xs-6");
            divColomnTwo.classList.add("col-md-4");
            divGroupButton.classList.add("btn-group");

            var lable = document.createElement('lable');
            lable.innerText = data[i].desc;

            var butEdit = document.createElement('button');
            butEdit.innerText = "Edit";
            butEdit.classList.add("btn");
            butEdit.classList.add("btn-primary");
            butEdit.classList.add("btn-rounded");
            $(butEdit).attr("onclick", "EditTask(" + data[i].id + ")");

            var butDelete = document.createElement('button');
            butDelete.innerText = "Delete";
            butDelete.classList.add("btn");
            butDelete.classList.add("btn-primary");
            butDelete.classList.add("btn-rounded");
            $(butDelete).attr("onclick", "DeleteTask(" + data[i].id + ")");

            $(divrow).append(divColomnOne);
            $(divrow).append(divColomnTwo);

            $(divColomnOne).append(lable);
            $(divGroupButton).append(butEdit);
            $(divGroupButton).append(butDelete);
            $(divColomnTwo).append(divGroupButton);
            $('#TaskContent').append(divrow);
        }
    });
}
function CleanForm() {

}
$(function () {
    UpdateForm();
});
function EditTask(idTask) {
    $.getJSON("/api/TodoTask/GetOne/" + idTask + "", null, function (data) {
        $("#InputOrEditLine").val(data.desc);
        $(OkButton).attr("onclick", "Upadte(" + data.id + "," + data.peopleId + ")");
    });
}
function DeleteTask(idTask) {
    alert("Delete" + idTask);
}

function Upadte(data, peopleId) {
    var text = $("#InputOrEditLine").val();
    var transferObj = new Object();
    transferObj.id = data;
    transferObj.desc = text;
    transferObj.complite = false;
    transferObj.peopleId = peopleId;
    //var res = { id: data, desc: text, complite: false, peopleId: 1 };
    //var myJSON = JSON.stringify(res);
    $.ajax({
        url: "/api/TodoTask",
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(transferObj),
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    }); 
    UpdateForm();
    //$.put("/api/TodoTask", myJSON, function (data) {}
    //);
}