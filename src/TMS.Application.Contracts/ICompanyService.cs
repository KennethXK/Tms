using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.Dtos.Company;
using Volo.Abp.Application.Services;

namespace TMS
{
    public interface ICompanyService : IApplicationService
    {
        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseResult<List<CompanyDto>>> GetListAsync(string code = "", string name = "");

        /// <summary>
        /// 获取公司分页
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseResult<List<CompanyDto>>> Getpage(string code = "", string name = "", int page = 1, int pageSize = 10);

        /// <summary>
        /// 根据ID获取公司信息
        /// </summary>
        /// <param name="routeId">路由ID</param>
        /// <returns></returns>
        Task<HttpResponseResult<CompanyDto>> GetAsync(Guid companyId);

        /// <summary>
        /// 创建公司信息
        /// </summary>
        /// <param name="createRouteDto"></param>
        /// <returns></returns>
        Task<HttpResponseResult> CreateAsync(CompanyDto companyDto);

        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        Task<HttpResponseResult> DeleteAsync(Guid companyId);

        /// <summary>
        /// 更新公司信息
        /// </summary>
        /// <param name="updateRouteDto"></param>
        /// <returns></returns>
        Task<HttpResponseResult> UpdateAsync(UpdateCompanyDto companyDto);
    }
}
