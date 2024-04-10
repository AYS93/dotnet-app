using AutoMapper;
using Models;
using Models.Models;
using Shared.Models;
using SharedRepository;

namespace Repository
{
    public class CassetteRepository : BaseRepository<Cassette, ICassette>, ICassetteRepository
    {
        private readonly EntityContext _context;

        public CassetteRepository(EntityContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public int CountCassette(int idCassette)
        {
            var cassetes = _context.Cassettes.FirstOrDefault(x => x.Id == idCassette).Quantity;
            return cassetes;
        }

        public ICassette GetCassette(int idCassette)
        {
            var cassette = _context.Cassettes.FirstOrDefault(x => x.Id == idCassette);
            return cassette;
        }

        public List<ICassette> GetAll()
        {
            var cassettes = _context.Cassettes.ToList<ICassette>();
            return cassettes;
        }

        public int? getMaxId()
        {
            var itemWithLargestId = _context.Cassettes.OrderByDescending(c => c.Id).FirstOrDefault();

            return itemWithLargestId.Id;
        }
    }
}
