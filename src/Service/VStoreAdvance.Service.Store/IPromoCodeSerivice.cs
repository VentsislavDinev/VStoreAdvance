using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IPromoCodeSerivice : IApplicationService
    {
        Task<PromoCode> Create(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo);
        Task<PromoCode> Delete(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo);
        IQueryable<PromoCode> GetAll();
        IQueryable<PromoCode> GetById(int id);
        IQueryable<PromoCode> GetByName(string code);
        Task<PromoCode> Update(string code, DateTime? createdOn, DateTime? ValidFrom, DateTime? validTo);
    }
}