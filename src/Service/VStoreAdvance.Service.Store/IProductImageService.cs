﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IProductImageService : IApplicationService
    {
        Task<ProductImage> Create(string code, DateTime createdOn, int productId);
        Task<ProductImage> Delete(string code, DateTime createdOn, int productId);
        IQueryable<ProductImage> GetAll();
        IQueryable<ProductImage> GetById(int id);
        IQueryable<ProductImage> GetByProductId(int productId);
        Task<ProductImage> Update(string code, DateTime createdOn, int productId);
    }
}