using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TMS.Basics.Domain.Entities
{
    public class Company : BaseEntity
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>
        public string? Code { get; set; }

    }
}
