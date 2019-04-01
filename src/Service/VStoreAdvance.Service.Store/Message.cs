namespace VAgency.Service.User.Company
{
    using Abp.Domain.Repositories;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels.Company;

    public class MessageCompany : IMessageCompany, IDisposable
    {
        /// <summary>
        /// The repo
        /// </summary>
        private readonly IRepository<CompanyMessage> _repo;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyContactQuery"/> class.
        /// </summary>
        /// <param name="_companySystemData">The company system data.</param>
        public MessageCompany( IRepository<CompanyMessage> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            this._repo = repo;
        }

        /// <summary>
        /// Creates the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="title">The title.</param>
        public async Task<CompanyMessage> Create(CompanyMessageCreateViewViewModel colletion)
        {
            var newMessage = new CompanyMessage
            {
                Description = colletion.Description,
                FirstName = colletion.FirstName,
                LastName = colletion.LastName,
                Phone = colletion.Phone,
                Title = colletion.Title,
                Email = colletion.Email,  
            };

            await  this._repo.InsertAsync(newMessage);

            return newMessage;
        }

        /// <summary>
        /// Updates the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="title">The title.</param>
        public async Task<CompanyMessage> Update(CompanyMessageViewViewModel colletion, int id)
        {
            var newMessage = new CompanyMessage
            {
                Description = colletion.Description,
                FirstName = colletion.FirstName,
                LastName = colletion.LastName,
                Phone = colletion.Phone,
                Title = colletion.Title,
                Email = colletion.Email,
                PreserveCreatedOn = true
            };
            //newMessage = this._repo.GetById(id);
           await   this._repo.UpdateAsync(newMessage);
            //try
            //{
            //    await this._repo.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            return newMessage;
        }

        /// <summary>
        /// Deletes the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="title">The title.</param>
        public async Task<CompanyMessage> Delete(int id, DateTime createdOn)
        {
            var newMessage = new CompanyMessage()
            {
                IsDeleted = true,
                DeletedOn = createdOn,
            };
            //newMessage = this._repo.GetById(id);

            await this._repo.InsertAsync(newMessage);
        

            return newMessage;
        }

        /// <summary>
        /// Gets all.
        /// </summary>s
        public IEnumerable<CompanyMessage> GetAll()
        {
            var getAllContact = this._repo.GetAll();

            return getAllContact;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}