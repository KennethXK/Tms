using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace TMS;

[DependsOn(
    typeof(TMSDomainModule),
    typeof(TMSApplicationContractsModule)
    )]
public class TMSApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TMSApplicationModule>();
        });
    }
}
