using DzienniczekE.Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace DzienniczekE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasMany(m => m.Grades)
                .WithOne(m => m.Student).HasForeignKey(k => k.StudentId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "db.db3")}");
        }

    }
}
