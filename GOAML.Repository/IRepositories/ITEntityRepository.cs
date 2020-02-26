using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface ITEntityRepository
    {
        Tentity GetTEntity(long cifValue);
        DbResponse SaveBusinessEntity(Tentity tentity);
    }
}
