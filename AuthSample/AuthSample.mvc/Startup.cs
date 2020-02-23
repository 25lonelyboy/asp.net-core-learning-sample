using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthSample.mvc.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthSample.mvc.Models;
using AuthSample.mvc.Services;
using Microsoft.AspNetCore.Authentication.QQ;
using Microsoft.AspNetCore.Authentication.WeChat;

namespace AuthSample.mvc
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
            //数据库上下文注入
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.Configure<IdentityOptions>(o => {
            //    //用户登陆错误锁定设置
            //    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);//锁定时间
            //    o.Lockout.MaxFailedAccessAttempts = 5;//锁定的错误次数
            //    o.Lockout.AllowedForNewUsers = true;//是否区别对待新用户
            //    //密码相关设置
            //    o.Password.RequireDigit = true;//是否需要数字
            //    o.Password.RequireUppercase = true;//是否需要大写字母
            //    o.Password.RequireLowercase = true;//是否需要小写字母
            //    o.Password.RequireNonAlphanumeric = true;//是否需要特殊字符
            //    o.Password.RequiredUniqueChars = 3;//密码中最少包含的唯一字符
            //    o.Password.RequiredLength = 6;//密码最小长度
            //    //登陆相关设置
            //    o.SignIn.RequireConfirmedEmail = true;//需要邮箱验证之后才能登陆
            //    o.SignIn.RequireConfirmedPhoneNumber = true;//需要短信认证之后才能拿登陆
            //    //用户名相关设置
            //    o.User.AllowedUserNameCharacters = "";//用户名中允许包含的字符
            //    o.User.RequireUniqueEmail = true;//注册使用的邮箱不能重复,数据库中已有的不能再用
            //    //声明相关配置
            //    o.ClaimsIdentity.RoleClaimType = "RoleName";//声明里面角色的Key
            //    o.ClaimsIdentity.UserIdClaimType = "UserName";//声明里面用户名称的Key
            //});
            ////配置cookie
            //services.ConfigureApplicationCookie(options => {
            //    options.AccessDeniedPath = "/home/AccessDenied";//没有权限，拒绝访问时的路径
            //    options.LoginPath = "/Account/Login";//401时导向的登陆页面
            //    options.Cookie.Name = "mycookie";//cookie名称
            //    options.Cookie.HttpOnly = true;//前端js不可读取cookie
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);//cookie过期时间
            //    options.SlidingExpiration = true;//是否滑动过期，即用户访问系统，是否更新cookie过期时间
            //    options.ReturnUrlParameter = "returnUrl";//queryString中跳转路径的key
            //});

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddAuthentication(o => {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddMicrosoftAccount(config =>
            {
                config.ClientId = "123";
                config.ClientSecret = "456";
            })
            .AddQQ(config =>
            {
                config.AppId = Configuration["Authentication:QQ:AppId"];
                config.AppKey = Configuration["Authentication:QQ:AppKey"];
            })
            .AddWeChat(config =>
            {
                config.AppId = Configuration["Authentication:WeChat:AppId"];
                config.AppSecret = Configuration["Authentication:WeChat:AppSecret"];
            })
            .AddIdentityCookies();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            //读取配置文件中的节点，到对应的配置类中
            services.Configure<SenderOptions>(Configuration.GetSection("SenderOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
