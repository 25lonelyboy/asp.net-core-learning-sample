using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClaimAuthSample.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using ClaimAuthSample.Extension.Authorization;

namespace ClaimAuthSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            ////基于声明的认证信息构建过程
            ////声明、证件元
            ////以键值对的形式存在
            ////Claim name = new Claim("姓名", "xxx");
            ////可以使用微软定义好的常量
            //Claim name = new Claim(ClaimTypes.Name, "XXX");
            //Claim email = new Claim(ClaimTypes.Email, "894962294@qq.com");
            //Claim role = new Claim(ClaimTypes.Role, "驾驶员");
            ////证件
            //ClaimsIdentity identity = new ClaimsIdentity("身份证");
            //identity.AddClaim(name);
            //identity.AddClaim(email);

            //ClaimsIdentity identity1 = new ClaimsIdentity("驾驶证");
            //identity1.AddClaim(name);
            //identity.AddClaim(email);
            //identity1.AddClaim(role);
            ////当事人,需要传入一个主要证件
            //ClaimsPrincipal user = new ClaimsPrincipal(identity);
            //user.AddIdentity(identity1);

            ////这些证件元信息，后续将用于授权策略中，判断用户是否具有权限
            ////例如角色,根据角色判断权限
            //user.IsInRole("驾驶员");//判断是否具有角色
            ////获取用户具有的角色
            //user.FindAll(c => c.Type == ClaimTypes.Role);
            //user.Claims.Where(c => c.Type == ClaimTypes.Role);
            ////HttpContext.User即上面的当事人
            //var currentUser = HttpContext.User;

            return View();
        }

        /// <summary>
        /// 登陆验证，用户票据颁发基本过程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            ClaimsPrincipal user = null;
            //验证用户名密码，生成用户信息
            if(model.UserName == "admin" && model.Password == "admin")
            {
                var name = new Claim(ClaimTypes.Name, "admin");
                var email = new Claim(ClaimTypes.Email, "xxx@xcode.ww");
                var role1 = new Claim(ClaimTypes.Role, "admin");
                var role2 = new Claim(ClaimTypes.Role, "demo");
                //在声明中添加最后修改时间，用于比对用户信息是否已经变更
                var lastChanged = new Claim("LastChanged", DateTime.Now.ToString());

                var identity = new ClaimsIdentity("证件");
                identity.AddClaim(name);
                identity.AddClaim(email);
                identity.AddClaim(role1);
                identity.AddClaim(role2);
                identity.AddClaim(lastChanged);

                user = new ClaimsPrincipal(identity);
            }
            if (model.UserName == "demo" && model.Password == "demo")
            {
                var name = new Claim(ClaimTypes.Name, "demo");
                var email = new Claim(ClaimTypes.Email, "xxx@xcode.ww");
                var role2 = new Claim(ClaimTypes.Role, "demo");
                var lastChanged = new Claim("LastChanged", DateTime.Now.ToString());

                var identity = new ClaimsIdentity("证件");
                identity.AddClaim(name);
                identity.AddClaim(email);
                identity.AddClaim(role2);
                identity.AddClaim(lastChanged);

                user = new ClaimsPrincipal(identity);
            }
            if(user == null)
            {
                ModelState.AddModelError("error", "无效的用户名和密码!");
                return View(model);
            }

            ////根据用户信息生成票据,使用cookie架构
            //var ticket = new AuthenticationTicket(user, CookieAuthenticationDefaults.AuthenticationScheme);
            //string token = JsonConvert.SerializeObject(ticket);
            ////加密

            ////写入cookie
            //Response.Cookies.Append("wwcokie", token);

            //也可以使用微软提供的方式，包含了加密等操作
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
            return RedirectToAction(nameof(Manage));
        }

        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "demo")]
        //[Authorize(Policy = "RequireAdminAndDemo")]
        [MinimumAgeAuthorize(18)]
        public IActionResult Manage()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return Content("你没有访问权限，请联系管理员!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
