using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthSample.mvc.Models;
using AuthSample.mvc.Services;

namespace AuthSample.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        public HomeController(IEmailSender emailSender, ISmsSender smsSender)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
        }
        public IActionResult Index()
        {
            //_emailSender.SendEmailAsync("894962294@qq.com", "Confirm your account", "Please confirm your account by clicking this link: <a href=\"https://localhost:5001/Account/ConfirmEmail?userId=d02896ea-4f05-4a63-9d12-4c8b67c3db4e&code=CfDJ8JGcblpMfXZFvDE21k5YVov4F%2ByhIksDrDSgV7NhzXxwpq0pVkHXYvCSqW%2B8Ze4tWjdZ5mndCxTMiLE5PJ3r9byw4hs7RPk8hBRBzmcjs4rQo%2FxwQ%2BYQ9LKXSytW4KSJrClUwYwG340HaWK9wi4VaF032U1mwid0s60ODGQJ1T9wmdW%2FfDojlgEs4Csy32sm0MmeLdXAKXxhpy2SKt8fzNNLQhPULUa5v%2FlWXvnfXKSrO2fB9RTZ%2FJxx0BwF2t8ZOQ%3D%3D\">link</a>");
            //_smsSender.SendSmsAsync("13570915297", "6666");
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
