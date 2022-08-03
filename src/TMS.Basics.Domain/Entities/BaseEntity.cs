using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TMS.Basics.Domain.Entities
{
    public class BaseEntity : Entity<Guid>
    {

        /// <summary>
        /// 创建用户Id
        /// </summary>
        public string? CreateId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string? CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户Id
        /// </summary>
        public string? UpdateId { get; set; }

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
