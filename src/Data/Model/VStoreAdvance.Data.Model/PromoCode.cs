using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.Products
{
    public class PromoCode : Entity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
