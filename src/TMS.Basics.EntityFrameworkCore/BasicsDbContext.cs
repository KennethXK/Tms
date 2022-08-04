using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TMS.Basics.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BasicsDbContext : AbpDbContext<BasicsDbContext>
    {

        #region Entities from the modules
        public DbSet<Company> Company { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public BasicsDbContext(DbContextOptions<BasicsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
