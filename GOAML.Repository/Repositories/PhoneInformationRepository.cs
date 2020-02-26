using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;
using Enum = GOAML.Repository.Helper.Enum;

namespace GOAML.Repository.Repositories
{
    public class PhoneInformationRepository: IPhoneInformationRepository
    {
        public Tphone GetPhoneInformation(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbPhoneInformation = dbEntities.t_phone.FirstOrDefault(i => i.entity_id == cifValue && i.director_id != null);
                    return ConvertToLocalObject(dbPhoneInformation, new Tphone()) ?? new Tphone();
                }
            }
            catch (Exception)
            {
                return new Tphone();
            }
        }

        public List<Tphone> GetPhoneInformations(long cifValue, long directorId,Enum.SearchCriteria searchCriteria)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbPhoneInformationList = new List<t_phone>();
                    switch (searchCriteria)
                    {
                        case Enum.SearchCriteria.ByEntity:
                            dbPhoneInformationList = dbEntities.t_phone.Where(i => i.entity_id == cifValue).ToList();
                            break;
                        case Enum.SearchCriteria.ByPersonMyClient:
                            dbPhoneInformationList = dbEntities.t_phone.Where(i => i.t_person_my_client_id == cifValue).ToList();
                            break;
                    }
                    if (directorId == -1)
                    {
                        dbPhoneInformationList = dbPhoneInformationList.Where(i => i.director_id == null).ToList();
                    }
                    var phoneInformationList = new List<Tphone>();
                    foreach (var dbPhoneInformation in dbPhoneInformationList)
                    {
                        phoneInformationList.Add(ConvertToLocalObject(dbPhoneInformation, new Tphone()));
                    }
                    return phoneInformationList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbResponse SaveTphone(Tphone tphone)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbPhoneInfo = ConvertToDbObject(tphone, new t_phone());
                    if (tphone.t_phone_id > 0)
                    {
                        dbPhoneInfo.updateBy = "System";
                        dbPhoneInfo.updateDate = System128.GetToday;
                        dbEntities.Entry(dbPhoneInfo).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_phone.Add(dbPhoneInfo);
                    }
                    dbEntities.SaveChanges();
                    return System128.SuccessMessage("Job Complete.");
                }
            }
            catch (Exception)
            {
                return System128.FailureMessage("Job Failed.");
            }
        }

        public Tphone ConvertToLocalObject(t_phone convertedFrom, Tphone convertedTo)
        {
            var converter = new ConvertTypeInto<t_phone, Tphone>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_phone ConvertToDbObject(Tphone convertedTo, t_phone convertedFrom)
        {
            var converter = new ConvertTypeInto<Tphone, t_phone>();
            return converter.ConvertInto(convertedTo, convertedFrom);
        }
    }
}
