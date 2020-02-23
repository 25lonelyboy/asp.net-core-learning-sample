using IdentityModel;
using IdentityProvider.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IdentityProvider.Controllers
{
    public class TokenController : Controller
    {
        private readonly IHostingEnvironment _env;
        public TokenController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody]LoginModel model)
        {
            if(model.UserName != "admin" || model.Password != "123456")
            {
                return Json(new { Error = "用户名或密码错误!" });
            }

            var user = new User 
            { 
                Id = 1,
                Name = model.UserName,
                Birthday = DateTime.Now.AddYears(27),
                Email = "admin@xcode.me",
                PhoneNumber = "12378292"
            };

            var handler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(Const.Secret);

            //RSA非对称加密
            var keyPrivate = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath, "key.private.json"));
            var keyParameter = JsonConvert.DeserializeObject<RSAParameters>(keyPrivate);
            var rsaSecurityKey = new RsaSecurityKey(keyParameter);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(JwtClaimTypes.Audience, "aspnetcoreweb"),
                    new Claim(JwtClaimTypes.Issuer, "xcode.me"),
                    new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, user.Name),
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                    new Claim(JwtClaimTypes.Role, "Manager")
                }),
                Expires = DateTime.UtcNow.AddMinutes(6),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256Signature)
            };

            var token = handler.CreateToken(tokenDescriptor);

            var tokenString = handler.WriteToken(token);

            return Json(new { Token = tokenString });
        }

        /// <summary>
        /// C#生成RSA密钥对演示
        /// </summary>
        /// <returns></returns>
        public IActionResult GenerateAndSaveKey()
        {
            RSAParameters publicKey, privateKey;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    privateKey = rsa.ExportParameters(true);
                    publicKey = rsa.ExportParameters(false);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }

            var dir = _env.ContentRootPath;
            System.IO.File.WriteAllText(Path.Combine(dir, "key.private.json"), JsonConvert.SerializeObject(privateKey));
            System.IO.File.WriteAllText(Path.Combine(dir, "key.public.json"), JsonConvert.SerializeObject(publicKey));
            return Ok();
        }
    }
}