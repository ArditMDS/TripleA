using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace TripleA.Model
{
    public class Team : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameTag { get; set; }
        public List<Player> Players { get; set; }

        private double stats;
        public double Stats {
            get => stats; 
            set
            {
                if (stats != value)
                {
                    stats = Math.Round(value, 2);
                    OnPropertyChanged();
                }
            }
        }


        public void SetStatView(string statstype)
        {
            var stats = GetStatsTeam();
            this.Stats = stats.ContainsKey(statstype) ? stats[statstype] : 0;
        }
       

        public Team(Guid id, string name, string nameTag, List<Player> players)
        {
            Id = id;
            Name = name;
            NameTag = nameTag;
            Players = players;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // Méthode pour obtenir les statistiques de l'équipe
        public Dictionary<string, double> GetStatsTeam()
        {
            var teamStats = Players
                .SelectMany(player => player.Statistiques)
                .ToList();

            int totalWins = teamStats.Count(s => s.Winner);
            int totalGames = teamStats.Count;
            int totalKills = teamStats.Sum(s => s.Kills);
            int totalDeaths = teamStats.Sum(s => s.Death);
            int totalAssists = teamStats.Sum(s => s.Assists);
            int totalDegatInflige = teamStats.Sum(s => s.DegatInflige);
            int totalDegatSubit = teamStats.Sum(s => s.DegatSubit);

            double winRate = totalGames == 0 ? 0 : (double)totalWins / totalGames * 100;
            double kda = totalDeaths == 0 ? totalKills + totalAssists : (double)(totalKills + totalAssists) / totalDeaths;
            double dda = totalDegatSubit == 0 ? totalDegatInflige : (double)totalDegatInflige / totalDegatSubit;

            return new Dictionary<string, double>
            {
                { "WinRate", winRate },
                { "KDA", kda },
                { "DDA", dda }
            };

        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
