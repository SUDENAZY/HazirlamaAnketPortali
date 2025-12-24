using Ankethazirlama.Data;
using Ankethazirlama.Models;
using Microsoft.EntityFrameworkCore;

namespace Ankethazirlama.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync(); // Ensure Microsoft.EntityFrameworkCore is referenced in your project
        }

        public async Task<Survey?> GetByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task AddAsync(Survey entity)
        {
            await _context.Surveys.AddAsync(entity);
        }

        public void Update(Survey entity)
        {
            _context.Surveys.Update(entity);
        }

        public void Delete(Survey entity)
        {
            _context.Surveys.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
