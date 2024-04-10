using AutoMapper;
using Dto.Incoming;
using Dto.Outgoing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using SharedServices;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getById")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserExtendedDto), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            var userDto = _mapper.Map<UserExtendedDto>(user);
            return Ok(userDto);
        }


        [HttpGet("getCurrent")]
        [ProducesResponseType(typeof(UserExtendedDto), StatusCodes.Status200OK)]
        public IActionResult GetCurrent()
        {
            var current = _userService.GetCurrentUser();
            var user = _mapper.Map<UserExtendedDto>(current);
            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        [HasPermission(Permission.canViewUserModule)]

        public IActionResult GetAll()
        {
            var allUsers = _userService.GetAllUsers();
            //var outDto = allUsers.Select(x => new OutUserDTO { FullName = x.FirstName + " " + x.LastName, Email = x.Email }); 
            var outDto = _mapper.Map<List<UserDto>>(allUsers);
            return Ok(outDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCurrent(int id, [FromBody] UpdateUserDto dto)
        {
            _userService.UpdateUser(id, dto);
            return Ok();
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            _userService.Register(dto);
            return Ok();
        }
    }
}
