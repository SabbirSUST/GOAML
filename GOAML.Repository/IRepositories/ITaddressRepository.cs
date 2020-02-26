using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.Helper;

namespace RepositoryCloud.IRepositories
{
    public interface ITaddressRepository
    {
        Taddress GetTaddress(long cifValue);
        List<Taddress> GetTaddresses(long cifValue, long directorId, Enum.SearchCriteria searchCriteria);
        DbResponse SaveTaddress(Taddress taddress);
    }
}
