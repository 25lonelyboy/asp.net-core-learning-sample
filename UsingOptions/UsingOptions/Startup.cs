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
using UsingOptions.Options;

namespace UsingOptions
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
            //添加选项模式
            services.AddOptions();
            //通过配置文件配置选项
            services.Configure<MyOptions>(Configuration);
            //读取配置文件之后，可以修改需要的值
            services.PostConfigure<MyOptions>(options => options.Option2 = 300);
            //通过配置文件读取某一配置节点
            services.Configure<SubOptions>(Configuration.GetSection("subOptions"));
            //硬编码的方式设置配置信息，也可以在这里读取数据库信息
            services.Configure<MemoryOptions>(options => {
                options.Id = 1;
                options.Name = Guid.NewGuid().ToString();
            });
            //读取相同字段的多块配置节点,以name为区分
            services.Configure<SubOptions>("sub1", Configuration.GetSection("subOptions1"));
            services.Configure<SubOptions>("sub2", Configuration.GetSection("subOptions2"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
