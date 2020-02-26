using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface IAccountInfoUpdateRepository
    {
        DbResponse GetAccountInfoUpdate(string cifNumber);
        DbResponse SaveAccountInfoUpdate(TaccountMyClientBucket taccountMyClientBucket);
    }
}
