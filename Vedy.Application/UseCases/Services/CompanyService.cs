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
                    Tin = company.Tin,
                });
            }

            return response;
        }

        public async Task<CompanyModel?> AddCompany(CompanyModel company)
        {
            var result = await _companyRepository.AddAsync(new Company
            {
                CompanyName = company.Name,
                Tin = company.Tin
            });

            return new CompanyModel { Id = result.Id, Name = result.CompanyName, Tin = result.Tin };
        }

        public async Task UpdateCompany(CompanyModel company)
        {
            await _companyRepository.UpdateAsync(new Company
            {
                Id= company.Id,
                CompanyName = company.Name,
                Tin = company.Tin
            });
        }

        public async Task DeleteCompany(long id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}
