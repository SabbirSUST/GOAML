using System;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;
using Enum = GOAML.Repository.Helper.Enum;

namespace GOAML.Repository.Repositories
{
    public class AccountInfoUpdateRepository : IAccountInfoUpdateRepository
    {
        private readonly ISignatoryInfoRepository _signatoryInfoRepository;
        private readonly ITAccountMyClientRepository _accountMyClientRepository;
        private readonly IDirectorRepository _directorRepository;

        public AccountInfoUpdateRepository(IDirectorRepository directorRepository, ITAccountMyClientRepository accountMyClientRepository, ISignatoryInfoRepository signatoryInfoRepository)
        {
            _directorRepository = directorRepository;
            _accountMyClientRepository = accountMyClientRepository;
            _signatoryInfoRepository = signatoryInfoRepository;
        }

        public DbResponse GetAccountInfoUpdate(string cifNumber)
        {
            try
            {
                var accInfoUpdate = new TaccountMyClientBucket();
                accInfoUpdate.TaccountMyClient = _accountMyClientRepository.GetTaccountMyClient(cifNumber);
                if (accInfoUpdate.TaccountMyClient == null) return System128.SuccessMessage(new TaccountMyClientBucket());
                accInfoUpdate.SignatoryInfos = _signatoryInfoRepository.GetSignatoryInfoList(cifNumber);
                accInfoUpdate.DirectorDetails = _directorRepository.GetDirectors(Convert.ToInt64(accInfoUpdate.TaccountMyClient.t_entity_id));
                return System128.SuccessMessage(accInfoUpdate);
            }
            catch (Exception)
            {
                return System128.SuccessMessage(new TaccountMyClientBucket());
            }
        }

        public DbResponse SaveAccountInfoUpdate(TaccountMyClientBucket taccountMyClientBucket)
        {
            taccountMyClientBucket.TaccountMyClient.updateBy = "System";
            taccountMyClientBucket.TaccountMyClient.updateDate = System128.GetToday;
            var response = _accountMyClientRepository.SaveTaccountMyClient(taccountMyClientBucket.TaccountMyClient);
            if (response.MessageType != (int) Enum.ResponseCode.Success) return System128.FailureMessage(0);
            taccountMyClientBucket.SignatoryInfo.accountNumber = taccountMyClientBucket.TaccountMyClient.Account;
            if (taccountMyClientBucket.TaccountMyClient.entityCode == "C")
            {
                response = _signatoryInfoRepository.SaveSignatoryInfo(taccountMyClientBucket.SignatoryInfo);
            }
            return response;
        }
    }
}
