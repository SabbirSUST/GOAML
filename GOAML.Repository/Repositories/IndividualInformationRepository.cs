using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;

namespace GOAML.Repository.Repositories
{
    public class IndividualInformationRepository : IIndividualInformationRepository
    {
        private readonly ITpersonMyClientRepository _tpersonMyClientRepository;
        private readonly IPersonIdentificationRepository _personIdentificationRepository;
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly ITaddressRepository _taddressRepository;

        public IndividualInformationRepository(ITaddressRepository taddressRepository, IPhoneInformationRepository phoneInformationRepository, IPersonIdentificationRepository personIdentificationRepository, ITpersonMyClientRepository tpersonMyClientRepository)
        {
            _taddressRepository = taddressRepository;
            _phoneInformationRepository = phoneInformationRepository;
            _personIdentificationRepository = personIdentificationRepository;
            _tpersonMyClientRepository = tpersonMyClientRepository;
        }

        public DbResponse GetIndividualInformation(long cifNumber)
        {
            var tPersonMyClient = _tpersonMyClientRepository.GetTpersonMyClient(cifNumber);
            var pIdentity = _personIdentificationRepository.GetPersonIdentifications(cifNumber,Enum.SearchCriteria.ByPersonMyClient);
            var phoneInfo = _phoneInformationRepository.GetPhoneInformations(cifNumber, 1, Enum.SearchCriteria.ByPersonMyClient);
            var tAddress = _taddressRepository.GetTaddresses(cifNumber, 1, Enum.SearchCriteria.ByPersonMyClient);
            var directoryInformation = new IndividualInformation { Taddress = tAddress, TpersonMyClient = tPersonMyClient, Tphone = phoneInfo, TpersonIdentification = pIdentity };
            //var directoryInformation = new DirectorInformation { DirectorDetails = director, Tphone = phoneInfo, TpersonIdentification = pIdentity };
            return System128.SuccessMessage(directoryInformation);
        }
    }
}
