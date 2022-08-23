
using Localization.Resources.AbpUi;
using TMS.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace TMS;

[DependsOn(
    typeof(TMSApplicationContractsModule)
    )]
public class TMSHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TMSResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
