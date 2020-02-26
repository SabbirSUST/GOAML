using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class Taddress
    {
        public int t_address_id { get; set; }
        public int? Address_type_id { get; set; }
        public string Address { get; set; }
        public string Town_id { get; set; }
        public string City_id { get; set; }
        public string Zip { get; set; }
        public string country_code_id { get; set; }
        public string State_id { get; set; }
        public string comments { get; set; }
        public int? t_person_my_client_id { get; set; }
        public int? entity_id { get; set; }
        public int? director_id { get; set; }
        public int? signatory_id { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
