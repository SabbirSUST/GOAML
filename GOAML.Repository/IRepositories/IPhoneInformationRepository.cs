using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.Helper;

namespace GOAML.Repository.IRepositories
{
    public interface IPhoneInformationRepository
    {
        Tphone GetPhoneInformation(long cifValue);
        List<Tphone> GetPhoneInformations(long cifValue, long directorId, Enum.SearchCriteria searchCriteria);
        DbResponse SaveTphone(Tphone tphone);
    }
}
