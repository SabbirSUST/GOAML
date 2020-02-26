using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class Tentity
    {
        public long Id { get; set; }
        public int t_entity_id { get; set; }
        public string Name { get; set; }
        public string Commercial_name { get; set; }
        public string Incorporation_legal_form_id { get; set; }
        public string incorporation_number { get; set; }
        public string Business { get; set; }
        public string Email { get; set; }
        public string url { get; set; }
        public string incorporation_state { get; set; }
        public string incorporation_country_code { get; set; }
        public string incorporation_date { get; set; }
        public string business_closed { get; set; }
        public string date_business_closed { get; set; }
        public string tax_numebr { get; set; }
        public string tax_registeration_number { get; set; }
        public string comments { get; set; }
        public int? branchId { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
