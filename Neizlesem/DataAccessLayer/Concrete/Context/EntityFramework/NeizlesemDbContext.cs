
using DataAccessLayer.Concrete.Context.EntityFramework.Mapping;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework
{
    public class NeizlesemDbContext
        : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NeIzlesemDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<FilmCategory>().HasKey(x => new { x.CategoryId, x.FilmId });
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new FilmMap());
            modelBuilder.ApplyConfiguration(new FilmImageMap());

            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

      
        public DbSet<FilmDetay> FilmDetay { get; set; }
        public DbSet<Yonetmen> Yonetmen { get; set; }
        public DbSet<FilmDetay> FilmDetays { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<FilmImage> FilmImages { get; set; }
        public DbSet<FilmCategory> FilmCategory { get; set; }
    }
}
