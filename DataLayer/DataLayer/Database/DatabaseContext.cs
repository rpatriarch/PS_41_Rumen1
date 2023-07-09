using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var User = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                ValidUntil = DateTime.Now.AddYears(10)

            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(User);


            var teacherUser = new DatabaseUser()
            {
                Id = 2,
                Names = "Marcus Vill",
                Password = "12345",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                ValidUntil = DateTime.Now.AddMonths(1)
            };

            var studentUser = new DatabaseUser()
            {
                Id = 3,
                Names = "Chris LeCrow",
                Password = "123456",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                ValidUntil = DateTime.Now.AddMonths(3)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(teacherUser, studentUser);
        }

        // Метод за създаване на директория
        public void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Метод за проверка на съществуването на директория
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
    }
}
