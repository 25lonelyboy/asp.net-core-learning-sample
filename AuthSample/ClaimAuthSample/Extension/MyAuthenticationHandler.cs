using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimAuthSample.Extension
{
    public class MyAuthenticationHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
    {
        public AuthenticationScheme Scheme { get; set; }

        protected HttpContext Context { get; private set; }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            //从认证方案存放Token的地方拿到对于认证信息
            //不同方案有所不同，对拿到的Token进行检查
            var cookie = Context.Request.Cookies["mycookie"];
            if(string.IsNullOrEmpty(cookie))
            {
                return Task.FromResult(AuthenticateResult.NoResult()); 
            }
            //检查通过后，对Token进行解密，得到票据
            return Task.FromResult(AuthenticateResult.Success(Deserialize(cookie)));
        }

        private AuthenticationTicket Deserialize(string cookie)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.Redirect("/login");
            return Task.CompletedTask;
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = 403;
            return Task.CompletedTask;
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            Scheme = scheme;
            Context = context;
            return Task.CompletedTask;
        }

        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            //根据用户和方案，构造票据
            var ticket = new AuthenticationTicket(user, properties, Scheme.Name);
            //将票据加密，并根据该方案的协议，写入到相应的地方
            Context.Response.Cookies.Append("mycookie", Serializer(ticket));
            return Task.CompletedTask;
        }

        private string Serializer(AuthenticationTicket ticket)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            //将请求响应中的票据移除
            Context.Response.Cookies.Delete("mycookie");
            return Task.CompletedTask;
        }
    }
}
