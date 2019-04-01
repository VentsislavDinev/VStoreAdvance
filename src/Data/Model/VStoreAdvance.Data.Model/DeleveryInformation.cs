using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.Products
{
    public class DeleveryInformation : Entity
    {

        private ICollection<OrderDetail> _orederDetails;

        public DeleveryInformation()
        {
            this._orederDetails = new HashSet<OrderDetail>();
            CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string StreetNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int ShopingCartId { get; set; }
        public virtual ICollection<OrderDetail> ShopingCarts
        {

            get
            {
                return this._orederDetails;
            }
            set
            {
                _orederDetails = value;
            }
        }
        public DateTime CreatedOn { get; set; }
    }
}
