namespace HostingStore.Products.Company
{
    using Abp.Domain.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class StaticPage : Entity
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

       
         public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}