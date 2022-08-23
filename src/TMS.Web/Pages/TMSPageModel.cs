using TMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TMS.Web.Pages;

public abstract class TMSPageModel : AbpPageModel
{
    protected TMSPageModel()
    {
        LocalizationResourceType = typeof(TMSResource);
    }
}
