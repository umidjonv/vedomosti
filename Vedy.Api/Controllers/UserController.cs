using Microsoft.AspNetCore.Mvc;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class UserController(ILogger<UserController> logger, UserService userService) : BaseController
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly UserService _userService = userService;
        
        [HttpPost]
        [ProducesResponseType(200, Type= typeof(UserResult))]
        public async Task<IActionResult> Create([FromBody] UserCreate user)
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            try
            {
                if (loginModel == null)
                {
                    throw new ArgumentException();
                }
                var result = await _userService.Login(loginModel);

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

    }
}
