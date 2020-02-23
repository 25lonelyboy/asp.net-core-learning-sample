using IdentityProvider.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml2;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SamlTokenSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenString = CreateSamlToken();

            Console.WriteLine(tokenString);

            var success = ValidateSamlToken(tokenString);

            Console.WriteLine(success);

            Console.ReadKey();
        }

        static string CreateSamlToken()
        {
            var user = new User
            { 
                Id = 1,
                Name = "123",
                Email = "www.wwshare@163.com",
                Birthday = DateTime.Now.AddYears(-27),
                PhoneNumber = "123456789"
            };
            var tokenHandler = new Saml2SecurityTokenHandler();

            string keyPrivate = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "key.private.json"));
            var keyParameter = JsonConvert.DeserializeObject<RSAParameters>(keyPrivate);
            var rsaSecurityKey = new RsaSecurityKey(keyParameter);

            var tokenDescriptor = new SecurityTokenDescriptor
            { 
                Audience = "aspnetcoreweb",
                Issuer = "xcode.me",
                NotBefore = DateTime.Now,
                Expires = DateTime.UtcNow.AddMinutes(6),
                SigningCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Role, "Manager")
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        static bool ValidateSamlToken(string token)
        {
            var tokenHandler = new Saml2SecurityTokenHandler();

            string keyPrivate = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "key.public.json"));
            var keyParameter = JsonConvert.DeserializeObject<RSAParameters>(keyPrivate);
            var rsaSecurityKey = new RsaSecurityKey(keyParameter);

            var tokenValidateParameter = new TokenValidationParameters
            {
                ValidIssuer = "xcode.me",
                ValidAudience = "aspnetcoreweb",
                IssuerSigningKey = rsaSecurityKey
            };

            ClaimsPrincipal principal = null;
            try
            {
                principal = tokenHandler.ValidateToken(token, tokenValidateParameter, out SecurityToken validatedToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return principal != null && principal.Identity.IsAuthenticated;
        }
    }
}
