using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;
using SignatoryInfo = GOAML.DomainModels.Models.SignatoryInfo;

namespace GOAML.Repository.Repositories
{
    public class TaccountMyClientRepository : ITAccountMyClientRepository
    {
        public TaccountMyClient GetTaccountMyClient(string cifNumber)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbtAccountMyClient = dbEntities.t_account_my_client.FirstOrDefault(i => i.Account == cifNumber);
                    return ConvertToLocalObject(dbtAccountMyClient, new TaccountMyClient()) ?? new TaccountMyClient();
                }
            }
            catch (Exception)
            {
                return new TaccountMyClient();
            }
        }

        public DbResponse SaveTaccountMyClient(TaccountMyClient taccountMyClient)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbObj = ConvertToDbObject(taccountMyClient, new t_account_my_client());
                    if (taccountMyClient.t_account_my_client_id > 0)
                    {
                        dbEntities.Entry(dbObj).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_account_my_client.Add(dbObj);
                    }
                    dbEntities.SaveChanges();
                    return System128.SuccessMessage(dbObj.t_account_my_client_id);
                }
            }
            catch (Exception exception)
            {
                return System128.ExceptionMessage(exception);
            }
        }

        public DbResponse SaveTaccountMyClientInBatch(List<TaccountMyClient> taccountMyClients)
        {
            try
            {
                //using (var transactionScope = new TransactionScope(tra))
                //{
                using (var dbEntities = new GOAMLEntities())
                {
                    var totalUploaded = 0;
                    var dbTAccountMyClient = dbEntities.t_account_my_client.ToList();
                    foreach (var taccountMyClient in taccountMyClients)
                    {
                        if (dbTAccountMyClient.Any(i => i.Account == taccountMyClient.Account) || taccountMyClient.status_code_id == "CLS") continue;
                        taccountMyClient.Instituation_name = "Woori Bank";
                        taccountMyClient.institution_code = "2721";
                        taccountMyClient.swift = "HVBKBDDH";
                        taccountMyClient.Non_banking_institution = "N";
                        taccountMyClient.status_code_id = "A";
                        if (taccountMyClient.entityCode == "I")
                            taccountMyClient.t_person_Id = taccountMyClient.t_person_Id;
                        else
                            taccountMyClient.t_entity_id = taccountMyClient.t_person_Id;
                        taccountMyClient.personal_account_type_id =
                            ConvertPersonalAccountType(taccountMyClient.personal_account_type_id);
                        var dbObj = ConvertToDbObject(taccountMyClient, new t_account_my_client());
                        dbEntities.t_account_my_client.Add(dbObj);
                        var signInfo = new SignatoryInfo();
                        signInfo.accountNumber = taccountMyClient.Account;
                        signInfo.signatorId = taccountMyClient.t_person_Id;
                        signInfo.isprimary = "Y";
                        dbEntities.SignatoryInfoes.Add(signInfo);
                        totalUploaded++;
                    }
                    dbEntities.SaveChanges();
                    return System128.SuccessMessage(totalUploaded + " row inserted.");
                }
                //transactionScope.Complete();

                //}
            }
            catch (Exception exception)
            {
                return System128.ExceptionMessage(exception);
            }
        }

        public DbResponse SaveTaccountMyClientInBatch(string taccountMyClients)
        {
            try
            {
                //using (var transactionScope = new TransactionScope(tra))
                //{
                using (var dbEntities = new GOAMLEntities())
                {
                    var count = 0;
                    var totalUploaded = 0;
                    var numExecute = 0;
                    var dbTAccountMyClient = dbEntities.t_account_my_client.ToList();
                    var cusInfoArr = taccountMyClients.Split('\n');
                    foreach (var cusInfo in cusInfoArr)
                    {
                        var cusObj = cusInfo.Split('|');
                        if (cusObj.Length < 20) continue;
                        if (dbTAccountMyClient.Any(i => i.Account == cusObj[4]) || cusObj[9] == "CLS") continue;
                        var ntaccountMyClient = new t_account_my_client
                        {
                            Instituation_name = "Woori Bank",
                            institution_code = "2721",
                            swift = "HVBKBDDH",
                            Non_banking_institution = "N",
                            status_code_id = "A",
                            Account = cusObj[4],
                            account_name = cusObj[5],
                            opened = Convert.ToDateTime(cusObj[2]),
                            entityCode = cusObj[18]
                        };

                        if (cusObj[18] == "I")
                            ntaccountMyClient.t_person_Id = Convert.ToInt32(cusObj[17]);
                        else
                            ntaccountMyClient.t_entity_id = Convert.ToInt32(cusObj[17]);
                        ntaccountMyClient.personal_account_type_id =
                            ConvertPersonalAccountType(cusObj[3]);
                        //var dbObj = ConvertToDbObject(taccountMyClient, new t_account_my_client());
                        dbEntities.t_account_my_client.Add(ntaccountMyClient);
                        var signInfo = new SignatoryInfo
                        {
                            accountNumber = ntaccountMyClient.Account,
                            signatorId = ntaccountMyClient.t_person_Id,
                            isprimary = "Y"
                        };
                        dbEntities.SignatoryInfoes.Add(signInfo);
                        dbEntities.SaveChanges();
                        totalUploaded++;
                    }
                    
                    return System128.SuccessMessage(totalUploaded + " row inserted.");
                }
                //transactionScope.Complete();

                //}
            }
            catch (Exception exception)
            {
                return System128.ExceptionMessage(exception);
            }
        }
        public DbResponse SaveCustomerInformationInBatch(string customerInforStr)
        {
            var count = 0;
            var totalUploaded = 0;
            var numExecute = 0;
            var dbEntities = new GOAMLEntities();
            try
            {
                var cusInfoArr = customerInforStr.Split('\n');
                var dbTentities = dbEntities.t_entity.ToList();
                var dbTpersonMyClient = dbEntities.t_person_my_client.ToList();
                foreach (var cusInfo in cusInfoArr)
                {
                    if (cusInfoArr.Length == count) continue;
                    count++;
                    var cusObj = cusInfo.Split('|');
                    // if cusinfo is not valid data or not contain any "|"
                    if (cusObj.Length < 53) continue;
                    var entityCode = cusObj[53];
                    var tEntityId = Convert.ToInt32(cusObj[6]);
                    // if entity code is null
                    if (string.IsNullOrEmpty(entityCode)) continue;
                    if (entityCode == "B" || entityCode == "C")
                    {
                        if (dbTentities.Any(i => i.t_entity_id == tEntityId)) continue;
                        var tEntity = GetTEntityFromArray(tEntityId, cusObj);
                        dbEntities.t_entity.Add(tEntity);
                        dbTentities.Add(tEntity);
                    }
                    if (entityCode == "I")
                    {
                        if (dbTpersonMyClient.Any(i => i.t_person_my_client_id == tEntityId)) continue;
                        var personMyClient = GetTPersonMyClientFromArray(cusObj, tEntityId);
                        dbEntities.t_person_my_client.Add(personMyClient);
                        dbTpersonMyClient.Add(personMyClient);
                    }
                    var tAddress = GetTAddressFromArray(cusObj, tEntityId);
                    dbEntities.t_address.Add(tAddress);
                    var tPhone = GetTPhoneFromArray(cusObj, tEntityId);
                    dbEntities.t_phone.Add(tPhone);
                    totalUploaded++;
                    numExecute++;
                    if (numExecute == 50)
                    {
                        dbEntities.SaveChanges();
                        dbEntities.Dispose();
                        dbEntities = new GOAMLEntities();
                        numExecute = 0;
                    }
                }
                return System128.SuccessMessage(totalUploaded + " row inserted.");
            }
            catch (Exception exception)
            {
                //dbTransaction.Rollback();
                return System128.ExceptionMessage(exception);
            }
        }

        private static t_phone GetTPhoneFromArray(string[] cusObj, int tEntityId)
        {
            var tPhone = new t_phone
            {
                tph_contact_type_id = 2,
                tph_communication_type_id = "L",
                tph_number = cusObj[34],
                entity_id = tEntityId
            };
            return tPhone;
        }

        private static t_entity GetTEntityFromArray(int tEntityId, string[] cusObj)
        {
            var tEntity = new t_entity
            {
                t_entity_id = tEntityId,
                Name = cusObj[8],
                Commercial_name = cusObj[8],
                branchId = Convert.ToInt32(cusObj[1])
            };
            return tEntity;
        }

        private static t_person_my_client GetTPersonMyClientFromArray(string[] cusObj, int tEntityId)
        {
            var names = cusObj[8];
            var nameArr = Regex.Split(names, @"\s+");
            var firstName = nameArr[0];
            var lastName = nameArr[nameArr.Length - 1];
            var midName = "";
            if (nameArr.Length > 2)
            {
                midName = nameArr[1];
            }
            var personMyClient = new t_person_my_client
            {
                t_person_my_client_id = tEntityId,
                branchId = Convert.ToInt32(cusObj[1]),
                first_name = firstName,
                last_name = lastName,
                middle_name = midName
            };
            return personMyClient;
        }

        private static t_address GetTAddressFromArray(string[] cusObj, int tEntityId)
        {
            var tAddress = new t_address
            {
                Address_type_id = 2,
                Address = cusObj[17],
                City_id = cusObj[19],
                country_code_id = cusObj[21],
                State_id = cusObj[19],
                entity_id = tEntityId
            };
            return tAddress;
        }

        private static string ConvertPersonalAccountType(string personalAccountTypeId)
        {
            switch (personalAccountTypeId)
            {
                case "CDA":
                    return "D";
                case "DDA":
                    return "S";
                case "NDA":
                    return "P";
                case "TDA":
                    return "T";
                case "MOB":
                    return "E";
                case "RQA":
                    return "N";
            }
            return "";
        }

        public TaccountMyClient ConvertToLocalObject(t_account_my_client convertedFrom, TaccountMyClient convertedTo)
        {
            var converter = new ConvertTypeInto<t_account_my_client, TaccountMyClient>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_account_my_client ConvertToDbObject(TaccountMyClient convertedFrom, t_account_my_client convertedTo)
        {
            var converter = new ConvertTypeInto<TaccountMyClient, t_account_my_client>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }
    }
}
