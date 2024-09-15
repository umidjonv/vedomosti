using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vedy.Common;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class ConfigController(ILogger<ConfigController> logger, IOptions<AppConfig> options) : BaseController
    {
        private readonly ILogger<ConfigController> _logger = logger;
        private readonly IOptions<AppConfig> _options = options;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Success(_options.Value);
            }catch (Exception ex) 
            {
                return Bad(ex.Message);
            }
        }


    }
}
