using Microsoft.AspNetCore.Mvc;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.User;
using Vedy.Infrastructure.Services;

namespace Vedy.Api.Controllers
{
    public class CompanyController(ILogger<CompanyController> logger, CompanyService customerCompanyService) : BaseController
    {
        private readonly ILogger<CompanyController> _logger = logger;
        private readonly CompanyService _companyService = customerCompanyService;
        
        [HttpPost]
        [ProducesResponseType(200, Type= typeof(UserResult))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyModel company)
        {
            try
            {
                if (company == null)
                {
                    throw new ArgumentException();
                }

                //var result = await _userService.AddUser(user);
                return Success("");

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
                var result = await _companyService.GetAll();

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CompanyModel company)
        {
            try
            {
                var result = await _companyService.AddCompany(company);

                return Success(result);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CompanyModel company)
        {
            try
            {
                await _companyService.UpdateCompany(company);

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
                await _companyService.DeleteCompany(id);

                return Success(id);
            }
            catch (Exception ex)
            {
                return Bad(ex.Message);
            }
        }

    }
}
