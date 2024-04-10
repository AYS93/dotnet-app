using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using SharedRepository;

namespace Repository
{
    public abstract class BaseRepository<Entity, IEntity> : IRepository<IEntity> where Entity : class, IEntity
    {
        protected readonly EntityContext _context;
        protected readonly DbSet<Entity> _dbSet;
        protected readonly IMapper _mapper;

        public BaseRepository(EntityContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context?.Set<Entity>();
            _mapper = mapper;
        }
        public void Update(int id, IEntity type)
        {
            var record = _dbSet.Find(id);
            _context.Entry<Entity>(record).CurrentValues.SetValues(type);
            _context.SaveChanges();
        }
        public void Insert(IEntity type)
        {
            var record = _mapper.Map<Entity>(type);
            _dbSet.Add(record);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = _dbSet.Find(id);
            _dbSet.Remove(record);
            _context.SaveChanges();
        }

        public IQueryable<IEntity> GetQueryable()
        {
            var result = _dbSet.AsQueryable()
                                 .AsNoTracking();
            return result;
        }
    }
}
