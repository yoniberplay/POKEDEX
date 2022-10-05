using Microsoft.EntityFrameworkCore;
using Persistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { } 

        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<regions> regions { get; set; }
        public DbSet<tipos> tipos { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nomenclatura Fluent API forma correcta de configurar las entidades nostros mismos.
            #region tables
            modelBuilder.Entity<Pokemons>().ToTable("Pokemons");
            modelBuilder.Entity<regions>().ToTable("regions");
            modelBuilder.Entity<tipos>().ToTable("tipos");
            #endregion

            #region "Primary keys"
            modelBuilder.Entity<Pokemons>().HasKey(p => p.Id); //lambda
            modelBuilder.Entity<regions>().HasKey(r => r.Id);
            modelBuilder.Entity<tipos>().HasKey(t => t.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<regions>()
                .HasMany<Pokemons>(r => r.Pokemons)
                .WithOne(p => p.regions).HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<tipos>()
                .HasMany<Pokemons>(r => r.Pokemons)
                .WithOne(p => p.tipos).HasForeignKey(p => p.PrimaryType).HasForeignKey(p => p.SecondaryType)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"
            #region Pokemons
            modelBuilder.Entity<Pokemons>().Property(p => p.Id).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pokemons>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Pokemons>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Pokemons>().Property(p => p.ImgUrl).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Pokemons>().Property(p => p.PrimaryType).IsRequired();
            modelBuilder.Entity<Pokemons>().Property(p => p.SecondaryType).IsRequired();
            modelBuilder.Entity<Pokemons>().Property(p => p.RegionId).IsRequired();
            #endregion
            #region regions
            modelBuilder.Entity<regions>().Property(r => r.Id).IsRequired();
            modelBuilder.Entity<regions>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<regions>().Property(r => r.Description).IsRequired();

            #endregion
            #region tipos
            modelBuilder.Entity<tipos>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<tipos>().Property(t => t.Id).IsRequired();
            #endregion
            #endregion
        }

    }
}
