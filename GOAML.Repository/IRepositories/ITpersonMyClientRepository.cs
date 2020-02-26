using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface ITpersonMyClientRepository
    {
        TpersonMyClient GetTpersonMyClient(long cifValue);
        DbResponse SaveTpersonMyClient(TpersonMyClient tentity);
    }
}
