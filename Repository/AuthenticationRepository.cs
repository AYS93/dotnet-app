using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Shared.Models;
using SharedRepository;

namespace Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly EntityContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<RfToken> _rfTokenContext;

        public AuthenticationRepository(EntityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _rfTokenContext = context.Tokens;
        }

        public DateTime GetExpireTime(int id)
        {
            var date = _context.Tokens.Where(x => x.Id == id && x.IsUsed == false).Select(c => c.ExpireDate).FirstOrDefault();
            return date;
        }

        public IRfToken GetToken(int id, string rToken)
        {
            var token = _context.Tokens.Where(x => x.UserId == id && x.RefreshToken == rToken).FirstOrDefault();
            return token;
        }

        public void InsertToken(IRfToken data)
        {
            var refreshToken = _mapper.Map<RfToken>(data);
            _context.Tokens.Add(refreshToken);
            _context.SaveChanges();
        }

        public void SetIsUsed(int id, string rToken)
        {
            var token = _context.Tokens.Where(x => x.UserId == id && x.RefreshToken == rToken).FirstOrDefault();
            token.IsUsed = true;
            _context.SaveChanges();
        }

        public void SetIsUsedForAll(int id)
        {
            var tokens = _context.Tokens.Where(x => x.UserId == id);
            foreach (var x in tokens)
            {
                x.IsUsed = true;
            }
            _context.SaveChanges();
        }
    }
}
