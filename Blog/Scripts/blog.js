$(function() {
    $("#login").click(function () {
        var data = {};
        $.ajax({
            type: "GET",
            url: 'Account/Login',
            date: date,
            cache: 'false',
            dataType: 'html',
            success: function(responce) {
                $("#main").html(responce);
            },
            error: function () { alert("hi")}
        });
        return false;
    });
});

