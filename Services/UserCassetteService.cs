using AutoMapper;
using Services.Exceptions;
using Services.Models.CassetteServiceModel;
using Services.Models.UserCassetteServiceModel;
using Shared.Dtos;
using Shared.Helpers;
using Shared.Models;
using SharedRepository;
using SharedServices;
using System.Transactions;

namespace Services
{
    public class UserCassetteService : IUserCassetteService
    {
        private readonly IUserCassetteRepository _userCassetteRepositories;
        private readonly ICassetteRepository _cassetteRepositories;
        private readonly UserPrincipal _userPrincipal;
        private readonly IMapper _mapper;

        public UserCassetteService(IUserCassetteRepository userCassetteRepositories, UserPrincipal userPrincipal, ICassetteRepository cassetteRepositories, IMapper mapper)
        {
            _userCassetteRepositories = userCassetteRepositories;
            _cassetteRepositories = cassetteRepositories;
            _userPrincipal = userPrincipal;
            _mapper = mapper;
        }

        public void RentCassette(IRentCassetteDto data)
        {
            var cassette = _cassetteRepositories.GetCassette(data.CasseteId);
            var userCassette = _userCassetteRepositories.FindNotReturned(data.UserId, data.CasseteId);

            if (cassette == null)
            {
                throw new BadRequestException("That cassette doesnt exist!");
            }
            if (_cassetteRepositories.CountCassette(data.CasseteId) == 0)
            {
                throw new BadRequestException("That cassette is not available!");
            }
            if (_userCassetteRepositories.NumberOfTaken(data.UserId) > 2)
            {
                throw new BadRequestException("User already borrow 3 cassette!");
            }
            if (userCassette != null)
            {
                throw new BadRequestException("User already borrow that cassette!");
            }

            var userCassetteModel = new UserCassetteServiceModel()
            {
                UserId = data.UserId,
                CassetteId = data.CasseteId,
                TakeDate = DateTime.UtcNow,
            };

            using var transactionScope = new TransactionScope();

            _userCassetteRepositories.Insert(userCassetteModel);
            var cassetteModel = _mapper.Map<CassetteServiceModel>(cassette);
            cassetteModel.Quantity--;

            _cassetteRepositories.Update(data.CasseteId, cassetteModel);

            transactionScope.Complete();

        }
        public void ReturnCassette(IRentCassetteDto data)
        {
            var cassette = _cassetteRepositories.GetCassette(data.CasseteId);
            var userCassette = _userCassetteRepositories.FindNotReturned(data.UserId, data.CasseteId);

            if (cassette == null)
            {
                throw new BadRequestException("That cassette doesnt exist!");
            }
            if (userCassette == null)
            {
                throw new BadRequestException("User didn't borrow that cassette!");
            }

            using var transactionScope = new TransactionScope();

            var userCassetteModel = _mapper.Map<UserCassetteServiceModel>(userCassette);
            userCassetteModel.ReturnDate = DateTime.Now;
            _userCassetteRepositories.Update(userCassette.Id, userCassetteModel);

            var cassetteModel = _mapper.Map<CassetteServiceModel>(cassette);
            cassetteModel.Quantity++;
            _cassetteRepositories.Update(data.CasseteId, cassetteModel);

            transactionScope.Complete();

        }

        public List<ICassette> GetUserCassettes()
        {
            var id = _userPrincipal.GetUserId();
            var cassetes = _userCassetteRepositories.GetUserCassettes(id.Value);
            if (cassetes == null)
            {
                throw new BadRequestException("There is no cassettes for that users");
            }
            return cassetes;
        }
        public List<ICassette> GetRentedCassetByUserId(int id)
        {
            var cassetes = _userCassetteRepositories.GetUserCassettes(id);
            if (cassetes == null)
            {
                throw new BadRequestException("There is no cassettes for that id");
            }
            return cassetes;
        }
    }
}
