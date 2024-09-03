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
            var entries = await _customerRepository.GetAll();
            var response = new List<CustomerEntryModel>();
            foreach (var customerEntry in entries)
            {

                response.Add(new CustomerEntryModel 
                {
                    Id = customerEntry.Id,
                    CarNumber = customerEntry.CarNumber,
                    Amount = customerEntry.Amount,
                    CompanyId = customerEntry.CompanyId,
                    CompanyName = customerEntry.Company.CompanyName,
                    CreatedDate = customerEntry.CreatedDate.ToUniversalTime(),
                    FullName = customerEntry.FullName,
                    SettlementDate = customerEntry.Settlement.Date,
                    SettlementId = customerEntry.SettlementId,
                    SettlementNumber = customerEntry.Settlement.Number,
                    SignHash = customerEntry.SignHash,
                                        
                });
            }

            return response;
        }

        public async Task<CustomerEntryModel?> Add(CustomerEntryModel entry)
        {
            var result = await _customerRepository.AddAsync(new CustomerEntry
            {
                FullName = entry.FullName,
                CompanyId = entry.CompanyId,
                CreatedDate = entry.CreatedDate.ToUniversalTime(),
                Amount = entry.Amount,
                CarNumber = entry.CarNumber,
                SettlementId = entry.SettlementId,
                SignHash = entry.SignHash
                
            });

            return new CustomerEntryModel 
            {
                Id = result.Id,
                CompanyId = result.CompanyId,
                CreatedDate = result.CreatedDate,
                FullName = result.FullName,
                CarNumber = result.CarNumber,
                SignHash= result.SignHash,
                SettlementId= result.SettlementId,
                Amount= result.Amount,
                CompanyName = entry.CompanyName,
                SettlementDate = entry.SettlementDate,
                SettlementNumber = entry.SettlementNumber  
            };
        }

        public async Task Update(CustomerEntryModel entry)
        {
            await _customerRepository.UpdateAsync(new CustomerEntry
            {
                FullName = entry.FullName,
                CompanyId = entry.CompanyId,
                CreatedDate = entry.CreatedDate,
                Amount = entry.Amount,
                CarNumber = entry.CarNumber,
                SettlementId = entry.SettlementId,
                SignHash = entry.SignHash

            });
        }

        public async Task Delete(long id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
