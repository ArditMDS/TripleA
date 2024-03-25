using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TripleA.Managers;

namespace TripleA.Model
{
    public class Player : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pseudo { get; set; }
        public Team Team { get; set; } 
        public List<Statistic> Statistiques { get; set; }

        public Player(int id, string name, string pseudo)
        {
            Id = id;
            Name = name;
            Pseudo = pseudo;
            Statistiques = new List<Statistic>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Méthode pour obtenir les statistiques du joueur
        public Dictionary<string, double> GetStatsPlayer()
        {
            int totalWins = Statistiques.Count(s => s.Winner);
            int totalKills = Statistiques.Sum(s => s.Kills);
            int totalDeaths = Statistiques.Sum(s => s.Death);
            int totalAssists = Statistiques.Sum(s => s.Assists); 
            int totalDegatInflige = Statistiques.Sum(s => s.DegatInflige);
            int totalDegatSubit = Statistiques.Sum(s => s.DegatSubit);

            double winRate = Statistiques.Count == 0 ? 0 : (double)totalWins / Statistiques.Count * 100;
            double kda = totalDeaths == 0 ? totalKills + totalAssists : (double)(totalKills + totalAssists) / totalDeaths;
            double dda = totalDegatSubit == 0 ? totalDegatInflige : (double)totalDegatInflige / totalDegatSubit;

            return new Dictionary<string, double>
            {
                { "WinRate", winRate },
                { "KDA", kda },
                { "DDA", dda }
            };
        }


        // Gestion des notifications de changement de propriété
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
