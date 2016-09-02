using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Context.Initializers;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Context
{
    public class LeagueDbContext : DbContext
    {
        public LeagueDbContext()
            : base("name=LeagueDatabase")
        {
            Database.SetInitializer<LeagueDbContext>(new LeagueDbInitializer());
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //modelBuilder.HasDefaultSchema("dbo");

            //modelBuilder.Entity<Team>().ToTable("tblTeams");
            //modelBuilder.Entity<Player>().ToTable("tblPlayers"); 

            //enable cascade deleting
            //modelBuilder.Entity<Team>().HasMany(e => e.Players).WithOptional(s => s.Team).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Team>()
            //.HasMany(c => c.Players)
            //.WithOptional(e => e.Team)
            //.HasForeignKey(e => e.TeamId)
            //.WillCascadeOnDelete(false);
        }
    }
}
