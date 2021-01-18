//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FairWorkk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.CompanyContractPayments = new HashSet<CompanyContractPayment>();
            this.FreeAreas = new HashSet<FreeArea>();
            this.SalesPersons = new HashSet<SalesPerson>();
        }
    
        public int ID { get; set; }
        public System.DateTime ContractDate { get; set; }
        public int SalesPersonId { get; set; }
        public int CompanyInformationId { get; set; }
        public int ContractTypeId { get; set; }
        public int StandTypeId { get; set; }
        public int StandId { get; set; }
        public Nullable<int> SquarePrice { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<decimal> EcxhangeRate { get; set; }
        public int DiscountRate { get; set; }
        public Nullable<int> MaturityNumber { get; set; }
        public string PaymentPlan { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public System.DateTime ContractDeadline { get; set; }
        public bool ContractSigned { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyContractPayment> CompanyContractPayments { get; set; }
        public virtual CompanyInformation CompanyInformation { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual Stand Stand { get; set; }
        public virtual StandType StandType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FreeArea> FreeAreas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesPerson> SalesPersons { get; set; }
    }
}
