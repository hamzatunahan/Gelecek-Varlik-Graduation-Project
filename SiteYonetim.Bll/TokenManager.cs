using SiteYonetim.Entity.Dto.DtoUser;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteYonetim.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;
        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public string CreateAccessToken(DtoLogin dtoLogin)
        {
          

            //Claims
            var claims = new[]
            { 
                new Claim(JwtRegisteredClaimNames.Email,dtoLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti,dtoLogin.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,dtoLogin.ApartmanId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,dtoLogin.FullName.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,dtoLogin.IsAdmin.ToString())
                
            };

            var claimmsIdentity = new ClaimsIdentity(claims, "Token");
            //Claim roles
            var claimsRoles = new List<Claim> 
            {
                new Claim("role","Admin"),
                new Claim("role2","User"),
                new Claim(ClaimTypes.Role,dtoLogin.IsAdmin.ToString())
            };

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //şifrelenmiş kimlik oluşturma
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token ayarları
            var token = new JwtSecurityToken
            (
                issuer:configuration["Tokens:Issuer"], // token dagutıcı url
                audience:configuration["Tokens:Audience"],//erişilebilecek apiler
                expires:DateTime.Now.AddDays(1),//token süresi 1 gün
                signingCredentials:cred,
                claims:claimmsIdentity.Claims
            );

            //token oluşturma sınıfı ile örnek alıp üretmek
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };
            return tokenHandler.token;

        }
    }
}
