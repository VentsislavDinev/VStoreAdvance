using Abp.Domain.Repositories;
using HostingStore.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class DeleveryInformationService : IDeleveryInformationService
    {
        private IRepository<DeleveryInformation> _product;


        public DeleveryInformationService(
            IRepository<DeleveryInformation> product)
        {
            _product = product ?? throw new ArgumentException(nameof(product));
        }

        public async Task<DeleveryInformation> Create(string address, string city,
            string country, string number, string firstName, string lastName, string phone)
        {


            DeleveryInformation newProduct = new DeleveryInformation
            {
                Address = address,
                City = city,
                Country = country,
                StreetNumber = number,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                //ProductCategoryId = categoryId,
                //ProductSubCategoryId = id,

            };

            await _product.InsertAsync(newProduct);


            return newProduct;
        }


        public async Task<DeleveryInformation> Update(string address, string city,
            string country, string number, string firstName, string lastName, string phone)
        {

            DeleveryInformation newProduct = new DeleveryInformation
            {
                Address = address,
                City = city,
                Country = country,
                StreetNumber = number,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
            };

           await  _product.UpdateAsync(newProduct);
           
            return newProduct;
        }


        public async Task<DeleveryInformation> Delete(string address, string city,
            string country, string number, string firstName, string lastName, string phone)
        {

            DeleveryInformation newProduct = new DeleveryInformation
            {
                Address = address,
                City = city,
                Country = country,
                StreetNumber = number,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
            };
            await _product.DeleteAsync(newProduct);
           
            return newProduct;
        }

        public IQueryable<DeleveryInformation> GetAll()
        {
            return _product.GetAll();
        }

        public IQueryable<DeleveryInformation> GetById(int id)
        {
            return _product.GetAll().Where(x => x.Id == id);
        }

        public IQueryable<DeleveryInformation> GetByAddress(string address)
        {
            return _product.GetAll().Where(x => x.Address == address);
        }

    }
}
