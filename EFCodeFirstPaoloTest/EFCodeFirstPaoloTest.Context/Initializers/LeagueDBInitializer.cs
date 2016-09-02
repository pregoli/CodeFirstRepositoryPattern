using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Entities;

namespace EFCodeFirstPaoloTest.Context.Initializers
{
    public class LeagueDbInitializer : CreateDatabaseIfNotExists<LeagueDbContext>
    {
        protected override void Seed(LeagueDbContext context)
        {
            var initialPlayers = GetInitialPlayers();
            var initialTeams = GetInitialTeams();

            foreach (var player in initialPlayers)
                context.Players.Add(player);

            foreach (var team in initialTeams)
                context.Teams.Add(team);

            base.Seed(context);
        }

        private IList<Player> GetInitialPlayers()
        {
            IList<Player> initialPlayers = new List<Player>();

            initialPlayers.Add(new Player() { Name = "Standard 1", Surname = "First Standard" });
            initialPlayers.Add(new Player() { Name = "Standard 2", Surname = "Second Standard" });
            initialPlayers.Add(new Player() { Name = "Standard 3", Surname = "Third Standard" });

            return initialPlayers;
        }

        private IList<Team> GetInitialTeams()
        {
            var initialPlayers = GetInitialPlayers();
            IList<Team> initialTeams = new List<Team>();

            initialTeams.Add(new Team() { Name = "Milan", Color = "Red", Players = new List<Player> { initialPlayers [0]} });
            initialTeams.Add(new Team() { Name = "Inter", Color = "Blue", Players = new List<Player> { initialPlayers[1] } });
            initialTeams.Add(new Team() { Name = "Juve", Color = "Yellow", Players = new List<Player> { initialPlayers[2] } });

            return initialTeams;
        }
    }
}
