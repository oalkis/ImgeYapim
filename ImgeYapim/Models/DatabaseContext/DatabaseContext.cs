using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImgeYapim.Models.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<DJ> DJ { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>();
            modelBuilder.Entity<Crew>();
            modelBuilder.Entity<Slider>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<DJ>();



            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });


        }
     

    }
}