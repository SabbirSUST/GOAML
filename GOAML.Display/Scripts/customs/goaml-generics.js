
var myObject = {};

var LoadAddress = function (addressId, objName) {
    var tempObj = {};
    tempObj[objName] = _.select(myObject.Taddress, function (taddress) { return taddress.t_address_id == addressId; })[0];
    SetObjects(tempObj);
    $('.' + objName).find('button.submitBtn').text("Update");
};
var LoadPhone = function (phoneId, objName) {
    var tempObj = {};
    tempObj[objName] = _.select(myObject.Tphone, function (tphone) { return tphone.t_phone_id == phoneId; });
    SetObjects(tempObj);
    $('.' + objName).find('button.submitBtn').text("Update");
};
var LoadIdentification = function (identificationId, objName) {
    var tempObj = {};
    tempObj[objName] = _.select(myObject.TpersonIdentification, function (tpersonIdentification) { return tpersonIdentification.t_person_identification_id == identificationId; });
    SetObjects(tempObj);
    $('.' + objName).find('button.submitBtn').text("Update");
};

var insert = function(str, index, value) {
    return str.substr(0, index) + value + str.substr(index);
};

var LoadTable = function (listObj, objName,tbodyClass,funcName,keyToShow,idKey) {
    $('tbody.' + tbodyClass).empty();
    //load table and alsoo load first item to field.
    keyToShow = keyToShow.split('^');
    for (var i = 0; i < listObj.length; i++) {
        var tableData = '<tr>';
        console.log(listObj[i]);
        $.each(listObj[i], function (key, value) {
            if (funcName != null && key == idKey) {
                var clickstr = ' onclick="' + funcName + '(' + value + ',\'' + objName + '\');"';
                tableData = insert(tableData, 3, clickstr);
            }
            if (jQuery.inArray(key, keyToShow) > -1) {
                tableData += '<td>' + ConvertMillisecondToDate(value) + '</td>';
            }
        });
        tableData += '</tr>';
        $('tbody.' + tbodyClass).append(tableData);
    }
};



//var LoadAddressTable = function (addressInfo, objName) {
//    var tableData = '';
//    $('tbody.Taddress-table').empty();
//    //load table and alsoo load first item to field.
//    for (var i = 0; i < addressInfo.length; i++) {
//        tableData += '<tr onclick="LoadAddress(' + addressInfo[i].t_address_id + ',\'' + objName + '\');"><td class="hidden">' + addressInfo[i].t_address_id + '</td><td>' + addressInfo[i].Address_type_id + '</td><td>' + addressInfo[i].Address + '</td><td>' + addressInfo[i].Town_id + '</td><td>' + addressInfo[i].City_id + '</td><td>' + addressInfo[i].Zip + '</td><td>' + addressInfo[i].State_id + '</td><td class="hidden">' + addressInfo[i].country_code_id + '</td></tr>';
//    }
//    $('tbody.Taddress-table').append(tableData);
//};

//var LoadPhoneTable = function (phoneInfo, objName) {
//    var tableData = '';
//    $('tbody.Tphone-table').empty();
//    //load table and alsoo load first item to field.
//    for (var i = 0; i < phoneInfo.length; i++) {
//        tableData += '<tr onclick="LoadPhone(' + phoneInfo[i].t_phone_id + ',\'' + objName + '\');"><td class="hidden">' + phoneInfo[i].t_phone_id + '</td><td>' + phoneInfo[i].tph_contact_type_id + '</td><td>' + phoneInfo[i].tph_communication_type_id + '</td><td>' + phoneInfo[i].tph_number + '</td><td>' + phoneInfo[i].tph_extension + '</td><td>' + phoneInfo[i].tph_country_prefix + '</td></tr>';
//    }
//    $('tbody.Tphone-table').append(tableData);
//};

//var LoadIdentificationTable = function (identificationInfo, objName) {
//    var tableData = '';
//    console.log('-----------------------------------');
//    console.log(identificationInfo);
//    console.log('-----------------------------------');
//    $('tbody.TpersonIdentification-table').empty();
//    //load table and alsoo load first item to field.
//    for (var i = 0; i < identificationInfo.length; i++) {
//        tableData += '<tr onclick="LoadIdentification(' + identificationInfo[i].t_person_identification_id + ',\'' + objName + '\');"><td class="hidden">' + identificationInfo[i].t_person_identification_id + '</td><td>' + identificationInfo[i].type_id + '</td><td>' + identificationInfo[i].number + '</td><td>' + ConvertMillisecondToDate(identificationInfo[i].issue_date) + '</td><td>' + ConvertMillisecondToDate(identificationInfo[i].expiry_date) + '</td><td>' + identificationInfo[i].issued_by + '</td><td>' + identificationInfo[i].issue_country_id + '</td></tr>';
//    }
//    $('tbody.TpersonIdentification-table').append(tableData);
//};