using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class SettlementService
    {
        private readonly ISettlementRepository _settlementRepository;
        private readonly ICompanyRepository _companyRepository;

        public SettlementService(ISettlementRepository settlementRepository) 
        {
            this._settlementRepository = settlementRepository;
        }

        public async Task<List<SettlementModel>> GetAll()
        {
            var settlements = await _settlementRepository.GetAllAsync();
            var response = new List<SettlementModel>();
            foreach (var settlement in settlements)
            {

                response.Add(new  SettlementModel 
                {
                    Id = settlement.Id,
                    Date = settlement.Date,
                    Number = settlement.Number,
                    
                });
            }

            return response;
        }

        public async Task<SettlementModel> GetById(long id)
        {
            var settlement = await _settlementRepository.GetById();
            var model = new SettlementModel
            {
                Id = settlement.Id,
                Date = settlement.Date,
                Number = settlement.Number,
                CustomerEntries = GetCustomerEntries(settlement.CustomerEntries)
            };
            
            return model;
        }

        public List<CustomerEntryModel> GetCustomerEntries(IEnumerable<CustomerEntry> customerEntries) 
        {
            var list = new List<CustomerEntryModel>();

            foreach (var customerEntry in customerEntries)
            {
                list.Add(new CustomerEntryModel
                {
                    Amount = customerEntry.Amount,
                    CarNumber = customerEntry.CarNumber,
                    CompanyId = customerEntry.CompanyId,
                    CompanyName = customerEntry.Company.CompanyName,
                    SettlementNumber = customerEntry.Settlement.Number,
                    FullName = customerEntry.FullName,
                    CreatedDate = customerEntry.CreatedDate,
                    Id = customerEntry.Id,
                    SettlementDate = customerEntry.Settlement.Date,
                    SettlementId = customerEntry.Settlement.Id,
                    SignHash = customerEntry.SignHash,
                });
            }

            return list;
        }

        public async Task<SettlementModel?> Add(SettlementModel model)
        {
            var result = await _settlementRepository.AddAsync(new Settlement
            {
                Date = model.Date,
                Number = model.Number,  
                UserId = model.UserId,
            });

            return new SettlementModel
            {
                UserId = model.UserId,
                Date = model.Date,
                Number = model.Number,
                CustomerEntries = model.CustomerEntries,
                Id = model.Id
            };
        }

        public async Task Update(SettlementModel model)
        {
            await _settlementRepository.UpdateAsync(new Settlement
            {
            });
        }

        public async Task Delete(long id)
        {
            await _settlementRepository.DeleteAsync(id);
        }
    }
}
