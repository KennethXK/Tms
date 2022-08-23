
using Volo.Abp.Threading;

namespace TMS.EntityFrameworkCore;

public static class TMSEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        TMSGlobalFeatureConfigurator.Configure();
        TMSModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
        });
    }
}
