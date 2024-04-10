using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using Services.Models.TokenServiceModel;
using Shared.Dtos;
using Shared.Helper;
using Shared.Models;
using SharedRepository;
using SharedServices;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _tokenRepositories;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly AppSettingsConfig _configuration;
        private readonly IUserRepository _userRepositories;
        private readonly JwtManager _jwtManager;

        public AuthenticationService(IAuthenticationRepository tokenRepositories, IMapper mapper, IUserService userService, IOptions<AppSettingsConfig> configuration, IUserRepository userRepositories, JwtManager jwtManager)
        {
            _tokenRepositories = tokenRepositories;
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration.Value;
            _userRepositories = userRepositories;
            _jwtManager = jwtManager;
        }

        public ILoginResponseDto Login(ILoginDto dto)
        {
            var user = _userRepositories.GetUser(dto.Email, dto.Password);
            if (user == null)
            {
                throw new BadRequestException("User not exist");
            }
            var token = this.GenerateToken(user.Id);
            var refreshToken = _jwtManager.GenerateRefreshToken(user.Id);
            var response = new LoginResponseServiceModel();
            response.Token = token;
            response.RefreshToken = refreshToken;
            this.Insert(refreshToken, user.Id);
            return response;
        }

        public ILoginResponseDto Refresh(ITokenRefreshDto dto)
        {
            string refreshToken = dto.RefreshToken;

            var id = this.ValidateCurrentToken(refreshToken);

            var userToken = _tokenRepositories.GetToken(id, refreshToken);

            if (userToken.IsUsed == true)
            {
                _tokenRepositories.SetIsUsedForAll(id);
                throw new BadRequestException("Error");
            }


            var newAccessToken = GenerateToken(id);
            var newRefreshToken = _jwtManager.GenerateRefreshToken(id);

            this.Insert(newRefreshToken, id);
            _tokenRepositories.SetIsUsed(id, refreshToken);

            return new LoginResponseServiceModel()
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public int ValidateCurrentToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.RefreshTokenKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                return userId;
            }
            catch (Exception)
            {
                throw new UnauthorizedException();
            }

        }

        public void Revoke(string token)
        {
            var id = ValidateCurrentToken(token);
            _tokenRepositories.SetIsUsed(id, token);
        }

        private string GenerateToken(int id)
        {
            var permissionIds = _userRepositories.GetUserPermissions(id);
            string token = _jwtManager.GenerateToken(id, permissionIds);

            return token;
        }

        public void Insert(string refreshToken, int id)
        {
            var rfToken = new TokenServiceModel
            {
                RefreshToken = refreshToken,
                IsUsed = false,
                ExpireDate = DateTime.UtcNow.AddDays(7),
                UserId = id
            };

            _tokenRepositories.InsertToken(rfToken);
        }
    }
}
