using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace RouterSampleCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 基本用法，没有制定Handler的情况下使用默认Handler
            //设置默认Handler
            //var hander = new RouteHandler(context => context.Response.WriteAsync("hello world !"));
            //app.UseRouter(routes => {
            //    routes.DefaultHandler = hander;
            //    routes.MapRoute("default", "/map1");
            //});

            //基本用法之一,没有指定Handler的情况下使用默认Handler，默认Handler也没有就报错
            //app.UseRouter(routes =>
            //{
            //    routes.MapRoute(
            //        name: "defaultRoute",
            //        //可在模板使用正则表达式约束
            //        template: "{controller}/{action}/{id?}",
            //        //默认值写这里
            //        //template: "{controller=home}/{action=index}/{id?}",
            //        //约束参数类型
            //        //template: "{controller}/{action}/{id:int}",
            //        //匹配完action之后，其余的部分全部作为subPath参数
            //        //template: "{controller}/{action}/{*subPath}",
            //        //在参数中使用正则表达式约束
            //        //template: "{controller}/{action}/{id:regex(^\\d{{3,4}}$)}",
            //        defaults: new { controller = "Home", action = "Index" }
            //     );
            //});

            ////没有模板，但是有默认参数的时候，会根据默认参数生成模板
            //app.UseRouter(routes =>
            //{
            //    routes.MapRoute(
            //        name: "defaultRoute",
            //        template: "",
            //        defaults: new { controller = "Home", action = "Index" }
            //     );
            //});

            ////可以这样设置参数约束
            //app.UseRouter(routes =>
            //{
            //    routes.MapRoute(
            //        name: "defaultRoute",
            //        template: "",
            //        defaults: new { controller = "Home", action = "Index" },
            //        constraints: new
            //        {
            //            id = new IntRouteConstraint(),
            //            subPath = new StringRouteConstraint(""),
            //            name = new RegexRouteConstraint("")
            //        }
            //     );
            //});

            //直接匹配路由规则，并通过委托提供处理程序
            //app.UseRouter(routes =>
            //{
            //    routes.MapRoute("{controller}/{action}/{id?}", context => {
            //        return Task.CompletedTask;
            //    });
            //});
            #endregion

            //设置默认的处理程序
            //var hander = new RouteHandler(context => context.Response.WriteAsync("hello world !"));
            //var routeBuilder = new RouteBuilder(app, hander);
            ////此时没有设置处理程序，所以会使用默认的处理程序
            //routeBuilder.MapRoute("default", "book/{yyyy}-{MM}.{ext}");
            //app.UseRouter(routeBuilder.Build());

            //演示路由中间件匹配路由规则
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("/blog/{operation:regex(^(create|edit|delete)$)}/{id:int}", context =>
            {
                //获取路由参数
                return context.Response.WriteAsync(context.GetRouteValue("operation").ToString());
            });
            app.UseRouter(routeBuilder.Build());

            //演示生成虚拟路径
            //var routeBuilder = new RouteBuilder(app);
            //routeBuilder.MapRoute("files/{fileName}.{ext}", context => {
            //    var dictionary = new RouteValueDictionary() { { "fileName", "xcode" }, { "ext", "zip" } };
            //    var vpc = new VirtualPathContext(context, null, dictionary);
            //    var path = routeBuilder.Build().GetVirtualPath(vpc).VirtualPath;
            //    return context.Response.WriteAsync(path);
            //});
            //app.UseRouter(routeBuilder.Build());



            app.Run(async context => {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            });
        }
    }
}
