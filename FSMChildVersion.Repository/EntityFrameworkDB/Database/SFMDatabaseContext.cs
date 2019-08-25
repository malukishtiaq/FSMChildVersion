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
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<FarmerMeeting> FarmerMeeting { get; set; }
        public DbSet<FarmerVisit> FarmerVisit { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<FieldDay> FieldDay { get; set; }
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
