using Microsoft.EntityFrameworkCore;

namespace Ankethazirlama.Data
{
    public class IdentityDbContextBase
    {

        private readonly DbContextOptions<SurveyDbContext> options;
        private readonly DbContextOptions<SurveyDbContext> options;
        private readonly DbContextOptions<SurveyDbContext> options;

        public DbContextOptions<SurveyDbContext> Options1 => options;

        public DbContextOptions<SurveyDbContext> GetOptions(DbContextOptions<SurveyDbContext> options)
        {
            return GetOptions();
        }

        private DbContextOptions<SurveyDbContext> GetOptions()
        {
            throw new NotImplementedException();
        }
    }
}