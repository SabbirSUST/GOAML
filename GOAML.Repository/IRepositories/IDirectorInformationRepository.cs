using GOAML.DomainModels.GlobalVariable;

namespace GOAML.Repository.IRepositories
{
    public interface IDirectorInformationRepository
    {
        DbResponse GetDirectorInformation(long cifNumber);
    }
}
