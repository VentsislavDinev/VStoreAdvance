namespace HostingStore.Products
{
    using Abp.Domain.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;


   

    public class CompanyContact : Entity
    {
        public int Id { get; set; }

       
        public string Phonenumber { get; set; }

       
        public string OfficeCountry { get; set; }

        public DateTime WorkFrom { get; set; }

        public DateTime WorkTo { get; set; }

        public string Email { get; set; }

       
         public string City { get; set; }

       
        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}