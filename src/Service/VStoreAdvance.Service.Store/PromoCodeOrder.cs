
using HostingStore.ProductViewModel;
using System;
using System.Linq;

namespace HostingStore.ProductService
{
    public class PromoCodeOrder : IPromoCodeOrder
    {
        private const int pageNumber = 10;
        private IPromoCodeSerivice _productReview;


        public PromoCodeOrder(IPromoCodeSerivice productReview)
        {
            _productReview = productReview ?? throw new ArgumentNullException(nameof(productReview));
        }

        public PromoCodeListViewModel OrderPromoCode(int id)
        {
            int page = id;

            int allItemCount = _productReview.GetAll().Count();
            int totalPagesFromDb = (int)Math.Ceiling(allItemCount / (decimal)pageNumber);
            int itemToSkipFromDb = (Convert.ToInt32(page) - 1) * pageNumber;

            IQueryable<PromoCodeViewModel> getAll = _productReview.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemToSkipFromDb)
                .Take(pageNumber)
                .Select(x => new PromoCodeViewModel
                {
                    Code = x.Code,
                    ValidFrom = x.ValidFrom,
                    ValidTo = x.ValidTo,
                });
            PromoCodeListViewModel searchEmpty = new PromoCodeListViewModel
            {

                TotalPages = totalPagesFromDb,
                CurrentPage = page,
                Space = getAll,
            };
            return searchEmpty;
        }

        public PromoCodeViewModel SinglePromoCode(string name)
        {
            PromoCodeViewModel getAll = _productReview.GetByName(name).Select(x => new PromoCodeViewModel
            {
                ValidTo = x.ValidTo,
                CreatedOn = x.CreatedOn,
                ValidFrom = x.ValidFrom,
                Code = x.Code,
            })
            .FirstOrDefault();

            return getAll;
        }
    }
}
