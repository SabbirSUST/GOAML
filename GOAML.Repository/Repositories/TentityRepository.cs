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
    public class TentityRepository : ITEntityRepository
    {
        public Tentity GetTEntity(long cifValue)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbTentities = dbEntities.t_entity.FirstOrDefault(i => i.t_entity_id == cifValue);
                    return ConvertToLocalObject(dbTentities, new Tentity()) ?? new Tentity();
                }
            }
            catch (Exception)
            {
                return new Tentity();
            }
        }

        public DbResponse SaveBusinessEntity(Tentity tentity)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var tEntity = ConvertToDbObject(tentity, new t_entity());
                    if (tentity.t_entity_id > 0)
                    {
                        tEntity.updateBy = "System";
                        tEntity.updateDate = System128.GetToday;
                        dbEntities.Entry(tEntity).State = EntityState.Modified;
                    }
                    else
                    {
                        dbEntities.t_entity.Add(tEntity);
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

        public Tentity ConvertToLocalObject(t_entity convertedFrom, Tentity convertedTo)
        {
            var converter = new ConvertTypeInto<t_entity, Tentity>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public t_entity ConvertToDbObject(Tentity convertedTo, t_entity convertedFrom)
        {
            var converter = new ConvertTypeInto<Tentity, t_entity>();
            return converter.ConvertInto(convertedTo, convertedFrom);
        }
    }
}
