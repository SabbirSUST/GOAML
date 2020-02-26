using System.Collections.Generic;
using GOAML.DomainModels.Models;

namespace GOAML.Repository.IRepositories
{
    public interface IRoleTypeRepository
    {
        List<Role_type> GetRoleTypes(string entityCode);
    }
}
