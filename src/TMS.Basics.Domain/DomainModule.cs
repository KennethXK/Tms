using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Basics.Domain.Shared;
using Volo.Abp.Modularity;

namespace TMS.Basics.Domain
{
    [DependsOn(
        typeof(DomainSharedModule)
    )]
    public class DomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
