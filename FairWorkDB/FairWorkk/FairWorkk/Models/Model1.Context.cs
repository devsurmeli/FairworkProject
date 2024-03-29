﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FairWorkDbEntities : DbContext
    {
        public FairWorkDbEntities()
            : base("name=FairWorkDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdditionalStandMaterial> AdditionalStandMaterials { get; set; }
        public virtual DbSet<ADMFAPayment> ADMFAPayments { get; set; }
        public virtual DbSet<AppUserInformation> AppUserInformations { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<BudgetAndCurrentSale> BudgetAndCurrentSales { get; set; }
        public virtual DbSet<CatalogInputForm> CatalogInputForms { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyContractPayment> CompanyContractPayments { get; set; }
        public virtual DbSet<CompanyInformation> CompanyInformations { get; set; }
        public virtual DbSet<CompanyNeed> CompanyNeeds { get; set; }
        public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fair> Fairs { get; set; }
        public virtual DbSet<FreeArea> FreeAreas { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<HiddenDiscount> HiddenDiscounts { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<Interviewee> Interviewees { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<ParticipantHandbook> ParticipantHandbooks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<Saloon> Saloons { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Stand> Stands { get; set; }
        public virtual DbSet<StandType> StandTypes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
    }
}
