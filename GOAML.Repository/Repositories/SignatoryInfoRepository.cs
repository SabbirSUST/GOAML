using System;
using System.Collections.Generic;
using System.Linq;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.Models;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.Helper;
using GOAML.Repository.IRepositories;
using SignatoryInfo = GOAML.DomainModels.LocalObjects.SignatoryInfo;

namespace GOAML.Repository.Repositories
{
    public class SignatoryInfoRepository : ISignatoryInfoRepository
    {
        public SignatoryInfo GetSignatoryInfo(string cifNumber)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbSignatoryInfo = dbEntities.SignatoryInfoes.FirstOrDefault(i => i.accountNumber == cifNumber);
                    return ConvertToLocalObject(dbSignatoryInfo, new SignatoryInfo()) ?? new SignatoryInfo();
                }
            }
            catch (Exception)
            {
                return new SignatoryInfo();
            }
        }

        public List<SignatoryInfo> GetSignatoryInfoList(string cifNumber)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbSignatories = dbEntities.SignatoryInfoes.Where(i => i.accountNumber == cifNumber).ToList();
                    var signatoryInfoList = new List<SignatoryInfo>();
                    foreach (var signatoryInfo in dbSignatories)
                    {
                        signatoryInfoList.Add(ConvertToLocalObject(signatoryInfo, new SignatoryInfo()));
                    }
                    return signatoryInfoList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DbResponse SaveSignatoryInfo(SignatoryInfo signatoryInfo)
        {
            try
            {
                using (var dbEntities = new GOAMLEntities())
                {
                    var dbObj = ConvertToDbObject(signatoryInfo, new DomainModels.Models.SignatoryInfo());
                    dbEntities.SignatoryInfoes.Add(dbObj);
                    dbEntities.SaveChanges();
                    return System128.SuccessMessage(dbObj.accountNumber);
                }
            }
            catch (Exception exception)
            {
                return System128.ExceptionMessage(exception);
            }
        }

        public SignatoryInfo ConvertToLocalObject(DomainModels.Models.SignatoryInfo convertedFrom, SignatoryInfo convertedTo)
        {
            var converter = new ConvertTypeInto<DomainModels.Models.SignatoryInfo, SignatoryInfo>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }

        public DomainModels.Models.SignatoryInfo ConvertToDbObject(SignatoryInfo convertedFrom, DomainModels.Models.SignatoryInfo convertedTo)
        {
            var converter = new ConvertTypeInto<SignatoryInfo, DomainModels.Models.SignatoryInfo>();
            return converter.ConvertInto(convertedFrom, convertedTo);
        }
    }
}
