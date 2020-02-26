using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class TpersonMyClient
    {
        public int t_person_my_client_id { get; set; }
        public string gender { get; set; }
        public string Title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string prefix { get; set; }
        public string last_name { get; set; }
        public DateTime? birthdate { get; set; }
        public string Birth_place { get; set; }
        public string mothers_name { get; set; }
        public string fathers_Name { get; set; }
        public string SSN { get; set; }
        public string passport_number { get; set; }
        public string passport_country { get; set; }
        public string id_number { get; set; }
        public string Nationality1_id { get; set; }
        public string Nationality2_id { get; set; }
        public string Nationality3_id { get; set; }
        public string residence { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public int? employer_id { get; set; }
        public string deceased { get; set; }
        public DateTime? deceased_date { get; set; }
        public string tax_number { get; set; }
        public string tax_reg_numebr { get; set; }
        public string source_of_wealth { get; set; }
        public string comments { get; set; }
        public int? branchId { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
