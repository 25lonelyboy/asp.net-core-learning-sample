using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClaimAuthSample.Extension;
using ClaimAuthSample.Extension.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimAuthSample
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
            //配置全局的cookie设置,与下方的cookie中间件搭配 app.UseCookiePolicy();
            //也可以在中间件中通过传入参数配置
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                //cookie添加时触发的事件
                //options.OnAppendCookie = cx => { };
                //cookie删除时触发的事件
                //options.OnDeleteCookie = cx => { };
            });

            //添加内存缓存
            services.AddMemoryCache();

            services.AddAuthentication(options => {
                //添加自己的认证方案
                options.AddScheme<MyAuthenticationHandler>("myHandler", "未晚认证");
            })
                //配置认证方案的cookie设置
                .AddCookie(options => {
                    options.LoginPath = "/home/login";//配置跳转登陆页面的路径
                    options.AccessDeniedPath = "/home/AccessDenied";//配置访问拒绝时跳转的路径
                    //options.LogoutPath = "";//配置登出时跳转的路径
                    //options.Cookie.Path = "";//配置允许传递cookie的访问路径，如/App1/,则App1以下的子路径才会传递cookie
                    //options.Cookie.Domain = "";//配置允许传递cookie的子域名
                    //options.Cookie.HttpOnly = true;//设置cookie在浏览器只读
                    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;//设置cookie传递的策略，即是否需要https

                    //配置登陆事件实现类
                    //options.EventsType = typeof(CustomCookieAuthenticationEvents);

                    //也可以通过配置options.Events中的事件来实现
                    //options.Events.OnValidatePrincipal = async xt => { };

                    //设置票据存储方案
                    options.SessionStore = services.BuildServiceProvider().GetRequiredService<ITicketStore>();
                });

            //同时需要向容器添加该类型的注入
            //services.AddScoped<CustomCookieAuthenticationEvents>();
            services.AddTransient<ITicketStore, MemoryCacheTickeStore>();

            //注入授权策略
            services.AddAuthorization(options => {
                //设置一个策略的某个条件判断失败时，是否执行后续的条件判断
                options.InvokeHandlersAfterFailure = true;

                //设置该策略需要用户拥有某些角色才能访问
                //与
                //options.AddPolicy("RequireAdminAndDemo", policy => policy.RequireRole("admin").RequireRole("demo"));
                //或
                //options.AddPolicy("RequireAdminAndDemo", policy => policy.RequireRole("admin", "demo"));
                //设置该策略需要用户拥有某些声明才能访问
                //options.AddPolicy("RequireEmailClaim", policy => policy.RequireClaim(ClaimTypes.Email));
                //也可以设置声明必须等于某个值
                //options.AddPolicy("RequireEmailClaim", policy => policy.RequireClaim(ClaimTypes.Email, "ylyao@163.com"));
                //设置该策略需要用户的用户名符合要求才能访问
                //options.AddPolicy("RequireUserNameIsAdmin", policy => policy.RequireUserName("admin"));
                //设置该策略只需要用户验证通过
                //options.AddPolicy("RequireAuthened", policy => policy.RequireAuthenticatedUser());
                //设置该策略通过断言实现，即满足响应条件才能访问，可用与较复杂的业务逻辑处理
                //options.AddPolicy("RequireAssertion", policy => policy.RequireAssertion(context => {
                //    //委托返回true即通过
                //    return context.User.HasClaim(c => c.Type == ClaimTypes.Email && c.Value.EndsWith("@163.com"));
                //}));

                //添加自定义的策略
                //options.AddPolicy("AgeMin18", policy => policy.AddRequirements(new MinimumAgeRequirement(18)));
                //也可以通过扩张方法，更加优雅的进行使用
                //options.AddPolicy("AgeMin18", policy => policy.RequireMinAge(18));
            });
            //注入相应的Handler,授权机制会根据授权条件自动查找相应的Handler
            //查看源代码，可以发现微软在上面的AddAuthorization()方法中，也对定义好的Handler进行了注入
            //services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddSingleton<IAuthorizationHandler, MinimumAgeRequirement>();
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options => {
                    //配置某个Page页面的授权策略
                    options.Conventions.AuthorizePage("/Contact", "RequireAssertion");
                    ////配置某个文件夹的授权策略
                    options.Conventions.AuthorizeFolder("/User", "RequireAssertion");
                    //允许某个文件匿名访问
                    options.Conventions.AllowAnonymousToFolder("/News");
                });
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
            //无论多少种认证方案，都只注入这一个中间件
            //中间件内部，通过SchemeProvider变量所有的Handler，找到匹配的Handler
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
