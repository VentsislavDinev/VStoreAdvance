namespace HostingStore.Products
{
    using Abp.Domain.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;


   

    public class CompanyFeedBackCompany : Entity
    {
        public int Id { get; set; }

       
       public string CompanyName { get; set; }

       
        public string Description { get; set; }
       
        public string Logo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}