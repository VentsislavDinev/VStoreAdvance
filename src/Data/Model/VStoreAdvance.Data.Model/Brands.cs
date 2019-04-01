using Abp.Domain.Entities;

namespace HostingStore.Products
{
    public class Brands : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}