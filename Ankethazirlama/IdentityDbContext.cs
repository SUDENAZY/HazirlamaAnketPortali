using Microsoft.EntityFrameworkCore;

namespace Ankethazirlama.Data
{
    public class IdentityDbContext : IdentityDbContextBase
    {
        private readonly DbContextOptions<SurveyDbContext> options;

        public IdentityDbContext(DbContextOptions<SurveyDbContext> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.options = options;
        }

        public override bool Equals(object? obj)
        {
            return obj is IdentityDbContext context &&
                   EqualityComparer<DbContextOptions<SurveyDbContext>>.Default.Equals(this.Options1, context.Options1);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(options);
        }

        private void GetOptions(DbContextOptions<SurveyDbContext> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            throw new NotImplementedException();
        }
    }
}