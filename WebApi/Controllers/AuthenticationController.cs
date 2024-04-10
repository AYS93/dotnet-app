using AutoMapper;
using Dto.Incoming;
using Dto.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _tokenService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var response = _tokenService.Login(dto);
            var responseDto = _mapper.Map<LoginResponseDto>(response);
            return Ok(responseDto);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult RefreshToken(TokenRefreshDto tokenDto)
        {
            var response = _tokenService.Refresh(tokenDto);
            var responseDto = _mapper.Map<LoginResponseDto>(response);
            return Ok(responseDto);
        }
    }
}
