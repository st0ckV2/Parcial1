using Parcial1.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.API.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
