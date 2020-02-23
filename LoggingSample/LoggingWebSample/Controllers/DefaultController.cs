using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LoggingWebSample.Controllers
{
    public class DefaultController : Controller
    {
        public DefaultController()
        {
            //设置当前控制器不使用默认的状态码处理页
            var statusCodePageFeature = HttpContext.Features.Get<IStatusCodePagesFeature>();
            if(statusCodePageFeature != null)
            {
                statusCodePageFeature.Enabled = false;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}