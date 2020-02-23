using Microsoft.AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Authentication.Basic.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreSample
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

            //使用basic认证方案
            services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme).AddBasic(options =>{
                options.Realm = "test";
                //订阅事件，这里写自己的验证逻辑
                options.Events= new BasicAuthenticationEvents
                {
                    OnValidateCredentials = (context) =>
                    {
                        if (context.UserName == context.Password)
                        {
                            Claim userName = new Claim(ClaimTypes.Name, context.UserName);

                            var identity = new ClaimsIdentity(BasicAuthenticationDefaults.AuthenticationScheme);
                            identity.AddClaim(userName);

                            var principal = new ClaimsPrincipal(identity);

                            context.Principal = principal;
                            context.Success();
                        }
                        return Task.CompletedTask;
                    }
                };
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
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
