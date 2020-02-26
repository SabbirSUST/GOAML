 
function GetIndividualInformation(searchBox, control) {
    var pdata = $('#' + searchBox).val();
    var url = 'IndividualInformation/GetIndividualInformation';
    $.ajax({
        type: 'GET',
        cache: false,
        data: { 'cifNumber': pdata },
        url: url,
        success: function (result) {
            myObject = result.ReturnValue;
            var tempObj = {};
            if (myObject == undefined) {
                ClearForm(control);
            } else {
                ClearForm(control);
                tempObj['TpersonMyClient'] = myObject.TpersonMyClient;
                SetObjects(tempObj);
                $('#Name').val(myObject.TpersonMyClient.first_name + ' ' + myObject.TpersonMyClient.middle_name + ' ' + myObject.TpersonMyClient.last_name);
                $('.t_person_my_client_id').val(myObject.TpersonMyClient.t_person_my_client_id);
                $('.TpersonMyClient').find('button.submitBtn').text("Update");
                //LoadTable(listObj, objName,tbodyClass,funcName,keyToShow,idKey)
                //LoadAddressTable(myObject.Taddress, 'Taddress');
                var addresskeys = 'Address_type_id^Address^Town_id^City_id^Zip^State_id';
                var addressIdKey = 't_address_id';
                LoadTable(myObject.Taddress, 'Taddress', 'Taddress-table', 'LoadAddress', addresskeys, addressIdKey);
                //LoadPhoneTable(myObject.Tphone, 'Tphone');
                var phonekeys = 'tph_contact_type_id^tph_communication_type_id^tph_number^tph_extension^tph_country_prefix';
                var phoneIdKey = 't_phone_id';
                LoadTable(myObject.Tphone, 'Tphone', 'Tphone-table', 'LoadPhone', phonekeys, phoneIdKey);
                //LoadIdentificationTable(myObject.TpersonIdentification, 'TpersonIdentification');
                var identificationKeys = 'type_id^number^issue_date^expiry_date^issued_by^issue_country_id';
                var identificationIdKey = 't_person_identification_id';
                LoadTable(myObject.TpersonIdentification, 'TpersonIdentification', 'TpersonIdentification-table', 'LoadIdentification', identificationKeys, identificationIdKey);
                
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}
/*
LoadIdentification(' + identificationInfo[i].t_person_identification_id + ',\'' + objName + '\');"><td class="hidden">' + identificationInfo[i].t_person_identification_id + '</td><td>' + identificationInfo[i].type_id + '</td><td>' + identificationInfo[i].number + '</td><td>' + ConvertMillisecondToDate(identificationInfo[i].issue_date) + '</td><td>' + ConvertMillisecondToDate(identificationInfo[i].expiry_date) + '</td><td>' + identificationInfo[i].issued_by + '</td><td>' + identificationInfo[i].issue_country_id 
*/
var individual_submit = function (formControl, formValidate, formUrl, controls) {
    var isSuccess = np_submit(formControl, formValidate, formUrl);
    if (isSuccess) {
        GetIndividualInformation('CifSearchBox', controls);
    }
};



// end load customer code

