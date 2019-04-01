namespace VAgency.Service.User.Company
{
    using Abp.Domain.Repositories;
    using HostingStore.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VAgency.Data.ViewModels;

    public class Contact : IContact
    {
        /// <summary>
        /// The repo
        /// </summary>
        private IRepository<CompanyContact> _repo;
        private IRepository<CompanyContact> Repo { get => _repo; set => _repo = value; }

        public Contact(IRepository<CompanyContact> repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo is null or empty");
            }
            Repo = repo;
        }

        /// <summary>
        /// Get all.
        /// </summary>sбж
        public IEnumerable<CompanyContact> GetAll()
        {
            return Repo.GetAll();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="office"></param>
        /// <param name="number"></param>
        /// <param name="workFrom"></param>
        /// <param name="workTo"></param>
        /// <param name="createdOn"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<CompanyContact> Create(CompanyContactViewModel collection, DateTime createdOn)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CompanyContact newContact = new CompanyContact
            {
                OfficeCountry = collection.OfficeCountry,
                Phonenumber = collection.Phonenumber,
                WorkFrom = collection.WorkFrom,
                WorkTo = collection.WorkTo,
                Address = collection.Address,
                City = collection.City,
                CreatedOn = createdOn,
                Email = collection.Email,
            };

            await Repo.InsertAsync(newContact);

            return newContact;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deletedOn"></param>
        /// <returns></returns>
        public async Task<CompanyContact> Delete(int id, DateTime deletedOn)
        {
            CompanyContact newContact = new CompanyContact()
            {
                IsDeleted = true,
                DeletedOn = deletedOn,
            };
            //newContact = this.UserSytemData.CompanyContacts.GetById(id);

            await Repo.UpdateAsync(newContact);

            return newContact;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="office"></param>
        /// <param name="number"></param>
        /// <param name="workFrom"></param>
        /// <param name="workTo"></param>
        /// <param name="createdOn"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<CompanyContact> Update(CompanyContactViewModel collection)
        {
            CompanyContact newContact = new CompanyContact
            {
                IsDeleted = true,
                OfficeCountry = collection.OfficeCountry,
                Phonenumber = collection.Phonenumber,
                WorkFrom = collection.WorkFrom,
                WorkTo = collection.WorkTo,
                Address = collection.Address,
                City = collection.City,
                PreserveCreatedOn = true,
            };

            await Repo.UpdateAsync(newContact);


            return newContact;
        }
    }
}