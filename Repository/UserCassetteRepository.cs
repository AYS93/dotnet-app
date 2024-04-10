using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Shared.Models;
using SharedRepository;

namespace Repository
{
    public class UserCassetteRepository : IUserCassetteRepository
    {
        private readonly EntityContext _context;
        private readonly IMapper _mapper;

        public UserCassetteRepository(EntityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int NumberOfTaken(int idUser)
        {
            var taken = _context.UserCassettes.Where(x => x.UserId == idUser && x.ReturnDate == null).Count();
            return taken;
        }

        public void Insert(IUserCassette data)
        {
            var userCassette = _mapper.Map<UserCassette>(data);
            _context.UserCassettes.Add(userCassette);
            _context.SaveChanges();
        }

        public IUserCassette FindNotReturned(int idUser, int idCassette)
        {
            var userCassette = _context.UserCassettes.SingleOrDefault(x => x.UserId == idUser && x.CassetteId == idCassette && x.ReturnDate == null);
            return userCassette;
        }
        public void Update(int id, IUserCassette data)
        {
            var userCassette = _context.UserCassettes.Find(id);
            _context.Entry<UserCassette>(userCassette).CurrentValues.SetValues(data);
            _context.SaveChanges();
        }

        public List<ICassette> GetUserCassettes(int id)
        {
            var cassetes = _context.UserCassettes.Include(x => x.Cassette).Where(p => p.UserId == id && p.ReturnDate == null).Select(d => d.Cassette).ToList<ICassette>();
            return cassetes;
        }
    }
}
