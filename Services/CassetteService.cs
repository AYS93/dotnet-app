using Services.Exceptions;
using Shared.Models;
using SharedRepository;
using SharedServices;

namespace Services
{
    public class CassetteService : ICassetteService
    {
        private readonly ICassetteRepository _cassetteRepositories;

        public CassetteService(ICassetteRepository cassetteRepositories)
        {
            _cassetteRepositories = cassetteRepositories;
        }

        public List<ICassette> GetAllCassettes()
        {
            var cassetes = _cassetteRepositories.GetAll().ToList();
            if (cassetes == null)
            {
                throw new BadRequestException("There is no cassettes");
            }
            return cassetes;
        }

        public void Insert(ICassette cassette)
        {
            if (cassette.Id == 0)
            {
                var id = _cassetteRepositories.getMaxId();
                if (id == null)
                {
                    id = 0;
                }
                cassette.Id = (int)(id + 1);
            }
            _cassetteRepositories.Insert(cassette);
        }

        public void Update(int id, ICassette cassette)
        {
            _cassetteRepositories.Update(id, cassette);
        }
    }
}
