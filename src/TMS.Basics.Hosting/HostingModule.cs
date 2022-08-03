using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMS.Basics.Application;
using TMS.Basics.EntityFrameworkCore;
using TMS.Basics.Hosting.Filters;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc.Validation;
using Volo.Abp.Autofac;
using Volo.Abp.Json;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace TMS.Basics.Hosting
{
    [DependsOn(
         typeof(AbpAutofacModule),
         typeof(ApplicationModule),
         typeof(AbpSwashbuckleModule),
        typeof(EntityFrameworkCoreModule)
     )]
    public class HostingModule : AbpModule
    {
        #region 中间件注入
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
            //注入会话
            context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            ConfigureCors(context);
            ConfigureMvc(context);
        }
        /// <summary>
        /// MVC中间件注入配置
        /// </summary>
        /// <param name="context"></param>
        private void ConfigureMvc(ServiceConfigurationContext context)
        {
            context.Services.AddControllers(options =>
            {
                // 移除 AbpValidationActionFilter
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpValidationActionFilter)));
                if (filterMetadata != null)
                    options.Filters.Remove(filterMetadata);
                //移除全局异常过滤器
                var errIndex = options.Filters.ToList().FindIndex(filter => filter is ServiceFilterAttribute attr && attr.ServiceType.Equals(typeof(AbpExceptionFilter)));
                if (errIndex > -1)
                    options.Filters.RemoveAt(errIndex);
                //
                options.Filters.Add(typeof(AbpCoreExceptionFilter));
            })
            .AddJsonOptions(opt => { });
            Configure<AbpJsonOptions>(options => options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 跨域注入
        /// </summary>
        /// <param name="context"></param>
        private void ConfigureCors(ServiceConfigurationContext context)
        {
            //跨域配置
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(o => true)
                    .AllowCredentials();
                });
            });
        }
        #endregion
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
