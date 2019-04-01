using Abp.Domain.Entities;
using System;

namespace HostingStore.Products
{
    public class StaticPageUrlImage : Entity
    {
        public int Id { get; set; }
                                              

        public string Extension { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}