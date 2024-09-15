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
            var settlements = await _settlementRepository.GetAllWithCompany();
            var response = new List<SettlementModel>();
            foreach (var settlement in settlements)
            {
                string? companyName = settlement.Company == null ? null : settlement.Company.CompanyName;
                response.Add(new  SettlementModel 
                {
                    Id = settlement.Id,
                    Date = settlement.Date,
                    Number = settlement.Number,
                    CompanyId = settlement.CompanyId,
                    CompanyName = companyName
                    
                });
            }

            return response;
        }


        public async Task<SettlementModel> GetById(long id)
        {
            var settlement = await _settlementRepository.GetById(id);
            string? companyName = settlement.Company == null ? null : settlement.Company.CompanyName;
            var model = new SettlementModel
            {
                Id = settlement.Id,
                Date = settlement.Date,
                Number = settlement.Number,
                CompanyId = settlement.CompanyId,
                CompanyName = companyName,
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
                    Sum = customerEntry.Sum,
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
                CompanyId = model.CompanyId,
            });

            return new SettlementModel
            {
                UserId = result.UserId,
                Date = result.Date,
                Number = result.Number,
                CompanyId= result.CompanyId,
                CompanyName = model.CompanyName,
                CustomerEntries = new List<CustomerEntryModel>(),
                Id = result.Id
            };
        }

        public async Task Update(SettlementModel model)
        {
            await _settlementRepository.UpdateAsync(new Settlement
            {
            });
        }


        public async Task Update(IEnumerable<CustomerEntryModel> entries, long settlementId)
        {
            var settlement = await _settlementRepository.GetById(settlementId);

            if (settlement == null)
            {
                throw new Exception("Settlement not found");                                
            }

            var customerEntries = new List<CustomerEntry>();

            foreach (var entryModel in entries)
            {
                customerEntries.Add(new CustomerEntry 
                {
                    Id = entryModel.Id.Value,
                    Amount = entryModel.Amount,
                    Sum = entryModel.Sum,
                    CarNumber = entryModel.CarNumber,
                    CompanyId = entryModel.CompanyId,
                    CreatedDate = entryModel.CreatedDate,   
                    FullName = entryModel.FullName, 
                    SettlementId = settlementId,
                    SignHash = entryModel.SignHash,
                });

            }

            settlement.CustomerEntries = customerEntries;
            await _settlementRepository.UpdateAsync(settlement);

        }
        public async Task Delete(long id)
        {
            await _settlementRepository.DeleteAsync(id);
        }
    }
}
