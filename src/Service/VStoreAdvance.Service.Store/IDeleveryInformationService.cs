using System.Linq;
using System.Threading.Tasks;
using HostingStore.Products;

namespace HostingStore.ProductService
{
    public interface IDeleveryInformationService
    {
        Task<DeleveryInformation> Create(string address, string city, string country, string number, string firstName, string lastName, string phone);
        Task<DeleveryInformation> Delete(string address, string city, string country, string number, string firstName, string lastName, string phone);
        IQueryable<DeleveryInformation> GetAll();
        IQueryable<DeleveryInformation> GetByAddress(string address);
        IQueryable<DeleveryInformation> GetById(int id);
        Task<DeleveryInformation> Update(string address, string city, string country, string number, string firstName, string lastName, string phone);
    }
}