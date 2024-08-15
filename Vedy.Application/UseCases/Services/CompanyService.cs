using Vedy.Application.Interfaces;
using Vedy.Common.DTOs.User;
using Vedy.Data;

namespace Vedy.Infrastructure.Services
{
    public class CustomerCompanyService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;

        public CustomerCompanyService(ICustomerRepository customerRepository,
                            ICompanyRepository companyRepository) 
        {
            this._customerRepository = customerRepository;
            this._companyRepository = companyRepository;
        }

        
    }
}
