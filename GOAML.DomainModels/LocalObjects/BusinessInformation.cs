using System.Collections.Generic;

namespace GOAML.DomainModels.LocalObjects
{
    public class BusinessInformation
    {
        public Tentity Tentity { get; set; }
        public List<Taddress> Taddress { get; set; }
        public List<Tphone> Tphone { get; set; }
    }
}
