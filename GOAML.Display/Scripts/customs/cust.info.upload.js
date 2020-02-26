var CustInfoUpload = function (evt, url, model) {
    //Retrieve the first (and only!) File from the FileList object
    var file = $('#' + evt)[0].files[0];
    var pdata = {};
    //var objName = model.ControlStr.split(npGlobalProp.npObjNameSplitter)[0];
    //var propList = model.ControlStr.split(npGlobalProp.npObjNameSplitter)[1].split(npGlobalProp.npPropSplitter);
    if (file) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var contents = e.target.result;
            var contArr = contents.split('\n');
            console.log('Inside file processing...');
            var testobj = [];
            $.each(contArr, function (key, value) {
                var strToArray = value.split('|');
                var temp = {};
                var j = 0;
                var tEntity = {};
                tEntity['t_entity_id'] = strToArray[6];
                tEntity['Name'] = strToArray[8];
                tEntity['CommercialName'] = strToArray[8];
                tEntity['branchId'] = strToArray[1];
                temp['Tentity'] = tEntity;
                var tAddress = {};
                tAddress['Address_type_id'] = 2;
                tAddress['Address'] = strToArray[17];
                tAddress['City_id'] = strToArray[19];
                tAddress['country_code_id'] = strToArray[21];
                tAddress['StateId'] = strToArray[19];
                tAddress['entityId'] = strToArray[6];
                temp['Taddress'] = tAddress;
                var tPhone = {};
                tPhone['tph_contact_type_id'] = 2;
                tPhone['tph_communication_type_id'] = 'L';
                tPhone['tph_number'] = strToArray[34];
                tPhone['entity_id'] = strToArray[6];
                temp['Tphone'] = tPhone;
                //$.each(strToArray, function (k, v) {
                //    var propName = propList[j++];
                //    temp[propName] = v;
                //});
                var mainObj = {};
                mainObj['CustomerInformation'] = temp;
                testobj.push(mainObj);
            });
            pdata['customerInformations'] = testobj;
            console.log(pdata);
            npSave(pdata, url);
        };
        reader.readAsText(file);
    } else {
        alert("Failed to load file");
    }
};