using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TMS.Basics.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BasicsDbContext : AbpDbContext<BasicsDbContext>
    {

        #region Entities from the modules
      

        #endregion

        public BasicsDbContext(DbContextOptions<BasicsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
