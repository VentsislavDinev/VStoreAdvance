using Abp.Domain.Entities;
using System;

namespace HostingStore.Products
{
    public class StaticPageURL : Entity
    {
        public int Id { get; set; }

       
        public string Name { get; set; }

       
        public string URL { get; set; }

        public int ImageId { get; set; }

        public virtual StaticPageUrlImage Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}