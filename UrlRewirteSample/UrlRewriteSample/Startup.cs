using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UrlRewriteSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(option => { 
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //重写中间件演示
            //var option = new RewriteOptions();
            //option.AddRedirect(@"xcode/(\d+)", "blog/$1")
            //    .AddRewrite(@"baidu/([a-z]{2,3})", "blog/$1", true)
            //    .AddRedirectToHttps();

            //app.UseRewriter(option);

            #region 使用配置文件设置重定向和重写规则
            
            var option = new RewriteOptions();
            //使用Apache配置文件
            using (StreamReader reader = File.OpenText("ApacheConfig.txt"))
            {
                option.AddApacheModRewrite(reader);
            }
            //使用IIS配置文件
            using (StreamReader reader = File.OpenText("IISUrlRewrite.xml"))
            {
                option.AddIISUrlRewrite(reader);
            }
            //使用委托
            option.Add(RewriteHelper.RedirectUrl);
            option.Add(RewriteHelper.RewriteUrl);
            //使用接口
            //option.Add(new CustomRule());

            app.UseRewriter(option);

            #endregion

            app.Run(async (context) =>
            {
                var url = context.Request.Protocol + context.Request.Host + context.Request.Path;
                await context.Response.WriteAsync("Hello World! " + url);
            });
        }
    }
}
