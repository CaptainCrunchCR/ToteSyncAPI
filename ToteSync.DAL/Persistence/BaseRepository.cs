using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToteSync.DAL.Persistence
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context) 
        {
            _context = context;
        }
        public IQueryable Query => _context.Set<TEntity>();

        public void Add(TEntity objModel)
        {
            _context.Set<TEntity>().Add(objModel);
        }

        public void AddRange(IEnumerable<TEntity> objModel)
        {
            _context.Set<TEntity>().AddRange(objModel);
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, bool isTracked = false)
        {
            return (isTracked) ? _context.Set<TEntity>().AsTracking().FirstOrDefault() :
                _context.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll(bool isTracked = false)
        {
            return (isTracked) ? _context.Set<TEntity>().AsTracking().ToList() :
                _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTracked = false)
        {
            return (isTracked) ? await _context.Set<TEntity>().AsTracking().ToListAsync() :
                await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool isTracked = false)
        {
            return (isTracked) ? await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(predicate) :
              await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, bool isTracked = false)
        {
            return (isTracked) ? _context.Set<TEntity>().AsTracking().Where(predicate).ToList() :
                _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool isTracked = false)
        {
            return (isTracked) ? await _context.Set<TEntity>().AsTracking().Where(predicate).ToListAsync() :
                await _context.Set<TEntity>().AsTracking().Where(predicate).ToListAsync();
        }

        public void Remove(TEntity objModel)
        {
            if (_context.Entry(objModel).State == EntityState.Detached)
                _context.Set<TEntity>().Attach(objModel);

            _context.Set<TEntity>().Remove(objModel);
        }

        public void Update(TEntity objModel)
        {
            if (_context.Entry(objModel).State == EntityState.Detached)
                _context.Set<TEntity>().Attach(objModel);

            _context.Set<TEntity>().Update(objModel);
        }
    }
}
