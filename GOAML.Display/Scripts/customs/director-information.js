// load director by CIF Number code.
var personName = "";
function GetDirectorInformation(cifValue, controls, callback) {
    //alertify.alert('Director Information Loaded!');
    var pdata = $('#' + cifValue).val();
    var url = 'DirectorInformation/GetDirectorInformation';
    var pOptionValues = '';
    $.ajax({
        type: 'GET',
        cache: true,
        data: { 'cifNumber': pdata },
        url: url,
        success: function (result) {
            window.myObject = result.ReturnValue;
            $('#Name').val(window.myObject.Tentity.Name);
            var inputId = 'Director';
            var requiredField = 't_person_id^first_name';
            GenerateDropDownList(myObject.DirectorDetails, inputId, requiredField);
            ClearForm(controls);
            $('.entity_id').val(pdata);
            $('.director-name').val('');
            $('.director_id').val('');
            $('.tab-content').find('button.submitBtn').text("Save");
            if (typeof (callback) == 'function') {
                callback();
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
    
}

function GetDirectorDetails(directorId,controls) {
    if (myObject == undefined) {
        ClearForm(controls);
    } else {
        ClearForm(controls);
        $('.tab-content').find('button.submitBtn').text("Save");
        var tempObject = {};
        tempObject['directorDetails'] = _.select(myObject.DirectorDetails, function (directorDetail) { return directorDetail.t_person_id == directorId; })[0];
        var tempTable = _.select(myObject.Taddress, function(taddress) { return taddress.director_id == directorId; });
        tempTable['taddress'] = _.select(myObject.Taddress, function (taddress) { return taddress.director_id == directorId; });
        tempTable['tphone'] = _.select(myObject.Tphone, function (tphone) { return tphone.director_id == directorId; });
        tempTable['tpersonIdentification'] = _.select(myObject.TpersonIdentification, function (tpersonIdentification) { return tpersonIdentification.directors_id == directorId; });
        //console.log(tempObject);
        personName = tempObject.directorDetails.Title + ' ' + tempObject.directorDetails.first_name + ' ' + tempObject.directorDetails.middle_name + ' ' + tempObject.directorDetails.last_name;
        $('.director-name').val(personName);
        $('.director_id').val(directorId);
        $('.directorDetails').find('button.submitBtn').text("Update");
        SetObjects(tempObject);
        //LoadTable(listObj, objName,tbodyClass,funcName,keyToShow,idKey)
        //LoadAddressTable(tempTable.taddress, 'taddress');
        var addresskeys = 'Address_type_id^Address^Town_id^City_id^Zip^State_id';
        var addressIdKey = 't_address_id';
        LoadTable(tempTable.taddress, 'taddress', 'Taddress-table', 'LoadAddress', addresskeys, addressIdKey);
        //LoadPhoneTable(tempTable.tphone, 'tphone');
        var phonekeys = 'tph_contact_type_id^tph_communication_type_id^tph_number^tph_extension^tph_country_prefix';
        var phoneIdKey = 't_phone_id';
        LoadTable(tempTable.tphone, 'tphone', 'Tphone-table', 'LoadPhone', phonekeys, phoneIdKey);
        //LoadIdentificationTable(tempTable.tpersonIdentification, 'tpersonIdentification');
        var identificationKeys = 'type_id^number^issue_date^expiry_date^issued_by^issue_country_id';
        var identificationIdKey = 't_person_identification_id';
        LoadTable(tempTable.tpersonIdentification, 'tpersonIdentification', 'TpersonIdentification-table', 'LoadIdentification', identificationKeys, identificationIdKey);
    }
}

var director_submit = function (formControl, formValidate, formUrl, controls) {
    var dirId = $('.directorDetails').find('input:hidden.t_person_id').val();
    var isSuccess = np_submit(formControl, formValidate, formUrl);
    if (isSuccess) {
        GetDirectorInformation('CifSearchBox', controls, function () {
            GetDirectorDetails(dirId, controls);
        });
    }
};
// end load director code