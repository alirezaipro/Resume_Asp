using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Models.Activity;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Models.Education;
using Resume.DAL.Models.User;

namespace Resume.DAL.Context;

public class ResumeContext : DbContext
{
    #region Constructor

    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {
    }

    #endregion

    #region DbSets

    public DbSet<User> Users { get; set; }

    public DbSet<ContactUs> ContactUs { get; set; }

    public DbSet<AboutMe> AboutMe { get; set; }

    public DbSet<Activity> Activities { get; set; }

    public DbSet<Education> Educations { get; set; }

    #endregion

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seed data

        #region User

        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                CreateDate = DateTime.Now,
                Email = "alirezai.pro@gmail.com",
                FirstName = "علی",
                LastName = "رضائی",
                Id = 1,
                IsActive = true,
                Mobile = "09367806232",
                Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B"
            });

        #endregion

        #region AboutMe

        modelBuilder.Entity<AboutMe>()
            .HasData(new AboutMe()
            {
                Bio = "",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                CreateDate = DateTime.Now,
                FirstName = "",
                Email = "",
                LastName = "",
                Location = "",
                Id = 1,
                Mobile = "",
                Position = "",
                ImageName = ""
            });

        #endregion

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}