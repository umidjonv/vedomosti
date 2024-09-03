using Microsoft.AspNetCore.Mvc;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class CustomerEntryController(ILogger<CustomerEntryController> logger, CustomerEntryService cutomerService) : BaseController
    {
        private readonly ILogger<CustomerEntryController> _logger = logger;
        private readonly CustomerEntryService _customerService = cutomerService;
        
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
