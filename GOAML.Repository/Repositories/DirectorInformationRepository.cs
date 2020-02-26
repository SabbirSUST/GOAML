using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;

namespace GOAML.Repository.Repositories
{
    public class DirectorInformationRepository : IDirectorInformationRepository
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IPersonIdentificationRepository _personIdentificationRepository;
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly ITEntityRepository _tEntityRepository;
        private readonly ITaddressRepository _taddressRepository;

        public DirectorInformationRepository(ITaddressRepository taddressRepository, ITEntityRepository tEntityRepository, IPhoneInformationRepository phoneInformationRepository, IPersonIdentificationRepository personIdentificationRepository, IDirectorRepository directorRepository)
        {
            _taddressRepository = taddressRepository;
            _tEntityRepository = tEntityRepository;
            _phoneInformationRepository = phoneInformationRepository;
            _personIdentificationRepository = personIdentificationRepository;
            _directorRepository = directorRepository;
        }

        public DbResponse GetDirectorInformation(long cifNumber)
        {
            var tEntity = _tEntityRepository.GetTEntity(cifNumber);
            var director = _directorRepository.GetDirectors(cifNumber);
            var pIdentity = _personIdentificationRepository.GetPersonIdentifications(cifNumber, Enum.SearchCriteria.ByEntity);
            var phoneInfo = _phoneInformationRepository.GetPhoneInformations(cifNumber,1,Enum.SearchCriteria.ByEntity);
            var tAddress = _taddressRepository.GetTaddresses(cifNumber, 1, Enum.SearchCriteria.ByEntity);
            var directoryInformation = new DirectorInformation { DirectorDetails = director, Taddress = tAddress, Tentity = tEntity, Tphone = phoneInfo, TpersonIdentification = pIdentity };
            //var directoryInformation = new DirectorInformation { DirectorDetails = director, Tphone = phoneInfo, TpersonIdentification = pIdentity };
            return System128.SuccessMessage(directoryInformation);
        }
    }
}
