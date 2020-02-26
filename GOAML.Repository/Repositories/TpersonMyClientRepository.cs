using System;
using System.Data.Entity;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;

namespace GOAML.Repository.Repositories
{
    public class TpersonMyClientRepository : ITpersonMyClientRepository
    {
        public TpersonMyClient GetTpersonMyClient(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbtPersonMyClient = dbEntities.t_person_my_client.FirstOrDefault(i => i.t_person_my_client_id == cifValue);
                    return ConvertToLocalObject(dbtPersonMyClient, new TpersonMyClient()) ?? new TpersonMyClient();
                }
            }
            catch (Exception)
            {
                return new TpersonMyClient();
            }
        }

        public DbResponse SaveTpersonMyClient(TpersonMyClient tpersonMyClient)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var toDbObject = ConvertToDbObject(tpersonMyClient, new t_person_my_client());
                    if (tpersonMyClient.t_person_my_client_id > 0)
                    {
                        toDbObject.updateBy = "System";
                        toDbObject.updateDate = System128.GetToday;
                        dbEntities.Entry(toDbObject).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_person_my_client.Add(toDbObject);
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

        public TpersonMyClient ConvertToLocalObject(t_person_my_client convertedFrom, TpersonMyClient convertedTo)
        {
            var converter = new ConvertTypeInto<t_person_my_client, TpersonMyClient>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_person_my_client ConvertToDbObject(TpersonMyClient convertedTo, t_person_my_client convertedFrom)
        {
            var converter = new ConvertTypeInto<TpersonMyClient, t_person_my_client>();
            return converter.ConvertInto(convertedTo, convertedFrom);
        }
    }
}
