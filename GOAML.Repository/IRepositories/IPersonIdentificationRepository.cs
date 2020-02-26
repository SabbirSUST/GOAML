using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.Helper;

namespace GOAML.Repository.IRepositories
{
    public interface IPersonIdentificationRepository
    {
        TpersonIdentification GetPersonIdentification(long cifValue);
        List<TpersonIdentification> GetPersonIdentifications(long cifValue, Enum.SearchCriteria searchCriteria);
        DbResponse SaveTpersonIdentification(TpersonIdentification tpersonIdentification);
    }
}
