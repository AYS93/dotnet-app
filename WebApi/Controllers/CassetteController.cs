using AutoMapper;
using Dto.Incoming;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using SharedServices;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CassetteController : ControllerBase
    {
        private readonly IUserCassetteService _userCassetteService;
        private readonly IMapper _mapper;
        private readonly ICassetteService _casseteService;

        public CassetteController(IUserCassetteService userCassetteService, IMapper mapper, ICassetteService casseteService)
        {
            _userCassetteService = userCassetteService;
            _mapper = mapper;
            _casseteService = casseteService;
        }

        [HttpPost("rentCassete")]
        [HasPermission(Permission.canRentMovies)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RentCassette(RentCassetteDto data)
        {
            _userCassetteService.RentCassette(data);
            return Ok();
        }

        [HttpPost("returnCassete")]
        [HasPermission(Permission.canRentMovies)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ReturnCassette(RentCassetteDto data)
        {
            _userCassetteService.ReturnCassette(data);
            return Ok();
        }

        [HttpGet("GetAllCassettes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var allCassettes = _casseteService.GetAllCassettes();
            var outDto = _mapper.Map<List<Dto.Outgoing.CassetteDto>>(allCassettes);
            return Ok(outDto);
        }

        [HttpGet("GetCurrentUsersCassettes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsersCassettes()
        {
            var allCassettes = _userCassetteService.GetUserCassettes();
            var outDto = _mapper.Map<List<Dto.Outgoing.CassetteDto>>(allCassettes);
            return Ok(outDto);
        }

        [HttpGet("GetCassettesByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCassettesById(int id)
        {
            var allCassettes = _userCassetteService.GetRentedCassetByUserId(id);
            var outDto = _mapper.Map<List<Dto.Outgoing.CassetteDto>>(allCassettes);
            return Ok(outDto);
        }

        [HttpPost("createCassete")]
        [HasPermission(Permission.canRentMovies)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateCassette(CassetteDto data)
        {
            _casseteService.Insert(data);
            return Ok();
        }

        [HttpPut("updateCassete/{id}")]
        [HasPermission(Permission.canRentMovies)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCassette(int id, CassetteDto data)
        {
            _casseteService.Update(id, data);
            return Ok();
        }
    }
}
