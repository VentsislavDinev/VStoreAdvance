using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.Products
{
    public class ProductPromoHome : Entity
    {
        public ProductPromoHome()
        {
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Avatar { get; set; }
    }
}
