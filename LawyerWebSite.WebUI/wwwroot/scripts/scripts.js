$(document).ready(function () {

    var wid = $(window).width();
    if (wid > 489 && wid < 992) {
        $(".breadcrumb").removeClass("w-25 w-100").addClass("w-50");
    } else if (wid < 489) {
        $(".breadcrumb").removeClass("w-25").addClass("w-100");
    }

    $(window).resize(function () {
        $(".jumbotron").each(function (i, e) {
            e = $(e);
            if (e.width() > 489 && e.width() < 992) {
                $(".breadcrumb").removeClass("w-25 w-100").addClass("w-50");
            } else if (e.width() >= 992) {
                $(".breadcrumb").removeClass("w-50 w-100").addClass("w-25");
            } else if (e.width() < 489) {
                $(".breadcrumb").removeClass("w-50").addClass("w-100");
            }
        });
    });
});