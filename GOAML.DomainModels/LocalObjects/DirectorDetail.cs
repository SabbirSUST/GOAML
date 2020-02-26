using System;

namespace GOAML.DomainModels.LocalObjects
{
    public class DirectorDetail
    {
        public int t_person_id { get; set; }
        public string gender { get; set; }
        public string Title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string prefix { get; set; }
        public string last_name { get; set; }
        public DateTime? birthdate { get; set; }
        public string Birth_place { get; set; }
        public string mothers_name { get; set; }
        public string alias { get; set; }
        public string SSN { get; set; }
        public string passport_number { get; set; }
        public string passport_country { get; set; }
        public string id_number { get; set; }
        public string Nationality1 { get; set; }
        public string Nationality2 { get; set; }
        public string Nationality3 { get; set; }
        public string residence { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string deceased { get; set; }
        public DateTime? deceased_date { get; set; }
        public string tax_number { get; set; }
        public string tax_reg_number { get; set; }
        public string source_of_wealth { get; set; }
        public string comments { get; set; }
        public int? entity_id { get; set; }
        public int? role_id { get; set; }
        public int? signatoryStatus { get; set; }
        public string updateBy { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
