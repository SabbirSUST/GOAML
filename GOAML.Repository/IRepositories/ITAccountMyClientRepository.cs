using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface ITAccountMyClientRepository
    {
        TaccountMyClient GetTaccountMyClient(string cifNumber);
        DbResponse SaveTaccountMyClient(TaccountMyClient taccountMyClient);
        //DbResponse SaveTaccountMyClientInBatch(List<TaccountMyClient> taccountMyClients);
        DbResponse SaveTaccountMyClientInBatch(string taccountMyClients);
        DbResponse SaveCustomerInformationInBatch(string customerInforStr);
    }
}
