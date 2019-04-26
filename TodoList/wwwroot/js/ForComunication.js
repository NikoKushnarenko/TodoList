$(function () {
    var res = []
    $.getJSON("/api/People", null, function (data) {
        alert(data);
    });
    alert("");
});
$(function () {
    $('#but1').bind('click', function () {
	    var fet = {};
	    $.getJSON("/api/People", null, fet);
	});
});