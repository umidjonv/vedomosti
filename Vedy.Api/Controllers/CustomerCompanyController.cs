using Microsoft.AspNetCore.Mvc;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class CustomerCompanyController(ILogger<CustomerCompanyController> logger, CustomerCompanyService customerCompanyService) : BaseController
    {
        private readonly ILogger<CustomerCompanyController> _logger = logger;
        private readonly CustomerCompanyService _userService = customerCompanyService;
        
        [HttpPost]
        [ProducesResponseType(200, Type= typeof(UserResult))]
        public async Task<IActionResult> CreateCompany([FromBody] UserCreate user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentException();
                }

                var result = await _userService.AddUser(user);
                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException();
                }
                var result = await _userService.GetUser(id);

                return Success(result);
            }catch (Exception ex) 
            {
                return Bad(ex.Message);
            }
        }

    }
}
