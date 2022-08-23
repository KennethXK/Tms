using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Dtos;
using TMS.Dtos.Company;
using Volo.Abp.Domain.Repositories;

namespace TMS
{
    public class CompanyService : BaseApplicationService, ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository) 
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseResult<List<CompanyDto>>> GetListAsync(string code = "",string name="") 
        {
            var query = (await _companyRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrEmpty(code), x => x.Code.Contains(code))
                .WhereIf(!string.IsNullOrEmpty(name),x=>x.Name.Contains(name));
            var result = query.Select(x => new CompanyDto()
            {
                Code = x.Code,
                Name = x.Name
            }).ToList();
            return Ok(result);
        }

        /// <summary>
        /// 获取公司分页
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseResult<List<CompanyDto>>> Getpage(string code = "",string name = "", int page = 1, int pageSize = 10) 
        {
            var query = (await _companyRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrEmpty(code),x=>x.Code.StartsWith(code))
                .WhereIf(!string.IsNullOrEmpty(name),x=>x.Name.StartsWith(name));
            var totalCount = query.Count();
            var result = query.Select(x => new CompanyDto() 
            {
                Code = x.Code,
                Name = x.Name
            })
            .PageBy((page - 1) * pageSize, pageSize)
            .ToList();
            return Ok(result, totalCount);
    }

        /// <summary>
        /// 根据ID获取公司信息
        /// </summary>
        /// <param name="routeId">路由ID</param>
        /// <returns></returns>
        public async Task<HttpResponseResult<CompanyDto>> GetAsync(Guid companyId) 
        {
            var query = (await _companyRepository.GetQueryableAsync())
                .WhereIf(companyId!=null, x => x.Id == companyId);

            var result = query.Select(c => new CompanyDto()
            {
                Code=c.Code,
                Name=c.Name
            }).FirstOrDefault();
            return Ok(result);
        }

        /// <summary>
        /// 创建公司信息
        /// </summary>
        /// <param name="createRouteDto"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> CreateAsync(CompanyDto companyDto) 
        {
            if (string.IsNullOrEmpty(companyDto.Code))
            {
                return Customize(400,"公司编码不能为空");
            }

            if (string.IsNullOrEmpty(companyDto.Code))
            {
                return Customize(400, "公司名称不能为空");
            }
            var entity = new Company() 
            {
                Code = companyDto.Code,
                Name = companyDto.Name
            };

            await _companyRepository.InsertAsync(entity);
            return Ok(201);
        }

        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> DeleteAsync(Guid companyId) 
        {
            await _companyRepository.DeleteAsync(x=>x.Id == companyId);
            return Ok(204);
        }

        /// <summary>
        /// 更新公司信息
        /// </summary>
        /// <param name="updateRouteDto"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> UpdateAsync(UpdateCompanyDto companyDto) 
        {
            var entity = _companyRepository.FirstOrDefaultAsync(x=>x.Id == companyDto.Id).Result;

            if (entity == null) 
            {
                return Customize(400,"公司信息不存在");
            }

            entity.Code = companyDto.Code;
            entity.Name = companyDto.Name;
            await _companyRepository.UpdateAsync(entity);

            return Ok(201);
        }
    }
}
