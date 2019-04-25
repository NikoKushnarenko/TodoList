$(function () {
	$.getJSON("/api/People", null, fet);
});
$(function () {
    $('#but1').bind('click', function () {
	    var fet = {};
	    $.getJSON("/api/People", null, fet);
	});
});