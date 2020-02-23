using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggingWebSample.Models;
using Microsoft.Extensions.Logging;

namespace LoggingWebSample.Controllers
{
    public class HomeController : Controller
    {
        //将日志记录器注入到控制器中就可以使用
        private readonly ILogger logger;
        private readonly ILoggerFactory loggerFactory;

        public HomeController(ILogger logger, ILoggerFactory loggerFactory)
        {
            this.logger = logger;
            this.loggerFactory = loggerFactory;
        }

        public IActionResult Index(int id)
        {
            if (id == 0)
            {
                throw new Exception("异常");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            int a = 0;
            float b = 1;
            var logger1 = LoggerMessage.Define(LogLevel.Information, new EventId(1), "this is value");
            logger1.Invoke(logger, null);

            var logger2 = LoggerMessage.Define<int, float>(LogLevel.Error, new EventId(2), "this is value {a}, {b}");
            logger2.Invoke(logger, a, b, null);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
