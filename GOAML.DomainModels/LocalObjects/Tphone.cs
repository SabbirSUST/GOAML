using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class Tphone
    {
        public int t_phone_id { get; set; }
        public int tph_contact_type_id { get; set; }
        public string tph_communication_type_id { get; set; }
        public string tph_country_prefix { get; set; }
        public string tph_number { get; set; }
        public string tph_extension { get; set; }
        public string comments { get; set; }
        public int? t_person_my_client_id { get; set; }
        public int? entity_id { get; set; }
        public int? director_id { get; set; }
        public int? signatory_id { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
