// load customer by CIF Number code.
// address information process

var LoadSignatoryTable = function (signatoryObj) {
    var tableData = '';
    $('tbody.signatory-table').empty();
    var isPrimary = '';
    //load table and alsoo load first item to field.
    for (var i = 0; i < signatoryObj.length; i++) {
        if (signatoryObj[i].isprimary == 'Y') isPrimary = 'PRIMARY';
        else isPrimary = 'NOT PRIMARY';
        var director = _.where(myObject.DirectorDetails, { t_person_id: signatoryObj[i].director_id });
        console.log(director);
        var directorName = '';
        if (director.length > 0) {
            directorName = director[0].first_name + ' ' + director[0].middle_name + ' ' + director[0].last_name;
        }
        tableData += '<tr><td>' + directorName + '</td><td>' + isPrimary + '</td></tr>';
    }
    $('tbody.signatory-table').append(tableData);
};

function GetCustomerInfo(cifnumber, controls) {
    var pdata = $('#' + cifnumber).val();
    var url = 'GetCustomerInfo';
    $.ajax({
        type: 'GET',
        cache: false,
        data: { 'cifNumber': pdata },
        url: url,
        success: function (result) {
            myObject = result.ReturnValue;
            console.log(myObject);
            var tempObj = {};
            if (myObject == undefined) {
                ClearForm(controls);
            } else {
                //TaccountMyClient, SignatoryInfos, DirectorDetails
                tempObj['TaccountMyClient'] = myObject.TaccountMyClient;
                ClearForm(controls);
                SetObjects(tempObj);
                GenerateDropDownList(myObject.DirectorDetails, 'director_id', 't_person_id^first_name');
                //var keyToShow = 'director_id^isprimary';
                //var idKey = 'sign_Id';
                LoadSignatoryTable(myObject.SignatoryInfos);
                $('.t_account_my_clients').find('button.submitBtn').text("Update");
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
};
// end load customer code

var cusUpdate_submit = function (formControl, formValidate, formUrl, controls) {
    //var dirId = $('.directorDetails').find('input:hidden.t_person_id').val();
    var isSuccess = np_submit(formControl, formValidate, formUrl);
    if (isSuccess) {
        GetCustomerInfo('CifSearchBox', controls);
    }
};