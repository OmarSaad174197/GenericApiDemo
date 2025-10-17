using GenericDemo.Data;
using GenericDemo.Interfaces;

namespace GenericDemo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext context) => _context = context;

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
                _repositories[typeof(TEntity)] = new GenericRepository<TEntity>(_context);

            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
