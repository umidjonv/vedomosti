using Microsoft.AspNetCore.Mvc;
using Vedy.Common.BaseModels;

namespace Vedy.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        protected IActionResult Success(object model)
        {
            return Ok(new BaseResponse
            {
                Data = model,
                IsSuccess = true,
            });
        }
        [NonAction]
        public IActionResult Bad(string message, int code = 404)
        {
            return Ok(new BaseResponse
            {
                IsSuccess = false,
                Error = new ErrorModel 
                {
                    Message = message,
                    ErrorCode = code
                }
            });
        }
    }
}
