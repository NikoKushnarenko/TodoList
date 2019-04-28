$(function () {
    $.getJSON("/api/TodoTask/1", null, function (data) {
	    for (var i = 0; i < data.length; i++) {
            var divrow = document.createElement('div');
            var divColomnOne = document.createElement('div');
            var divColomnTwo = document.createElement('div');

            divrow.classList.add("row");
            divColomnOne.classList.add("col-xs-12");
            divColomnOne.classList.add("col-sm-6");
            divColomnOne.classList.add("col-md-8");
            divColomnTwo.classList.add("col-xs-6");
            divColomnTwo.classList.add("col-md-4");

		    var lable = document.createElement('lable');
		    lable.innerText = data[i].desc;
		    var butEdit = document.createElement('button');
		    butEdit.innerText = "Edit";
		    var butDelete = document.createElement('button');
            butDelete.innerText = "Delete";

            $(divrow).append(divColomnOne);
            $(divrow).append(divColomnTwo);

            $(divColomnOne).append(lable);
            $(divColomnTwo).append(butEdit);
            $(divColomnTwo).append(butDelete);
            $('#TaskContent').append(divrow);
	    }
	    
    });
});