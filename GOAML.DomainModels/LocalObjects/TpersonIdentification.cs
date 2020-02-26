using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class TpersonIdentification
    {
        public int t_person_identification_id { get; set; }
        public string type_id { get; set; }
        public string number { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? expiry_date { get; set; }
        public string issued_by { get; set; }
        public string issue_country_id { get; set; }
        public string comments { get; set; }
        public int? t_person_my_client_id { get; set; }
        public int? directors_id { get; set; }
        public int? entity_id { get; set; }
        public int? signatory_id { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
