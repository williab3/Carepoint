$(document).ready(function () {
    $("#tabContent").load("/Home/MyPasbaApps");

    $("#pasbaTabs").on("click", function (e) {
        $("#pasbaTabs > li").each(function (i, element) {
            $(element).removeClass("active");
        });
        console.log(e.target);
        $(e.target).parent().addClass("active");
    });
});