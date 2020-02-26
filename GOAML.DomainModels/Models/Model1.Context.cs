﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GOAMLEntities : DbContext
    {
        public GOAMLEntities()
            : base("name=GOAMLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account_Person_Role> Account_Person_Role { get; set; }
        public virtual DbSet<Account_Status_Type> Account_Status_Type { get; set; }
        public virtual DbSet<Account_Type> Account_Type { get; set; }
        public virtual DbSet<Branch_Info> Branch_Info { get; set; }
        public virtual DbSet<Communication_Type> Communication_Type { get; set; }
        public virtual DbSet<Contact_Type> Contact_Type { get; set; }
        public virtual DbSet<Country_Codes> Country_Codes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CUSTOMER_FROM_WINFOS> CUSTOMER_FROM_WINFOS { get; set; }
        public virtual DbSet<director_detail> director_detail { get; set; }
        public virtual DbSet<District_Name> District_Name { get; set; }
        public virtual DbSet<Division_Name> Division_Name { get; set; }
        public virtual DbSet<Funds_type> Funds_type { get; set; }
        public virtual DbSet<goods_services> goods_services { get; set; }
        public virtual DbSet<Identification_Type> Identification_Type { get; set; }
        public virtual DbSet<Legal_Form_Type> Legal_Form_Type { get; set; }
        public virtual DbSet<report> reports { get; set; }
        public virtual DbSet<Report_Code> Report_Code { get; set; }
        public virtual DbSet<Role_type> Role_type { get; set; }
        public virtual DbSet<signatory> signatories { get; set; }
        public virtual DbSet<signatoryDetail> signatoryDetails { get; set; }
        public virtual DbSet<SignatoryInfo> SignatoryInfoes { get; set; }
        public virtual DbSet<Submission_type> Submission_type { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<t_account_my_client> t_account_my_client { get; set; }
        public virtual DbSet<t_address> t_address { get; set; }
        public virtual DbSet<t_entity> t_entity { get; set; }
        public virtual DbSet<t_foreign_currency> t_foreign_currency { get; set; }
        public virtual DbSet<t_from> t_from { get; set; }
        public virtual DbSet<t_from_my_client> t_from_my_client { get; set; }
        public virtual DbSet<t_person_employer> t_person_employer { get; set; }
        public virtual DbSet<t_person_identification> t_person_identification { get; set; }
        public virtual DbSet<t_person_my_client> t_person_my_client { get; set; }
        public virtual DbSet<t_phone> t_phone { get; set; }
        public virtual DbSet<t_to> t_to { get; set; }
        public virtual DbSet<t_to_my_client> t_to_my_client { get; set; }
        public virtual DbSet<t_transaction> t_transaction { get; set; }
        public virtual DbSet<tempTransaction> tempTransactions { get; set; }
        public virtual DbSet<Thana_Name> Thana_Name { get; set; }
        public virtual DbSet<Transaction_Item_Status> Transaction_Item_Status { get; set; }
        public virtual DbSet<Transaction_Item_Type> Transaction_Item_Type { get; set; }
        public virtual DbSet<Transaction_Mode> Transaction_Mode { get; set; }
        public virtual DbSet<userInfo> userInfoes { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
