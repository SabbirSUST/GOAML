using GOAML.DomainModels.GlobalVariable;

namespace GOAML.Repository.IRepositories
{
    public interface IIndividualInformationRepository
    {
        DbResponse GetIndividualInformation(long cifNumber);
    }
}
