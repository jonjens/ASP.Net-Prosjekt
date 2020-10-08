using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodingChallengeAsp.Models;

namespace CodingChallengeAsp.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext (DbContextOptions<FootballContext> options)
            : base(options)
        {
        }

        public FootballContext()
        {
        }

        public DbSet<Player> Player { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Sponsor> Sponsor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerSponsor>().HasKey(ps => new { ps.PlayerId, ps.SponsorId });
        }

        public DbSet<CodingChallengeAsp.Models.PlayerSponsor> PlayerSponsor { get; set; }

        public DbSet<CodingChallengeAsp.Models.MapModel> MapModel { get; set; }


    }
}
