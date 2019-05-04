//отдельный метод генерации формы.
function UpdateForm() {
    $.getJSON("/api/TodoTask/1", null, function (data) {
        for (var i = 0; i < data.length; i++) {
            var divrow = document.createElement('div');
            var divColomnOne = document.createElement('div');
            var divColomnTwo = document.createElement('div');
            var divColomnThree = document.createElement('div');
            var divGroupButton = document.createElement('div');

            divrow.classList.add("row");
            divColomnOne.classList.add("col");
            //divColomnOne.classList.add("col-sm-6");
            //divColomnOne.classList.add("col-md-8");
            divColomnTwo.classList.add("col-md-auto");
            //divColomnTwo.classList.add("col-md-4");
            divGroupButton.classList.add("btn-group");
            divColomnThree.classList.add("col");
            divColomnThree.classList.add("col-lg-2");

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

            var checkbox = $('<input />', { type: 'checkbox', value: data[i].id});
            $(checkbox).attr("onchange", "UdateByChecedBox("+data[i].id+")");
            //$(checkbox).click(UdateByChecedBox(data[i].id))
            if (data[i].complite) {
                $(checkbox).prop('checked', true);
            }
            else {
                $(checkbox).prop('checked', false);
            }
            $(divrow).append(divColomnOne);
            $(divrow).append(divColomnTwo);
            $(divrow).append(divColomnThree);

            $(divColomnOne).append(lable);
            $(divGroupButton).append(butEdit);
            $(divGroupButton).append(butDelete);
            $(divColomnTwo).append(checkbox);
            $(divColomnThree).append(divGroupButton);
            $('#TaskContent').append(divrow);
        }
    });
}
function UpdateAll() {
    CleanAddForm();
    CleanContent();
    UpdateForm();
}

function CleanContent() {
    $("#TaskContent").empty();
}
$(function () {
    UpdateAll();
});
function EditTask(idTask) {
    $.getJSON("/api/TodoTask/GetOne/" + idTask + "", null, function (data) {
        $("#InputOrEditLine").val(data.desc);
        $(OkButton).attr("onclick", "Upadte(" + data.id + "," + data.peopleId + ")");
    });
}
function DeleteTask(idTask) {
    $.ajax({
        url: "/api/TodoTask",
        type: 'DELETE',
        data: { id:idTask },
        success: function (result) {
            console.log(result);
        }
    });
    UpdateAll();
}

function CleanAddForm() {
    $("#InputOrEditLine").val("");
    $('#OkButton').attr('onClick', 'AddNewTask()');

} 
function AddNewTask() {
    var text = $("#InputOrEditLine").val();
    var transferObj = new Object();
    transferObj.desc = text;
    transferObj.complite = false;
    transferObj.peopleId = 1;
    $.ajax({
        url: "/api/TodoTask",
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(transferObj),
    }); 
    UpdateAll();
}
function Upadte(data, peopleId) {
    var text = $("#InputOrEditLine").val();
    var transferObj = new Object();
    transferObj.id = data;
    transferObj.desc = text;
    transferObj.complite = false;
    transferObj.peopleId = peopleId;
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
    UpdateAll();
}

function UdateByChecedBox(value) {
    $.getJSON("/api/TodoTask/GetOne/" + value + "", null, function (data) {
        var updateTask = data;
        updateTask.complite = !updateTask.complite;
        $.ajax({
            url: "/api/TodoTask",
            type: 'PUT',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(updateTask),
            success: function (data, textStatus, xhr) {
                console.log(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }
        }); 
    });
    
    UpdateAll();
}