using gurusoft_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace gurusoft_backend.Infrastructure.Persistence
{
    public class NumerosPrimosDbContext : DbContext
    {
        public NumerosPrimosDbContext(DbContextOptions<NumerosPrimosDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost; 
        //        Initial Catalog=NumerosPrimosGuru;user id=sa;password=admin123")
        //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //    .EnableSensitiveDataLogging();
        //}

        public DbSet<NumerosPrimos>? NumerosPrimos { get; set; }
    }
}
