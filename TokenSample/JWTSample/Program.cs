using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CreateJWTToken();

            Console.ReadKey();
        }

        static void CreateJWTToken()
        {
            User user = new User() { Id = 1, UserName = "", Email = "yao@163.com", PhoneNumber = "123456" };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Consts.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                //认证信息
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(JwtClaimTypes.Audience, "api"),
                    new Claim(JwtClaimTypes.Issuer, "xcode.me"),
                    new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, user.UserName),
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            Console.WriteLine(tokenString);

            Console.WriteLine(ValidateToken(tokenString));
        }

        static bool ValidateToken(string jwtTokenString)
        {
            var key = Encoding.ASCII.GetBytes(Consts.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var validateParamers = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidAudience = "api",
                ValidIssuer = "xcode.me"
            };

            ClaimsPrincipal principal;
            SecurityToken token;

            try
            {
                principal = tokenHandler.ValidateToken(jwtTokenString, validateParamers, out token);
            }
            catch(SecurityTokenException ex)
            {
                return false;
            }
            return principal != null;
        }
    }
}
