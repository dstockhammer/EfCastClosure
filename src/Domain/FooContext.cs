using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCastClosure.Domain
{
    public class FooContext : DbContext
    {
        public DbSet<FooEntity> Foos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FooDb;Trusted_Connection=True;")
                .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
    }
}