using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TMS.Web.Pages;

public class IndexModel : TMSPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
