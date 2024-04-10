using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Exceptions;
using Services.Models.UserServiceModel;
using Shared.Dtos;
using Shared.Models;
using SharedRepository;
using SharedServices;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepositories;
        private readonly IMapper _mapper;

        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepositories, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepositories = userRepositories;
            _mapper = mapper;
        }

        public IUser GetUserById(int id)
        {
            var user = _userRepositories.GetByIdIUserExtended(id);
            if (user == null)
            {
                throw new BadRequestException("There is no user with that id");
            }
            return user;
        }


        public int GetUserId(ILoginDto dto)
        {
            var userId = _userRepositories.GetUserIdByEmailAndPassword(dto.Email, dto.Password);
            return userId;
        }

        public IUserExtended GetCurrentUser()
        {
            var current = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            var id = int.Parse(current);
            var user = _userRepositories.GetByIdIUserExtended(id);
            if (user == null)
            {
                throw new BadRequestException("There is no user loged in");
            }
            return (IUserExtended)user;
        }

        public List<IUser> GetAllUsers()
        {
            var users = _userRepositories.GetAll().ToList();
            if (users == null)
            {
                throw new BadRequestException("There is no users");
            }
            return users;
        }



        public List<int> UserPermissions(int id)
        {
            return _userRepositories.GetUserPermissions(id);
        }



        public void Register(IRegisterUserDto dto)
        {

            if (!_userRepositories.IsEmailUnique(dto.Email))
            {
                throw new BadRequestException("There is alreay user with this email");
            }
            var user = new UserServiceModel()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
            };
            _userRepositories.Insert(user);
        }

        public void UpdateUser(int id, IUpdateUserDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                throw new BadRequestException("Bad input");
            }
            var dbUser = _userRepositories.GetByIdIUserExtended(id);
            var user = _mapper.Map<UserServiceModel>(dto);
            user.Password = dbUser.Password;
            _userRepositories.Update(id, user);
        }


    }
}
