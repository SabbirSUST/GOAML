using System.Collections.Generic;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;

namespace GOAML.Repository.IRepositories
{
    public interface ISignatoryInfoRepository
    {
        SignatoryInfo GetSignatoryInfo(string cifNumber);
        List<SignatoryInfo> GetSignatoryInfoList(string cifNumber);
        DbResponse SaveSignatoryInfo(SignatoryInfo signatoryInfo);
    }
}
