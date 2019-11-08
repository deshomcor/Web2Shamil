using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1Shamil.Models.Classes;

namespace Web1Shamil.Data
{
    public class MContext : DbContext
    {
        public MContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Players> Players { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Uniforms> Uniforms { get; set; }
        public DbSet<Web1Shamil.Models.Classes.Coach> Coach { get; set; }
        public DbSet<PlayersPositions> PlayersPositions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayersPositions>().HasKey(sc => new { sc.PlayersId, sc.PositionsId });
       //     modelBuilder.Entity<Teams>().HasMany(t => t.Players)
       // .WithOne(g => g.Teams)
       // .HasForeignKey(g => g.TeamsId);
       //     modelBuilder.Entity<Stage>().HasMany(s => s.Teams)
       // .WithOne(g => g.Stages)
       // .HasForeignKey(g => g.StageId);
       //     modelBuilder.Entity<Regions>().HasMany(s => s.Teams)
       //.WithOne(g => g.Regions)
       //.HasForeignKey(g => g.RegionsId);
        }


    }

}
