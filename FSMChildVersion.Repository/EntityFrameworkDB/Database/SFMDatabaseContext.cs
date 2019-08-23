using System;
using System.Diagnostics;
using System.IO;
using FSMChildVersion.Repository.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FSMChildVersion.Repository.EntityFramework.Database
{
    public class SFMDatabaseContext : DbContext
    {
        public DbSet<MakeUp> MakeUp { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public SFMDatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = $"Filename={Path.Combine(Config.LocalDBFile)}";
            optionsBuilder.UseSqlite(path);
        }
    }
}
