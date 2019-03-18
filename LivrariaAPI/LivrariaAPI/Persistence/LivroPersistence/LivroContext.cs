using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI.Persistence.LivroPersistence
{
    public class LivroContext: DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options)
            : base(options)
        {
        }

        public DbSet<LivroEntity> LivroEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroEntity>().HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
