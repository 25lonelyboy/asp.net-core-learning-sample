using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityProvider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AspNetCoreWebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置使用Jwt Bearer身份认证方案
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    //var key = Encoding.ASCII.GetBytes(Const.Secret);

                    var keyPrivate = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath, "key.public.json"));
                    var keyParameter = JsonConvert.DeserializeObject<RSAParameters>(keyPrivate);
                    var rsaSecurityKey = new RsaSecurityKey(keyParameter);

                    options.TokenValidationParameters.IssuerSigningKey = rsaSecurityKey;
                    options.TokenValidationParameters.ValidAudience = "aspnetcoreweb";
                    options.TokenValidationParameters.ValidIssuer = "xcode.me";
                    options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
                    options.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;

                    //Bearer是一种认证信息(token)传输协议
                    //JWT是认证信息(token)的一种加密表现信息
                    //两者实际上并没有必然的关系，也可以通过其他方式传递JWT，也可以通过Bearer协议传递其他形式的token
                    //以下是通过其他方式获取JWT
                    //options.Events = new JwtBearerEvents { 
                    //    OnMessageReceived = context => {
                    //        //通过cookies
                    //        context.Token = context.Request.Cookies["token"];
                    //        //甚至通过queryString
                    //        //context.Token = context.Request.Query["token"];
                    //        return Task.CompletedTask;
                    //    }
                    //};

                    //通过认证框架
                    //通过以下配置，认证中间件会通过地址到认证服务器上查找认证相关的信息
                    //上面的配置都可以不用
                    //options.Authority = "https://wwshare.code.me";
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //设置跨域规则
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowCredentials().AllowAnyHeader());
            app.UseAuthentication();

            app.UseHttpsRedirection();
            //设置默认路由
            app.UseMvcWithDefaultRoute();
        }
    }
}
