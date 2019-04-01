using HostingStore.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public class DeleveryInformationOrderService : IDeleveryInformationOrderService
    {
        private const int pageNumber = 100;
        private readonly IDeleveryInformationService _productCategory;
        public DeleveryInformationOrderService(IDeleveryInformationService productCategory)
        {

            _productCategory = productCategory ?? throw new ArgumentNullException(nameof(productCategory));
        }

        public async Task<DeleveryInformationViewModel> GetSingleDeleveryInformation()
        {
            var getAll = await _productCategory.GetAll()
              
                .Select(x => new DeleveryInformationViewModel
                {
                    Address = x.Address,
                    City = x.Address,
                    Country = x.Country,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    StreetNumber = x.StreetNumber
                }).FirstOrDefaultAsync();

            return getAll;
        }

        public async Task<IList<DeleveryInformationViewModel>> OrderDeleveryInformation(int id)
        {
            int page = id;

            int allItemCount = await _productCategory.GetAll().CountAsync();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;
            var getAll = await _productCategory.GetAll()

                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new DeleveryInformationViewModel
                {
                    Address = x.Address,
                    City = x.Address,
                    Country = x.Country,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                     StreetNumber = x.StreetNumber
                }).ToListAsync();

            return getAll;
        }
    }
}
