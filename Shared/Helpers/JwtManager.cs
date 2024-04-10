using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shared.Helper
{
    public class JwtManager
    {
        private readonly AppSettingsConfig _configuration;

        public JwtManager(IOptions<AppSettingsConfig> configuration)
        {
            _configuration = configuration.Value;
        }

        public string GenerateToken(int id, List<int> permissionIds)
        {
            var permisionsString = string.Join(",", permissionIds);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.TokenKey);
            var expire = Int32.Parse(_configuration.TokenKeyExpireDate);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Id", id.ToString()),
                        new Claim("permissionIds", permisionsString)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expire),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var createToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createToken);
            return token;
        }

        public string GenerateRefreshToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.RefreshTokenKey);
            var expire = Int32.Parse(_configuration.RefreshTokenKeyExpireDate);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Id", id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(expire),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var createToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createToken);
            return token;
        }
    }
}
