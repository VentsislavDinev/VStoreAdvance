using HostingStore.ProductViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostingStore.ProductService
{
    public interface IDeleveryInformationOrderService
    {
        Task<DeleveryInformationViewModel> GetSingleDeleveryInformation();
        Task<IList<DeleveryInformationViewModel>> OrderDeleveryInformation(int id);
    }
}