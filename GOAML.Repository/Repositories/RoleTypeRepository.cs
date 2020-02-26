using System;
using System.Collections.Generic;
using System.Linq;
using GOAML.DomainModels.Models;
using GOAML.Repository.IRepositories;

namespace GOAML.Repository.Repositories
{
    public class RoleTypeRepository: IRoleTypeRepository
    {
        public List<Role_type> GetRoleTypes(string entityCode)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbRoleTypes = dbEntities.Role_type.Where(i => i.entityCode == entityCode).ToList();
                    return dbRoleTypes;
                }
            }
            catch (Exception)
            {
                return new List<Role_type>();
            }
        }
    }
}
