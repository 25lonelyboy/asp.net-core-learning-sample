using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace LoggingSampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 日志基本操作
            //ILoggerFactory factory = new LoggerFactory();
            ////添加控制台日志,也可以设置日志输出最小级别，若不设置则为info
            //factory.AddConsole(LogLevel.Trace);
            ////需要传入一个标记，一般使用全类名，可以根据标记查找到哪里发生异常
            ////ILogger logger = factory.CreateLogger("LoggingSampleConsole。Program");
            ////也可以用泛型的形式
            //ILogger logger = factory.CreateLogger<Program>();

            ////写日志是异步执行的
            ////断点
            //logger.LogTrace("this is a trace {date} {level}.", DateTime.Now, 1);
            ////调试
            //logger.LogDebug(new EventId(200), "this is a debug.");
            ////信息
            //logger.LogInformation("this is a info.");
            ////警告
            //logger.LogWarning("this is a warning.");
            ////错误
            //logger.LogError("this is a error.");
            ////当机
            //logger.LogCritical("this is Critical"); 
            #endregion


            #region 日志分组
            //ILoggerFactory factory = new LoggerFactory();
            ////设置启用日志分组,可以同时启用多种日志输出方式
            //factory.AddConsole(LogLevel.Trace, true).AddConsole();
            //ILogger logger = factory.CreateLogger<Program>();

            //using (logger.BeginScope("this is a scope"))
            //{
            //    int a = 1;
            //    logger.LogInformation("define a = {a}", a);

            //    int b = 1;
            //    logger.LogInformation("define b = {b}", b);

            //    int c = a + b;
            //    logger.LogInformation("define c = {c}", c);
            //} 
            #endregion


            #region 多种日志输出方式
            ////微软自带的日志输出方式
            ////控制台
            ////调试---输出到vs中的输出窗口
            ////EventSource
            ////EventLog -----输出到windows中的事件查看器
            ////TraceSource
            ////Azure服务
            //ILoggerFactory factory = new LoggerFactory();
            ////设置启用日志分组,可以同时启用多种日志输出方式
            //factory.AddConsole(LogLevel.Trace, true).AddDebug();
            //ILogger logger = factory.CreateLogger<Program>();

            //using (logger.BeginScope("this is a scope"))
            //{
            //    int a = 1;
            //    logger.LogInformation("define a = {a}", a);

            //    int b = 1;
            //    logger.LogInformation("define b = {b}", b);

            //    int c = a + b;
            //    logger.LogInformation("define c = {c}", c);
            //} 
            #endregion


            #region 通过配置文件设置日志配置

            //IConfiguration config = new ConfigurationBuilder().
            //    SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("config.json")
            //    .Build();

            //ILoggerFactory factory = new LoggerFactory();
            ////添加控制台日志,也可以设置日志输出最小级别，若不设置则为info
            //factory.AddConsole(config.GetSection("Logging"));
            ////需要传入一个标记，一般使用全类名，可以根据标记查找到哪里发生异常
            ////ILogger logger = factory.CreateLogger("LoggingSampleConsole。Program");
            ////也可以用泛型的形式
            //ILogger logger = factory.CreateLogger<Program>();

            ////写日志是异步执行的
            ////断点
            //logger.LogTrace("this is a trace {date} {level}.", DateTime.Now, 1);
            ////调试
            //logger.LogDebug(new EventId(200), "this is a debug.");
            ////信息
            //logger.LogInformation("this is a info.");
            ////警告
            //logger.LogWarning("this is a warning.");
            ////错误
            //logger.LogError("this is a error.");
            ////当机
            //logger.LogCritical("this is Critical");

            //ILogger logger1 = factory.CreateLogger("Zerodo");

            ////写日志是异步执行的
            ////断点
            //logger1.LogTrace("this is a trace {date} {level}.", DateTime.Now, 1);
            ////调试
            //logger1.LogDebug(new EventId(200), "this is a debug.");
            ////信息
            //logger1.LogInformation("this is a info.");
            ////警告
            //logger1.LogWarning("this is a warning.");
            ////错误
            //logger1.LogError("this is a error.");
            ////当机
            //logger1.LogCritical("this is Critical");
            #endregion

            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddNLog();

            var logger = loggerFactory.CreateLogger<Program>();
            while (true)
            {
                //断点
                logger.LogTrace("this is a trace {date} {level}.", DateTime.Now, 1);
                //调试
                logger.LogDebug(new EventId(200), "this is a debug.");
                //信息
                logger.LogInformation("this is a info.");
                //警告
                logger.LogWarning("this is a warning.");
                //错误
                logger.LogError("this is a error.");
                //当机
                logger.LogCritical("this is Critical");
            }
            
        }
    }
}
