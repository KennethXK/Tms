
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace TMS;

[DependsOn(
    typeof(TMSDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class TMSApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        TMSDtoExtensions.Configure();
    }
}
