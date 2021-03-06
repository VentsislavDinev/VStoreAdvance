﻿namespace HostingStore.Products
{
    using Abp.Domain.Entities;
    using System;



    public class CompanyInformation : Entity
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

       
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string FilePath { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}