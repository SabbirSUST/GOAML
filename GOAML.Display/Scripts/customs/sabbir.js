// convert javascript datetime format(milisecond) to UTC format
/*
*   javascript fatch datetime in milisecond format.
*   this function convert milisecond to actual understandable datetime
*/
function ConvertMillisecondToDate(param) {
    //var result;
    if (param == '' || param == null) return param;
    if (!_.isString(param)) return param;
    if (param.indexOf("/Date") > -1) {
        var y = new Date(parseInt(param.substr(6)));
        return  y.getDate() + '/' + (y.getMonth() + 1) + '/' + y.getFullYear();
    }
    return param;
}
/* 
 * this converter substract 13 hours from our local datetime.
 * created by Mohammed Sabbir
*/
function ConvertMillisecondToDateOnline(param) {
    var result;
    if (param.indexOf("/Date") > -1) {
        var y = new Date(parseInt(param.substr(6)) - (13 * 3600000));
        result = y.getDate() + '/' + (y.getMonth() + 1) + '/' + y.getFullYear();
    } else {
        result = "";
    }
    return result;
}

// convert null variable to widespace
function ConvertNullToEmpty(result) {
    var resultstring = JSON.stringify(result);
    resultstring = resultstring.split("null").join('" "');
    result = JSON.parse(resultstring);
    return result;
}
/*
*   convert boolean value to viewable yes/no string
*
*/
function booleantoString(a) {
    var result = "";
    if (a && a != " ") {
        result = "Yes";
    } else if (!a) {
        result = "No";
    } else {
        result = " ";
    }
    return result;
}

/*
*   use to show halt time.
*/
function loading() {
    $(".btn").isLoading();

    setTimeout(function () {
        // Deactivate the loading plugin
        $(".btn").isLoading("hide");

    }, 5000);
}


$(function () {
    $(".dropdown-menu > li > a.trigger").on("click", function (e) {
        var current = $(this).next();
        var grandparent = $(this).parent().parent();
        if ($(this).hasClass('left-caret') || $(this).hasClass('right-caret'))
            $(this).toggleClass('right-caret left-caret');
        grandparent.find('.left-caret').not(this).toggleClass('right-caret left-caret');
        grandparent.find(".sub-menu:visible").not(current).hide();
        current.toggle();
        e.stopPropagation();
    });
    $(".dropdown-menu > li > a:not(.trigger)").on("click", function () {
        var root = $(this).closest('.dropdown');
        root.find('.left-caret').toggleClass('right-caret left-caret');
        root.find('.sub-menu:visible').hide();
    });
});
