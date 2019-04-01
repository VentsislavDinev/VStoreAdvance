namespace HostingStore.Products
{
    using Abp.Domain.Entities;
    using System;

    public class ProductReview : Entity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
    }
}