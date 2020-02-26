//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GOAML.DomainModels.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_address
    {
        public t_address()
        {
            this.goods_services = new HashSet<goods_services>();
            this.reports = new HashSet<report>();
        }
    
        public int t_address_id { get; set; }
        public Nullable<int> Address_type_id { get; set; }
        public string Address { get; set; }
        public string Town_id { get; set; }
        public string City_id { get; set; }
        public string Zip { get; set; }
        public string country_code_id { get; set; }
        public string State_id { get; set; }
        public string comments { get; set; }
        public Nullable<int> t_person_my_client_id { get; set; }
        public Nullable<int> entity_id { get; set; }
        public Nullable<int> director_id { get; set; }
        public Nullable<int> signatory_id { get; set; }
        public string updateBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
    
        public virtual Contact_Type Contact_Type { get; set; }
        public virtual Country_Codes Country_Codes { get; set; }
        public virtual director_detail director_detail { get; set; }
        public virtual District_Name District_Name { get; set; }
        public virtual Division_Name Division_Name { get; set; }
        public virtual ICollection<goods_services> goods_services { get; set; }
        public virtual ICollection<report> reports { get; set; }
        public virtual signatoryDetail signatoryDetail { get; set; }
        public virtual t_entity t_entity { get; set; }
        public virtual t_person_my_client t_person_my_client { get; set; }
        public virtual Thana_Name Thana_Name { get; set; }
    }
}
