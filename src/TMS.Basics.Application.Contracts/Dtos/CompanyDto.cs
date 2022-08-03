using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Basics.Application.Contracts.Dtos
{
    public class CompanyDto
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string? CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string? UpdateUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
