using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Application.Contracts.Dtos;
using Volo.Abp.Application.Services;

namespace TMS.Basics.Application.Contracts
{
    /// <summary>
    /// 公司
    /// </summary>
    public interface ICompanyService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<HttpResponseResult<CompanyDto>> GetAsync(Guid id);
    }
}
