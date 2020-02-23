using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Authorize]
    public class HolleWorldController : Controller
    {
        public IActionResult Test()
        {
            return Content("Hello World," + User.Identity.Name);
        }
    }
}