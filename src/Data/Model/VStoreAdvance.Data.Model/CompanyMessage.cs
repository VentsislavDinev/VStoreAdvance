namespace HostingStore.Products
{
    using Abp.Domain.Entities;
    using System;



    public class CompanyMessage : Entity
    {
        public int Id { get; set; }

       
        public string Title { get; set; }

       
        public string Description { get; set; }

       
        public string Phone { get; set; }

        public string FirstName { get; set; }

       
        public string Email { get; set; }

       
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}