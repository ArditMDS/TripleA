using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class Game
    {
        public Guid id { get; set; }
        public DateTime date { get; set; }
        public List<Player> playersTeamA { get; set; }
        public List<Player> playersTeamB { get; set; }

        public string gameName { get; set; }

        public Game(Guid anId, DateTime aDate, List<Player> thePlayersTeamA, List<Player> thePlayersTeamB, string theGameName)
        {
            this.id = anId;
            this.date = aDate;
            this.playersTeamA = thePlayersTeamA;
            this.playersTeamB = thePlayersTeamB;
            this.gameName = theGameName;

            foreach (Player player in this.playersTeamA)
            {
                
                if (player.Statistiques == null)
                {
                    player.Statistiques = new List<Statistic>();
                }

                
                player.Statistiques.Add(GenerateRandomStats());
            }
            foreach (Player player in this.playersTeamB)
            {
                
                if (player.Statistiques == null)
                {
                    player.Statistiques = new List<Statistic>();
                }

                
                player.Statistiques.Add(GenerateRandomStats());
            }
        }
        public Statistic GenerateRandomStats()
        {
            var random = new Random();

            Statistic randomStat = new Statistic(
                    random.Next(2) == 0,
                    random.Next(10),
                    random.Next(10),
                    random.Next(10),
                    random.Next(10000),
                    random.Next(10000),
                    random.Next(300),
                    TimeSpan.FromMinutes(random.Next(20, 40))
                );
            
            return randomStat;
        }
    }
}
