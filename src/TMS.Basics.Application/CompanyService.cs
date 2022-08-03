using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Application.Contracts;
using TMS.Basics.Application.Contracts.Dtos;
using TMS.Basics.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace TMS.Basics.Application
{
    public class CompanyService : BaseApplicationService, ICompanyService
    {
        private readonly IRepository<Company> _repository;

        public CompanyService(IRepository<Company> repository) 
        {
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult<CompanyDto>> GetAsync(Guid id)
        {
            var result = (await _repository.GetQueryableAsync())
                .Where(x => x.Id == id)
                .ProjectToType<CompanyDto>()
                .FirstOrDefault();
            return Ok(result);
        }
    }
}
