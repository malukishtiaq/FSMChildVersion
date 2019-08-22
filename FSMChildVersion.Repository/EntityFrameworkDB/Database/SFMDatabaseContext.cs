using System.IO;
using FSMChildVersion.Repository.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FSMChildVersion.Repository.EntityFramework.Database
{
    public class SFMDatabaseContext : DbContext
    {
        public DbSet<MakeUp> MakeUp { get; set; }
        public DbSet<User> User { get; set; }
        public SFMDatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Path.Combine(Config.LocalDBFile)}");
        }
    }
}
