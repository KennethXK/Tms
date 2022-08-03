using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using TMS.Basics.Application.Contracts;

namespace TMS.Basics.Hosting.Filters
{
    public class AbpCoreExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);

            context.Result = new JsonResult(new HttpResponseResult()
            {
                Code = 500,
                Message = context.Exception.Message
            });
            context.ExceptionHandled = true;
        }
    }
}
