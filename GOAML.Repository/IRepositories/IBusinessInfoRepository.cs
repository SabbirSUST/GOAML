using GOAML.DomainModels.GlobalVariable;

namespace GOAML.Repository.IRepositories
{
    public interface IBusinessInfoRepository
    {
        DbResponse GetBusinessInformation(long cifNumber);
    }
}
