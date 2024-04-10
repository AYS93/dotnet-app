using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Shared.Models;
using SharedRepository;

namespace Repository
{
    public class UserRepository : BaseRepository<User, IUser>, IUserRepository
    {
        public UserRepository(EntityContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int GetUserIdByEmailAndPassword(string email, string password)
        {
            var id = _dbSet.Where(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower() == password.ToLower()).Select(x => x.Id).FirstOrDefault();
            return id;
        }

        public IUser GetByIdIUser(int id)
        {
            var user = _dbSet.SingleOrDefault(x => x.Id == id);
            return user;
        }

        public IUserExtended GetByIdIUserExtended(int id)
        {
            var user = _dbSet.Include(x => x.UserRoles)
                             .ThenInclude(x => x.Role)
                             .ThenInclude(x => x.RolePermissions)
                             .FirstOrDefault(x => x.Id == id);
            return user;
        }

        public List<IUser> GetAll()
        {
            var users = _dbSet.ToList<IUser>();
            return users;
        }

        public IUser GetUser(string email, string password)
        {
            var user = _dbSet.FirstOrDefault(u => u.Email == email.ToLower() && u.Password.ToLower() == password.ToLower());
            return user;
        }

        public List<int> GetUserPermissions(int id)
        {
            var permissionIds = _context.UserRoles.Where(x => x.UserId == id).SelectMany(x => x.Role.RolePermissions.Select(y => y.PermissionId)).Distinct().ToList();
            return permissionIds;
        }

        public bool IsEmailUnique(string email)
        {
            var exist = _dbSet.FirstOrDefault(x => x.Email == email);
            if (exist == null)
            {
                return true;
            }
            return false;
        }

        public List<User> GetSale(List<int> ids)
        {
            var users = _dbSet.Where(x => ids.Contains(x.Id)).ToList();
            return users;
        }
    }
}
