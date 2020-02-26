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
    public class PersonIdentificationRepository : IPersonIdentificationRepository
    {
        public TpersonIdentification GetPersonIdentification(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbPersonIdentification = dbEntities.t_person_identification.FirstOrDefault(i => i.entity_id == cifValue && i.directors_id != null);
                    return ConvertToLocalObject(dbPersonIdentification, new TpersonIdentification()) ?? new TpersonIdentification();
                }
            }
            catch (Exception)
            {
                return new TpersonIdentification();
            }
        }

        public List<TpersonIdentification> GetPersonIdentifications(long cifValue,Enum.SearchCriteria searchCriteria)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbPersonIdentificationList = new List<t_person_identification>();
                    switch (searchCriteria)
                    {
                        case Enum.SearchCriteria.ByEntity:
                            dbPersonIdentificationList = dbEntities.t_person_identification.Where(i => i.entity_id == cifValue).ToList();
                            break;
                        case Enum.SearchCriteria.ByPersonMyClient:
                            dbPersonIdentificationList = dbEntities.t_person_identification.Where(i => i.t_person_my_client_id == cifValue).ToList();
                            break;
                    }
                    var personIdentificationList = new List<TpersonIdentification>();
                    foreach (var dbPersonIdentification in dbPersonIdentificationList)
                    {
                        personIdentificationList.Add(ConvertToLocalObject(dbPersonIdentification, new TpersonIdentification()));
                    }
                    return personIdentificationList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbResponse SaveTpersonIdentification(TpersonIdentification tpersonIdentification)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbIdentification = ConvertToDbObject(tpersonIdentification, new t_person_identification());
                    if (tpersonIdentification.t_person_identification_id > 0)
                    {
                        dbIdentification.updateBy = "System";
                        dbIdentification.updateDate = System128.GetToday;
                        dbEntities.Entry(dbIdentification).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_person_identification.Add(dbIdentification);
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

        public TpersonIdentification ConvertToLocalObject(t_person_identification convertedFrom, TpersonIdentification convertedTo)
        {
            var converter = new ConvertTypeInto<t_person_identification, TpersonIdentification>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_person_identification ConvertToDbObject(TpersonIdentification convertedTo, t_person_identification convertedFrom)
        {
            var converter = new ConvertTypeInto<TpersonIdentification, t_person_identification>();
            return converter.ConvertInto(convertedTo, convertedFrom);
        }
    }
}
