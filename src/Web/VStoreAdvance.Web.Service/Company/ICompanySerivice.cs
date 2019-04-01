using Abp.Application.Services;
using System.Collections.Generic;
using VAgency.Data.ViewModels;
using VAgency.Service.User.Company;
using VAgency.Services.Static;

namespace VStoreAdvance.Web.Service.Company
{
    public interface ICompanySerivice: IApplicationService
    {
        IContact Contact { get; set; }
        IFeedBackCompany FeedBackCompany { get; set; }
        IMessageCompany Message { get; set; }
        IPage Page { get; set; }
        IService Service { get; set; }
        IAbout About { get; set; }

        IEnumerable<CompanyContactViewModel> GetContact();
        IEnumerable<StaticPageViewModel> Pages();
    }
}
