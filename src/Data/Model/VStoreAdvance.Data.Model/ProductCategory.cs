using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostingStore.Products
{
    public class ProductCategory : Entity
    {
        private ICollection<ProductSubCategory> _parent;
       

        public ProductCategory()
        {
            this._parent = new HashSet<ProductSubCategory>();
     
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
        //represnts Parent ID and it's nullable  
        public int? ParentId { get; set; }
        
        public virtual ICollection<ProductSubCategory> Parent
        {
            get
            {
                return this._parent;
            }

            set
            {
                this._parent = value;
            }
        }



    }
}