using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class CustomerEntryController(ILogger<CustomerEntryController> logger, CustomerEntryService cutomerService, SettlementService settlementService) : BaseController
    {
        private readonly ILogger<CustomerEntryController> _logger = logger;
        private readonly CustomerEntryService _customerService = cutomerService;
        private readonly SettlementService  _settlementService = settlementService;
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException();
                }
                

                return Success("");
            }catch (Exception ex) 
            {
                return Bad(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByDate([FromBody]DateRangeModel dateRanges)
        {
            

            try
            {
                

                //if (!DateTimeOffset.TryParse(date, out var currentDate))
                //{
                //    return Bad("Not correct date format");
                //}

                var result = await _customerService.GetByDate(dateRanges);

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _customerService.GetAll();

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CustomerEntryModel entry)
        {
            try
            {
                var result = await _customerService.Add(entry);

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CustomerEntryModel entry)
        {
            try
            {
                await _customerService.Update(entry);

                return Success(true);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEntries([FromBody] SetSettlementModel model)
        {
            try
            {
                await _settlementService.Update(model.Entries, model.SettlementId);

                return Success(true);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _customerService.Delete(id);

                return Success(id);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

    }
}
