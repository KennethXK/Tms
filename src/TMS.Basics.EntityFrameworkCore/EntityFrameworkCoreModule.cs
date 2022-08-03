using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Domain;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace TMS.Basics.EntityFrameworkCore
{
    [DependsOn(
        typeof(DomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule)
        )]
    public class EntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
            context.Services.AddAbpDbContext<BasicsDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var dbContext = context.ServiceProvider.GetService<BasicsDbContext>();
            if (dbContext != null&& dbContext.Database.GetMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
