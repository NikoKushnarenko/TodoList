$(function () {
    $.getJSON("/api/TodoTask", { id: 1 }, function (data, textStatus) {
	    var div = document.createElement('div');
	    var p = document.createElement('lable');
	    p.innerText = "123";
	    var butEdit = document.createElement('button');
	    butEdit.innerText = "Edit";
	    var butDelete = document.createElement('button');
	    butDelete.innerText = "Delete";
	    var idPeople = document.createElement('input');

	    $(div).append(p);
	    $(div).append(butEdit);
	    $(div).append(butDelete);
	    $('#TaskContent').append(div);
    });
});
$(function () {
    $('#but1').bind('click', function () {
	    var fet = {};
        $.getJSON("/api/people", { id: 1 }, function(data, textStatus) {
	        alert(data);
        });
	});
});

//var div = document.createElement('div');
//var p = document.createElement('lable');
//p.innerText = "123";
//var butEdit = document.createElement('button');
//butEdit.innerText = "Edit";
//var butDelete = document.createElement('button');
//butDelete.innerText = "Delete";
//var idPeople = document.createElement('input');

//$(div).append(p);
//$(div).append(butEdit);
//$(div).append(butDelete);
//$('#TaskContent').append(div);