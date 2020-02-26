using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface IDirectorRepository
    {
        DirectorDetail GetDirector(long cifValue);
        List<DirectorDetail> GetDirectors(long cifValue);
        DbResponse SaveDirectorDetails(DirectorDetail directorDetail);
    }
}
