using System.Collections.Generic;

namespace GOAML.DomainModels.LocalObjects
{
    public class DirectorInformation
    {
        public Tentity Tentity { get; set; }
        public List<Taddress> Taddress { get; set; }
        public List<Tphone> Tphone { get; set; }
        public List<TpersonIdentification> TpersonIdentification { get; set; }
        public List<DirectorDetail> DirectorDetails { get; set; }
    }
}
