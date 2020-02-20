using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StaticFileSample.Controllers
{
    [Route("[controller]/[action]")]
    public class FileController : Controller
    {
        [Route("[id]")]
        public IActionResult Index(int id)
        {
            return Content(DateTime.Now.ToString() + " " + id);
        }

        public IActionResult GetFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sample.zip");
            return PhysicalFile(path, "application/octet-stream");
        }
    }
}