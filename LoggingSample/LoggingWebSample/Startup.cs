using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingWebSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddLogging(builder => 
            //{
            //    builder.ClearProviders();
            //    builder.AddConsole();
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //使用状态码错误页,这种情况下出现404等状态时，就使用以下的响应方式
            //app.UseStatusCodePages(async context => {
            //    context.HttpContext.Response.ContentType = "text/plain";
            //    await context.HttpContext.Response.WriteAsync($"this is status code : { context.HttpContext.Response.StatusCode }");
            //});

            //app.UseStatusCodePages("text/plain", "this is status code error.");
            //当出现404状态码时,跳转到一个自定义的错误页面
            //app.UseStatusCodePagesWithRedirects("/Error/NotFoundPage");
            //当出现404等状态码时，执行自定义的错误页面，然后返回给用户，url地址不改变
            app.UseStatusCodePagesWithReExecute("/Error/NotFoundPage");

            if (env.IsDevelopment())
            {
                //开发环境错误页面，会在发生异常时显示错误信息，有利于调试
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
