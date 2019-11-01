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
        public DbSet<Web1Shamil.Models.Classes.Coach> Coach { get; set; }
    }
}
