using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Application.Contracts;
using TMS.Basics.Domain;
using Volo.Abp.Modularity;

namespace TMS.Basics.Application
{
    [DependsOn(
       typeof(DomainModule),
       typeof(ApplicationContractsModule)
       )]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //在此处注入依赖项
        }
    }
}
