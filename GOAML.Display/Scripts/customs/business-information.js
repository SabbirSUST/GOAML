// load customer by CIF Number code.
// address information process
function GetBusinessInformation(cifnumber,controls) {
    var pdata = $('#' + cifnumber).val();
    var url = 'BusinessInformation/GetCustomerInformation';
    $.ajax({
        type: 'GET',
        cache: true,
        data: { 'cifNumber': pdata },
        url: url,
        success: function (result) {
            myObject = result.ReturnValue;
            console.log(myObject);
            var tempObj = {};
            if (myObject == undefined) {
                ClearForm(controls);
            } else {
                $('.entity_id').val(myObject.Tentity.t_entity_id);
                tempObj['tentity'] = myObject.Tentity;
                ClearForm(controls);
                SetObjects(tempObj);
                tempObj['taddress'] = myObject.Taddress;
                tempObj['tphone'] = myObject.Tphone;
                //LoadTable(listObj, objName,tbodyClass,funcName,keyToShow,idKey)
                //LoadAddressTable(tempObj.taddress, 'taddress');
                var addresskeys = 'Address_type_id^Address^Town_id^City_id^Zip^State_id';
                var addressIdKey = 't_address_id';
                LoadTable(tempObj.taddress, 'taddress', 'Taddress-table', 'LoadAddress', addresskeys, addressIdKey);
                //LoadPhoneTable(tempObj.tphone, 'tphone');
                var phonekeys = 'tph_contact_type_id^tph_communication_type_id^tph_number^tph_extension^tph_country_prefix';
                var phoneIdKey = 't_phone_id';
                LoadTable(tempObj.tphone, 'tphone', 'Tphone-table', 'LoadPhone', phonekeys, phoneIdKey);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}
// end load customer code

var business_submit = function (formControl, formValidate, formUrl, controls) {
    //var dirId = $('.directorDetails').find('input:hidden.t_person_id').val();
    var isSuccess = np_submit(formControl, formValidate, formUrl);
    if (isSuccess) {
        GetBusinessInformation('CifSearchBox', controls);
    }
};