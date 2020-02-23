using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsingOptions.Models;
using UsingOptions.Options;

namespace UsingOptions.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyOptions options;
        private readonly SubOptions subOptions;
        private readonly SubOptions subOptions1;
        private readonly SubOptions subOptions2;
        public HomeController(IOptions<MyOptions> optionAccessor, IOptions<SubOptions> subOptionAccessor, IOptionsSnapshot<SubOptions> optionsSnapshot)
        {
            options = optionAccessor.Value;
            subOptions = subOptionAccessor.Value;
            //通过name读取对应的选项
            subOptions1 = optionsSnapshot.Get("sub1");
            subOptions2 = optionsSnapshot.Get("sub2");
        }

        public IActionResult Index()
        {
            ViewBag.Option1 = options.Option1;
            ViewBag.Option2 = options.Option2;
            ViewBag.SubOpt1 = subOptions.SubOpt1;
            ViewBag.SubOpt2 = subOptions.SubOpt2;
            ViewBag.subOptions1 = subOptions1.SubOpt1;
            ViewBag.subOptions2 = subOptions2.SubOpt1;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
