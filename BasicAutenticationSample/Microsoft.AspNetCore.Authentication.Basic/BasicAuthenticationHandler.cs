using Microsoft.AspNetCore.Authentication.Basic.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.Basic
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        public BasicAuthenticationEvents Event 
        {
            get { return (BasicAuthenticationEvents)base.Events; }
            set { base.Events = value; } 
        }

        protected override Task<object> CreateEventsAsync() => Task.FromResult<object>(new BasicAuthenticationEvents());

        /// <summary>
        /// 根据basic协议，验证票据是否有效
        /// </summary>
        /// <returns></returns>
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorizationHeader = Request.Headers["authorization"];
            if(string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.NoResult();
            }
            if (!authorizationHeader.StartsWith(BasicAuthenticationDefaults.AuthenticationScheme + " ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.NoResult();
            }
            string encodedCredentials = authorizationHeader.Substring(BasicAuthenticationDefaults.AuthenticationScheme.Length).Trim();
            if(string.IsNullOrEmpty(encodedCredentials))
            {
                return AuthenticateResult.Fail("No Credentials");
            }
            string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            var delimiterIndex = decodedCredentials.IndexOf(':');
            if(delimiterIndex == -1)
            {
                return AuthenticateResult.Fail("Invalid Credentials, missing delimiter.");
            }
            var username = decodedCredentials.Substring(0, delimiterIndex);
            var password = decodedCredentials.Substring(delimiterIndex + 1);

            var validateCredentialsContext = new ValidateCredentialsContext(Context, Scheme, Options)
            {
                UserName = username,
                Password = password
            };
            await Event.OnValidateCredentials(validateCredentialsContext);
            if(validateCredentialsContext.Result != null && validateCredentialsContext.Result.Succeeded)
            {
                var ticket = new AuthenticationTicket(validateCredentialsContext.Principal, BasicAuthenticationDefaults.AuthenticationScheme);
                return AuthenticateResult.Success(ticket);
            }
            //if(username == Options.UserName && password == Options.Password)
            //{
            //    Claim userName = new Claim(ClaimTypes.Name, username);
                
            //    var identity = new ClaimsIdentity(BasicAuthenticationDefaults.AuthenticationScheme);
            //    identity.AddClaim(userName);

            //    var principal = new ClaimsPrincipal(identity);

            //    var ticker = new AuthenticationTicket(principal, BasicAuthenticationDefaults.AuthenticationScheme);
            //    return Task.FromResult(AuthenticateResult.Success(ticker));
            //}
            return AuthenticateResult.Fail("Invaild usernam or password.");
        }

        /// <summary>
        /// 咨询策略，根据basic协议返回相应的头部信息
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;
            var headerValue = BasicAuthenticationDefaults.AuthenticationScheme + $" realm=\"{ Options.Realm }\"";
            Response.Headers.Append(HeaderNames.WWWAuthenticate, headerValue);
            return Task.CompletedTask;
        }
    }
}
