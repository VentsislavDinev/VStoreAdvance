using Abp.Application.Services;
using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class ProductBrandService : ApplicationService, IProductBrandService
    {

        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<ProductBrand> _repo;


        public ProductBrandService( IRepository<ProductBrand> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<ProductBrand> Create(string name, string desc, string image)
        {
            ProductBrand createProductCategory = new ProductBrand
            {
                Name = name,
                Description = desc,
                Image = image,
            };

            await  _repo.InsertAsync(createProductCategory);
            
            return createProductCategory;
        }


        public async Task<ProductBrand> Update(string name, string desc, string image)
        {
            ProductBrand createProductCategory = new ProductBrand
            {
                Name = name,
                Description = desc,
                Image = image,
            };
          await   _repo.UpdateAsync(createProductCategory);
           
            return createProductCategory;
        }


        public async Task<ProductBrand> Delete(string name, string desc, string image)
        {
            ProductBrand createProductCategory = new ProductBrand
            {
                Name = name,
                Description = desc,
                Image = image,
            };

            await  _repo.DeleteAsync(createProductCategory);
           
            return createProductCategory;
        }

        public IQueryable<ProductBrand> GetAll()
        {
            return _repo.GetAll();
        }

        public IQueryable<ProductBrand> GetById(int id)
        {
            return _repo.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<ProductBrand> GetByName(string category)
        {
            return _repo.GetAll().Where(x => x.Name == category);
        }
        
    }
}
