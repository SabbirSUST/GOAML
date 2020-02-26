using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;
using Enum = GOAML.Repository.Helper.Enum;

namespace GOAML.Repository.Repositories
{
    public class BusinessInfoRepository : IBusinessInfoRepository
    {
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly ITEntityRepository _tEntityRepository;
        private readonly ITaddressRepository _taddressRepository;

        public BusinessInfoRepository(ITEntityRepository tEntityRepository, ITaddressRepository taddressRepository, IPhoneInformationRepository phoneInformationRepository)
        {
            _tEntityRepository = tEntityRepository;
            _taddressRepository = taddressRepository;
            _phoneInformationRepository = phoneInformationRepository;
        }

        public DbResponse GetBusinessInformation(long cifNumber)
        {
            var tEntity = _tEntityRepository.GetTEntity(cifNumber);
            var phoneInfo = _phoneInformationRepository.GetPhoneInformations(cifNumber, -1, Enum.SearchCriteria.ByEntity);
            var tAddress = _taddressRepository.GetTaddresses(cifNumber,-1,Enum.SearchCriteria.ByEntity);
            var directoryInformation = new BusinessInformation {  Taddress = tAddress, Tentity = tEntity, Tphone = phoneInfo };
            //var directoryInformation = new DirectorInformation { DirectorDetails = director, Tphone = phoneInfo, TpersonIdentification = pIdentity };
            return System128.SuccessMessage(directoryInformation);
        }
        
    }
}
