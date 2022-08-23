using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TMS;

[Dependency(ReplaceServices = true)]
public class TMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TMS";
}
