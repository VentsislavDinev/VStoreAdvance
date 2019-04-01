using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAgency.Data.ViewModels;
using VAgency.Service.User.Company;
using VAgency.Services.Static;

namespace VStoreAdvance.Web.Service.Company
{
    public class CompanySerivice : ApplicationService, ICompanySerivice
    {

        private IContact _contact;
        private IPage _page;
        //private ISEOService _seo;
        private IService _service;
        private IMessageCompany _message;
        private IFeedBackCompany _feedBackCompany;
        private IAbout _about;

        public CompanySerivice(IContact contact, IPage page, IService service, IMessageCompany message, IFeedBackCompany feedBackCompany, IAbout about)
        {
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            Page = page ?? throw new ArgumentNullException(nameof(page));
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            FeedBackCompany = feedBackCompany ?? throw new ArgumentNullException(nameof(feedBackCompany));
            About = about ?? throw new ArgumentNullException(nameof(about));
        }
        public IContact Contact { get => _contact; set => _contact = value; }

        public IPage Page { get => _page; set => _page = value; }

        public IService Service { get => _service; set => _service = value; }
        public IMessageCompany Message { get => _message; set => _message = value; }
        public IFeedBackCompany FeedBackCompany { get => _feedBackCompany; set => _feedBackCompany = value; }
        public IAbout About { get => _about; set => _about = value; }



        public IEnumerable<CompanyContactViewModel> GetContact()
        {
            var getContact = this._contact.GetAll().Where(x => x.Id == 1)
           .Select(x => new CompanyContactViewModel
           {
               Email = x.OfficeCountry,
               WorkTo = x.WorkTo,
               WorkFrom = x.WorkFrom,
               Phonenumber = x.Phonenumber
           });
            return getContact;
        }


        public IEnumerable<StaticPageViewModel> Pages()
        {
            var getStaticPage = this._page.GetAll()
                .Select(x => new StaticPageViewModel
                {
                    Name = x.Name,
                });
            return getStaticPage;
        }
    }
}
