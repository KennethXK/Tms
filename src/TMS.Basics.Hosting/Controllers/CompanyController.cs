using Microsoft.AspNetCore.Mvc;
using TMS.Basics.Application.Contracts;
using TMS.Basics.Application.Contracts.Dtos;

namespace TMS.Basics.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService) 
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<HttpResponseResult<CompanyDto>> Get(Guid Id)
        {

            return await _companyService.GetAsync(Id);
        }
    }
}
