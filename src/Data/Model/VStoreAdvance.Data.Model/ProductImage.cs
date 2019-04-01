using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.Products
{
    public class ProductImage : Entity
    {
        public int Id { get; set; }
        public string File { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
