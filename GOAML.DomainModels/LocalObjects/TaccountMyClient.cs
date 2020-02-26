using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class TaccountMyClient
    {
        public int t_account_my_client_id { get; set; }
        public string Instituation_name { get; set; }
        public string institution_code { get; set; }
        public string swift { get; set; }
        public string Non_banking_institution { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
        public string currency_code_id { get; set; }
        public string account_name { get; set; }
        public string iban { get; set; }
        public string client_number { get; set; }
        public string personal_account_type_id { get; set; }
        public int? t_entity_id { get; set; }
        public DateTime? opened { get; set; }
        public DateTime? closed { get; set; }
        public string status_code_id { get; set; }
        public string beneficiary { get; set; }
        public string beneficiary_comment { get; set; }
        public string comments { get; set; }
        public string entityCode { get; set; }
        public int? t_person_Id { get; set; }
        public int? branchId { get; set; }
        public byte[] signCard { get; set; }
        public string person_role { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
