using Ankethazirlama.Data;
using Microsoft.EntityFrameworkCore;

namespace Ankethazirlama.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SurveyDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(SurveyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _table = context.Set<T>() ?? throw new InvalidOperationException($"DbSet for type {typeof(T).Name} could not be initialized.");
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
