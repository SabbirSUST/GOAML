using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using RepositoryCloud.IRepositories;
using Enum = GOAML.Repository.Helper.Enum;

namespace GOAML.Repository.Repositories
{
    public class TaddressRepository : ITaddressRepository
    {
        public Taddress GetTaddress(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbtAddress = dbEntities.t_address.FirstOrDefault(i => i.entity_id == cifValue && i.director_id != null);
                    return ConvertToLocalObject(dbtAddress, new Taddress()) ?? new Taddress();
                }
            }
            catch (Exception)
            {
                return new Taddress();
            }
        }

        public List<Taddress> GetTaddresses(long cifValue, long directorId, Enum.SearchCriteria searchCriteria)
        {
            try
            {
                var dbTaddressList = new List<t_address>();
                using (var dbEntities = new GOAMLEntities())
                {
                    switch (searchCriteria)
                    {
                        case Enum.SearchCriteria.ByEntity:
                            dbTaddressList = dbEntities.t_address.Where(i => i.entity_id == cifValue).ToList();
                            break;
                        case Enum.SearchCriteria.ByPersonMyClient:
                            dbTaddressList = dbEntities.t_address.Where(i => i.t_person_my_client_id == cifValue).ToList();
                            break;
                    }
                    if (directorId == -1)
                    {
                        dbTaddressList = dbTaddressList.Where(i => i.director_id == null).ToList();
                    }
                    
                    var tAddressList = new List<Taddress>();
                    foreach (var dbTaddress in dbTaddressList)
                    {
                        tAddressList.Add(ConvertToLocalObject(dbTaddress, new Taddress()));
                    }
                    return tAddressList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbResponse SaveTaddress(Taddress taddress)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbTaddress = ConvertToDbObject(taddress, new t_address());
                    if (taddress.t_address_id > 0)
                    {
                        dbTaddress.updateBy = "System";
                        dbTaddress.updateDate = System128.GetToday;
                        dbEntities.Entry(dbTaddress).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_address.Add(dbTaddress);
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

        public Taddress ConvertToLocalObject(t_address convertedFrom, Taddress convertedTo)
        {
            var converter = new ConvertTypeInto<t_address, Taddress>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_address ConvertToDbObject(Taddress convertedTo, t_address convertedFrom)
        {
            var converter = new ConvertTypeInto<Taddress, t_address>();
            return converter.ConvertInto(convertedTo, convertedFrom);
        }
    }
}
