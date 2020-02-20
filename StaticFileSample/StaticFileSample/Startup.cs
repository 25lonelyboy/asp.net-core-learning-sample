using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StaticFileSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 静态文件中间件
            //设置默认页面，默认查找wwwroot中的 default.htm、default.html、index.htm、index.html，按顺序查找
            //app.UseDefaultFiles();

            ////也可以自定义默认页面
            //app.UseDefaultFiles(new DefaultFilesOptions()
            //{
            //    DefaultFileNames = new string[] { "demo.htm", "demo.html" }
            //});


            //启用目录浏览，以列表的形式查看某个文件夹下面的所有文件
            //app.UseDirectoryBrowser();

            //同样的路径，如果在第一个静态文件中间件中匹配到了文件，就会返回，不会往下匹配

            //项目中的一些静态文件通常不需要权限判断等操作
            //但是用户也无法直接下载，需要使用静态文件中间件才能访问下载
            //默认情况下，asp.net core框架保护项目下的所有文件，只有wwwroot文件夹路径下的才能访问
            //以 http://localhost:5000/sample.zip 这样的url访问
            //app.UseStaticFiles();

            ////程序也可以指定特定的文件夹下的文件可以被用户访问
            //app.UseStaticFiles(new StaticFileOptions
            //{ 
            //    //通过FileProvider指定文件提供者
            //    //可以是本地文件，也可以是云端的文件，只要使用特定的特供者即可
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Files")),
            //    //设置文件访问url， http://localhost:5000/fiels/sample.zip
            //    RequestPath = "/files",
            //    OnPrepareResponse = ctx =>
            //    {
            //        //设置文件缓存
            //        ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=600");
            //    }
            //});

            ////相当于 UseStaticFiles + UseStaticFiles + UseDefaultFiles
            //app.UseFileServer(); 
            #endregion

            //app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "defaultRoute", 
            //        template: "{controller}/{action}/{id?}", 
            //        defaults: new { controller= "Home", action = "Index" }
            //     );
            //});

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
