using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentSample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnvironmentSample
{
    public partial class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //读取配置文件中的设置
            //var version = configuration["AppVersion"];

            #region 读取自定义配置文件demo
            //读取自定义配置文件（json）
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("config.json");
            //IConfiguration config = builder.Build();
            //var str1 = config["SiteName"];
            ////字段用Key读取
            //var str2 = config["detail:userName"];
            ////数据用下标读取
            //var str3 = config["users:0:name"];

            //读取xml配置文件
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddXmlFile("config.xml");
            //IConfiguration config = builder.Build();
            ////多个相同节点时，只能用name来读取
            //var str2 = config["SiteConfig:jerry:age"]; 
            #endregion


            #region 加载内存字典配置
            ////加载内存字典配置
            //var dict = new Dictionary<string, string>
            //{
            //    {"Profile:MachineName", "window"},
            //    {"App:MainWindow:Height", "20"},
            //    {"App:MainWindow:Width", "21"},
            //    {"App:MainWindow:Top", "19"},
            //    {"App:MainWindow:Left", "23"}
            //};
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddInMemoryCollection(dict);
            //IConfiguration config = builder.Build();
            //var str = config["Profile:MachineName"];
            //var str2 = config["App:MainWindow:Height"];
            ////也可以用GetValue方法获取值，并且实现类型的转换和默认值设置
            //var height = config.GetValue<int>("App:MainWindow:Height", 88);

            ////接收一个对象，这里需要获取配置节点，节点中包含对象的属性
            //Window window = new Window();
            //config.GetSection("App:MainWindow").Bind(window);

            ////无需事先new一个对象的方式
            //Window window2 = config.GetSection("App:MainWindow").Get<Window>(); 
            #endregion


            #region 读取环境变量
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            ////加载环境变量配置
            //builder.AddEnvironmentVariables();
            //IConfiguration config = builder.Build();
            //var str = config["windir"]; 
            #endregion


            #region 读取命令行参数
            ////读取命令行参数
            //ConfigurationBuilder builder = new ConfigurationBuilder();
            ////可将命令行参数args传进去,这里模拟一个string[]
            //builder.AddCommandLine(new string[] { "key=value" });
            //IConfiguration config = builder.Build();
            //var str = config["key"]; 
            #endregion


            #region 加载数据库中的配置
            //加载EF配置
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.Add(new EFConfigurationSource(optionsAction => optionsAction.UseInMemoryDatabase("menoryDB")));
            //使用扩展方法
            builder.AddEFConfiguration(optionsAction => optionsAction.UseSqlServer(configuration.GetConnectionString("Defualt")));
            IConfiguration config = builder.Build();
            var str = config["quote2"]; 
            #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Configure ");
            });
        }
    }
}
