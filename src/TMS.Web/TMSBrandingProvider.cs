using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TMS.Web;

[Dependency(ReplaceServices = true)]
public class TMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TMS";
}
