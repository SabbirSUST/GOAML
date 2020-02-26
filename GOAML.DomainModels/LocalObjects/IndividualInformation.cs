using System.Collections.Generic;

namespace GOAML.DomainModels.LocalObjects
{
    public class IndividualInformation
    {
        public TpersonMyClient TpersonMyClient { get; set; }
        public List<Taddress> Taddress { get; set; }
        public List<Tphone> Tphone { get; set; }
        public List<TpersonIdentification> TpersonIdentification { get; set; }
        
    }
}
