using Microsoft.AspNetCore.Mvc;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class SettlementController(ILogger<SettlementController> logger, SettlementService settlementService) : BaseController
    {
        private readonly ILogger<SettlementController> _logger = logger;
        private readonly SettlementService _settlementService = settlementService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException();
                }

                var settlement = await _settlementService.GetById(id);

                return Success(settlement);
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
                var result = await _settlementService.GetAll();

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SettlementModel model)
        {
            try
            {
                var result = await _settlementService.Add(model);

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SettlementModel model)
        {
            try
            {
                await _settlementService.Update(model);

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
                await _settlementService.Delete(id);

                return Success(id);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

    }
}
