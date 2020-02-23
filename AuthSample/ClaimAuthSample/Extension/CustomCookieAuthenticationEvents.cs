using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        //继承认证时间，重写用户认证方法
        public override Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var user = context.Principal;

            var lastChanged = user.Claims.Where(c => c.Type == "LastChanged").Select(c => c.Value).First();
            if(!string.IsNullOrEmpty(lastChanged))
            {
                //读取数据库信息，比较时间

                //如果时间不一致,就将用户登出
                //context.HttpContext.SignOutAsync();
            }

            return base.ValidatePrincipal(context);
        }
    }
}
