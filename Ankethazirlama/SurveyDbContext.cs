using Microsoft.EntityFrameworkCore;

namespace Ankethazirlama.Data
{
    public class SurveyDbContext : IdentityDbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            NewMethod(options);
            this.options = options;
        }

        private void NewMethod(DbContextOptions<SurveyDbContext> options)
        {
            DbContextOptions<SurveyDbContext> dbContextOptions = GetOptions(options);
        }
        // Define your DbSets here, for example:  
        // public DbSet<YourEntity> YourEntities { get; set; }  
    }
}
