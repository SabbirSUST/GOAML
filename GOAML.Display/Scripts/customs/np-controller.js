var npGlobalProp = {
    npPropSplitter: '^',
    npObjSplitter: '~',
    npObjNameSplitter: '<prop>',
    npListSplitter: '<list>'
};


var npAlert = function (msg) {
    if (msg.MessageType == 1) {
        //alertify.success(msg.Message + msg.ReturnValue);
        alertify.success(msg.ReturnValue);
    } else if (msg.MessageType == 2) {
        alertify.error(msg.ReturnValue);
    } else if (msg.MessageType == 3) {
        alertify.error(msg.ReturnValue);
    } else if (msg.MessageType == 4) {
        alertify.error(msg.ReturnValue);
    } else if (msg.MessageType == 5) {
        alertify.error(msg.ReturnValue);
    }
};
var npNotification = function (msg) {
    //var data = JSON.parse(msg);
    console.log(msg.ReturnValue);
    if (msg.MessageType == 1) {
        $('.alert').addClass('alert-success');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $('.alert').fadeIn('slow');
        //$(".alert").delay(2000).fadeOut("slow");
    } else if (msg.MessageType == 2) {
        $('.alert').addClass('alert-danger');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $(".alert").delay(2000).fadeOut("slow");
    } else if (msg.MessageType == 3) {
        $('.alert').addClass('alert-warning');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $(".alert").delay(2000).fadeOut("slow");
    } else if (msg.MessageType == 4) {
        $('.alert').addClass('alert-warning');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $(".alert").delay(2000).fadeOut("slow");
    } else if (msg.MessageType == 5) {
        $('.alert').addClass('alert-warning');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $(".alert").delay(3000).fadeOut("slow");
    } else if (msg.MessageType == 6) {
        $('.alert').addClass('alert-danger');
        $('.alert').html(msg.Message + '\n' + msg.ReturnValue);
        $(".alert").delay(3000).fadeOut("slow");
    }
    
};
/* this function intend to save ready data to server.
   **  pdata object create dynamically. it could be single object, list of object or 
       an object which contain both.
   **  url contain controller -> method name.
   **  redirectUrl contain url name if system needs to redirect to another method.

*/
var GenerateDropDownList = function (listObj, control, requiredField) {
    $('select#' + control).empty();
    var pOptionValues = '';
    requiredField = requiredField.split('^');
    pOptionValues += '<option value="0">Select One</option>';
    $.each(listObj, function (key, value) {
        pOptionValues += '<option value="' + value[requiredField[0]] + '">' + value[requiredField[1]] + '</option>';
    });
    $('select#' + control).append(pOptionValues);
};
// clear the form value
var ClearForm = function (controls) {
    $.each(controls, function (key, objVal) {
        var selectedDiv = '.' + key;
        //console.log(selectedDiv);
        $.each(objVal, function (k, control) {
            control = '#' + control;
            if ($(selectedDiv).find(control).is('select') || $(selectedDiv).find(control).is('Select') || $(selectedDiv).find(control).is('SELECT')) {
                $(selectedDiv).find(control + ' option:first').attr('selected','selected');
            }
            if ($(selectedDiv).find(control).is('input:radio')) {
                $(selectedDiv).find(control).prop('checked', false);
            }
            if ($(selectedDiv).find(control).is('input:text')) {
                $(selectedDiv).find(control).val('');
            }
            if ($(selectedDiv).find(control).is('textarea')) {
                    $(selectedDiv).find(control).val('');
            }
            if ($(selectedDiv).find(control).is('input:password')) {
                    $(selectedDiv).find(control).val('');
            }
            if ($(selectedDiv).find(control).is('input:hidden')) {
                    $(selectedDiv).find(control).val('');
            }
            if ($(selectedDiv).find(control).is('input:checkbox')) {
                $(selectedDiv).find(control).attr('checked', false);
            }
        });
    });
};
// clear the form value ends here
// prepare full form from object
var SetObjects = function (objects) {
    console.log(objects);
    $.each(objects, function (key, objVal) {
        var selectedDiv = '.' + key;
        if (Object.prototype.toString.call(objVal) === '[object Array]') {
            objVal = objVal[0];
        }
        //console.log(selectedDiv);
        $.each(objVal, function (k, value) {
            var control = '#' + k;
            if ($(selectedDiv).find(control).is('select') || $(selectedDiv).find(control).is('Select') || $(selectedDiv).find(control).is('SELECT')) {
                $('select' + control + ' option').each(function () {
                    if ($(this).val() == value) {
                        $(this).attr("selected", "selected");
                    }
                });
            }
            if ($(selectedDiv).find(control).is('input:radio')) {
                //$(selectedDiv).find(control).prop('checked', false);
            }
            if ($(selectedDiv).find(control).is('input:text')) {
                if (typeof (value) == "string") {
                    $(selectedDiv).find(control).val(ConvertMillisecondToDate(value));
                } else {
                    $(selectedDiv).find(control).val(value);
                }
            }
            if ($(selectedDiv).find(control).is('textarea')) {
                $(selectedDiv).find(control).val(value);
            }
            if ($(selectedDiv).find(control).is('input:password')) {
                $(selectedDiv).find(control).val(value);
            }
            if ($(selectedDiv).find(control).is('input:hidden')) {
                $(selectedDiv).find(control).val(value);
            }
            if ($(selectedDiv).find(control).is('input:checkbox')) {
                // $(selectedDiv).find(control).attr('checked', false);
            }
        });
    });
};
// prepare full form from object ends here
//return the value of html input field
//it will find the type and then find the value of that field.
var npGetPropVal = function (selectedDiv, control) {
    control = '#' + control;
    selectedDiv = '.' + selectedDiv;
    if ($(selectedDiv).find(control).is('select') || $(selectedDiv).find(control).is('Select') || $(selectedDiv).find(control).is('SELECT')) {
        return $(selectedDiv).find(control).find(':selected').attr('value');
    }
    if ($(selectedDiv).find(control).is('input:radio')) {
        return $(selectedDiv).find(control).attr('value');
    }
    if ($(selectedDiv).find(control).is('input:text')) {
        return $(selectedDiv).find(control).val();
    }
    if ($(selectedDiv).find(control).is('textarea')) {
        return $(selectedDiv).find(control).val();
    }
    if ($(selectedDiv).find(control).is('input:password')) {
        return $(selectedDiv).find(control).val();
    }
    if ($(selectedDiv).find(control).is('input:hidden')) {
        return $(selectedDiv).find(control).val();
    }
    if ($(selectedDiv).find(control).is('input:checkbox')) {
        if ($(selectedDiv).find(control).is(':checked')) {
            return 1;
        } else {
            return 0;
        }
    } else {
        return " ";
    }
};
/*
example :
    **  string format 
    **  controlStr='<obj-name>table-name<param-list>col1^col2^col3'
    **  seperate all table first by split the line using objectSplitter
    after 
*/

var npGetObject = function (npObjName, npObjProp) {
    // npObjProp = col1^col2^col3
    var npTemp = {};
    var propList = npObjProp.split(window.npGlobalProp.npPropSplitter);
    // propList = ['col1','col2','col3'];
    propList.forEach(function (val) {
        npTemp[val] = window.npGetPropVal(npObjName, val);
    });
    // npTemp = {'col1':col1_value,'col2':col2_value,'col3:col3_value'};
    return npTemp;
};

var npGetList = function (npObjName, npObjProp) {
    // npObjProp = col1^col2^col3
    // npObjName = should be table name
    var npTempArr = [];
    var propList = npObjProp.split(window.npGlobalProp.npPropSplitter);
    var container = $('.' + npObjName);
    $.each(container, function () {
        $(this).find('tr').each(function () {
            var npTemp = {};
            $(this).find('td').each(function () {
                var key = $(this).attr('np-key');
                if (_.indexOf(propList, key) > -1) {
                    npTemp[key] = $(this).html();
                }
            });
            npTempArr.push(npTemp);
        });
    });
    // npTempArr = {[0] = {'col1':col1_value,'col2':col2_value,'col3:col3_value'},
    //              [1] = {'col1':col1_value,'col2':col2_value,'col3:col3_value'}
    //              [2] = {'col1':col1_value,'col2':col2_value,'col3:col3_value'}};
    return npTempArr;
};

var npGetMegaObj = function (npFormControl) {
    var npMegaObj = {};
    var npObjName = '';
    var npObjProp = '';
    if (npFormControl.IsSingle) {

        npObjName = npFormControl.ControlStr.split(window.npGlobalProp.npObjNameSplitter)[0];
        // npObjName = tablename or <list>tablename
        npObjProp = npFormControl.ControlStr.split(window.npGlobalProp.npObjNameSplitter)[1];
        // npObjProp = col1^col2^col3
        
        if (npObjName.indexOf(window.npGlobalProp.npListSplitter) > -1) {
            // if npObjName == <list>tablename
            //objStr = <list>tablename<param-list>col1^col2^col3'
            npObjName = npObjName.split(window.npGlobalProp.npListSplitter)[1];
            npMegaObj[npObjName] = window.npGetList(npObjName, npObjProp);
        } else {
            // if npObjName == tablename
            //objStr = tablename<param-list>col1^col2^col3
            npMegaObj[npObjName] = window.npGetObject(npObjName, npObjProp);
        }
    } else {
        // split object by object splitter "~"
        var npObjContainer = npFormControl.ControlStr.split(window.npGlobalProp.npObjSplitter);
        // after split npObjContainer = [[0]='tablename<prop>col1^col2^col3',[1]='tablename<prop>col1^col2^col3',
        //                               [2]='<list>tablename<prop>col1^col2^col3'];
        npObjContainer.forEach(function (objStr) {
            npObjName = objStr.split(window.npGlobalProp.npObjNameSplitter)[0];
            // npObjName = tablename or <list>tablename
            npObjProp = objStr.split(window.npGlobalProp.npObjNameSplitter)[1];
            // npObjProp = col1^col2^col3
            if (npObjName.indexOf(window.npGlobalProp.npListSplitter) > -1) {
                // if npObjName == <list>tablename
                //objStr = <list>tablename<param-list>col1^col2^col3'
                npObjName = npObjName.split(window.npGlobalProp.npListSplitter)[1];
                npMegaObj[npObjName] = window.npGetList(npObjName, npObjProp);
            } else {
                // if npObjName == tablename
                //objStr = tablename<param-list>col1^col2^col3
                npMegaObj[npObjName] = window.npGetObject(npObjName, npObjProp);
            }
        });
    }
    return npMegaObj;
};

var JumpToUrl = function (redirectUrl) {
    location.href = redirectUrl;
};

var npSave = function (pdata, url) {
    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(pdata),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        cache: false,
        crossDomain: true,
        success: function (result) {
            console.log("-------------------------");
            console.log(result);
            console.log("-------------------------");
            npAlert(result);
            //npNotification(result);
            return true;
        },
        error: function(err) {
            //console.log(err);
            return false;
        }
    });
    return true;
};

var npValidation = function (npMegaObj, npValidate) {
    return false;
};


var base_url = function() {
    console.log(location.pathname);
};

var np_submit = function (npFormControl, npValidate, url) {
    var isValid = true;
    console.log(npFormControl);
    var npMegaObj = npGetMegaObj(npFormControl);
    console.log(npMegaObj);
    if (npValidate.IsChecked) {
        isValid = npValidation(npMegaObj, npValidate);
    }
    if (!isValid) return false;
    
    return npSave(npMegaObj, url);
};


var file_submit = function (evt,url,model) {
    //Retrieve the first (and only!) File from the FileList object
    var file = $('#' + evt)[0].files[0];
    var pdata = {};
    console.log(model);
    var objName = model.ControlStr.split(npGlobalProp.npObjNameSplitter)[0];
    var propList = model.ControlStr.split(npGlobalProp.npObjNameSplitter)[1].split(npGlobalProp.npPropSplitter);
    if (file) {
        var reader = new FileReader();
        reader.onload = function(e) {
            var contents = e.target.result;
            var contArr = contents.split('\n');
            console.log('Inside file processing...');
            var testobj = [];
            $.each(contArr, function (key, value) {
                var strToArray = value.split('|');
                var temp = {};
                var j = 0;
                $.each(strToArray, function(k, v) {
                    var propName = propList[j++];
                    temp[propName] = v;
                });
                testobj.push(temp);
            });
            pdata[objName] = testobj;
            console.log(pdata);
            npSave(pdata, url);
        };
        reader.readAsText(file);
    } else {
        alert("Failed to load file");
    }
};