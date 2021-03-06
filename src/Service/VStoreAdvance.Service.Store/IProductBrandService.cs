﻿using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductBrandService : IApplicationService
    {
        Task<ProductBrand> Create(string name, string desc, string image);
        Task<ProductBrand> Delete(string name, string desc, string image);
        IQueryable<ProductBrand> GetAll();
        IQueryable<ProductBrand> GetById(int id);
        IQueryable<ProductBrand> GetByName(string category);
        Task<ProductBrand> Update(string name, string desc, string image);
    }
}