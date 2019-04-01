using Abp.Domain.Entities;

namespace HostingStore.Products
{
    public class CompanyInformationImage :Entity
    {
        public int Id { get; set; }

        public string filePath { get; set; }
    }
}