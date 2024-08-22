using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.User;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class CompanyService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICustomerRepository customerRepository,
                            ICompanyRepository companyRepository) 
        {
            this._customerRepository = customerRepository;
            this._companyRepository = companyRepository;
        }

        public async Task<List<CompanyModel>> GetAll()
        {
            var companies = await _companyRepository.GetAllAsync();
            var response = new List<CompanyModel>();
            foreach (var company in companies)
            {

                response.Add(new CompanyModel 
                {
                    Id = company.Id,
                    Name = company.CompanyName,
                    TIN = company.Tin,
                });
            }

            return response;
        }
    }
}
