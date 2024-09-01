using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.User;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class CustomerEntryService
    {
        private readonly ICustomerEntryRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;

        public CustomerEntryService(ICustomerEntryRepository customerRepository,
                            ICompanyRepository companyRepository) 
        {
            this._customerRepository = customerRepository;
            this._companyRepository = companyRepository;
        }

        public async Task<List<CustomerEntryModel>> GetAll()
        {
            var customers = await _customerRepository.GetAllAsync();
            var response = new List<CustomerEntryModel>();
            foreach (var company in customers)
            {

                response.Add(new CustomerEntryModel 
                {
                    
                });
            }

            return response;
        }

        public async Task<CustomerEntryModel?> Add(CustomerEntryModel company)
        {
            var result = await _customerRepository.AddAsync(new CustomerEntry
            {
                //CompanyName = company.Name,
                //Tin = company.Tin
            });

            return new CustomerEntryModel {  };
        }

        public async Task Update(CustomerEntryModel company)
        {
            await _customerRepository.UpdateAsync(new CustomerEntry
            {
                //Id= company.Id,
                //CompanyName = company.Name,
                //Tin = company.Tin
            });
        }

        public async Task Delete(long id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
