$("#but1").click(function () {
    $.ajax({
        url: "add.php",
        data: "x=4&y=5",
        success: function (result) {
            $("#par1").html(result)
        }
    });
});