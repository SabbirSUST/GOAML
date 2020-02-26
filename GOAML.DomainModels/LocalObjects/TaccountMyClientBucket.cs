using System.Collections.Generic;

namespace GOAML.DomainModels.LocalObjects
{
    public class TaccountMyClientBucket
    {
        public TaccountMyClient TaccountMyClient{ get; set; }
        public SignatoryInfo SignatoryInfo { get; set; }
        public List<DirectorDetail> DirectorDetails { get; set; }
        public List<SignatoryInfo> SignatoryInfos { get; set; } 
    }
}
