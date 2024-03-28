using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TripleA.Model;

namespace TripleA.ViewModels
{
    public class EsportStatsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Team> Teams { get; set; }

        private string _selectedStatType;

        public EsportStatsViewModel()
        {
            Players = new ObservableCollection<Player>();
            Teams = new ObservableCollection<Team>();

            // Initialiser les données de test
            InitializeTestData();

            var rankedTeams = GetTeamsRankedByStat("WinRate");

            Teams.Clear();
            foreach (var team in rankedTeams)
            {
                Teams.Add(team);
            }
        }
        public string SelectedStatType
        {
            get => _selectedStatType;
            set
            {
                if (_selectedStatType != value)
                {
                    _selectedStatType = value;
                    OnPropertyChanged(nameof(SelectedStatType));
                    // Mettez à jour votre vue ou les données ici
                    UpdateRankedTeams(); // Cette méthode doit être implémentée par vous pour mettre à jour les données affichées
                }
            }
        }
        private void UpdateRankedTeams()
        {
            try
            {
                var rankedTeams = GetTeamsRankedByStat(_selectedStatType);
                Teams.Clear();
                foreach (var team in rankedTeams)
                {
                    Teams.Add(team);
                }
            }
            catch (ArgumentException ex)
            {
                // Gérer l'exception si le type de statistique n'est pas valide
                // Vous pourriez par exemple afficher un message d'erreur à l'utilisateur
            }
        }
        // Fonction générique pour classer les équipes selon une statistique
        public List<Team> GetTeamsRankedByStat(string statType)
        {
            if (!new List<string> { "WinRate", "KDA", "DDA" }.Contains(statType))
            {
                throw new ArgumentException("Stat type is not valid. Please use 'WinRate', 'KDA', or 'DDA'.", nameof(statType));
            }

            return Teams
                .Select(team => new
                {
                    Team = team,
                    StatValue = team.GetStatsTeam()[statType]
                })
                .OrderByDescending(ts => ts.StatValue)
                .Select(ts => ts.Team)
                .ToList();
        }

        // Fonction générique pour classer les joueurs selon une statistique
        public List<Player> GetPlayersRankedByStat(string statType)
        {
            if (!new List<string> { "WinRate", "KDA", "DDA" }.Contains(statType))
            {
                throw new ArgumentException("Stat type is not valid. Please use 'WinRate', 'KDA', or 'DDA'.", nameof(statType));
            }

            return Players
                .Select(player => new
                {
                    Player = player,
                    StatValue = player.GetStatsPlayer().ContainsKey(statType) ? player.GetStatsPlayer()[statType] : 0
                })
                .OrderByDescending(ps => ps.StatValue)
                .Select(ps => ps.Player)
                .ToList();
        }

        private void InitializeTestData()
        {
            // Statistiques fictives pour chaque joueur
            var random = new Random();

            // Fonction pour générer des statistiques aléatoires pour un joueur
            List<Statistic> GenerateRandomStats()
            {
                var statsList = new List<Statistic>();
                for (int i = 0; i < 6; i++)
                {
                    statsList.Add(new Statistic(
                        random.Next(2) == 0,
                        random.Next(10),
                        random.Next(10),
                        random.Next(10),
                        random.Next(10000),
                        random.Next(10000),
                        random.Next(300),
                        TimeSpan.FromMinutes(random.Next(20, 40))
                    ));
                }
                return statsList;
            }

            // Création des joueurs
            for (int teamNumber = 1; teamNumber <= 3; teamNumber++)
            {
                var teamPlayers = new List<Player>();
                for (int playerNumber = 1; playerNumber <= 4; playerNumber++)
                {
                    var newPlayer = new Player(playerNumber, $"Joueur {playerNumber} de l'Équipe {teamNumber}", $"Pseudo{playerNumber}", null);
                    newPlayer.Statistiques.AddRange(GenerateRandomStats());
                    teamPlayers.Add(newPlayer);
                    Players.Add(newPlayer); // Ajout du joueur à la liste globale
                }

                // Création de l'équipe et ajout des joueurs à cette équipe
                var newTeam = new Team(Guid.NewGuid(), $"Équipe {teamNumber}", $"E{teamNumber}", teamPlayers);
                Teams.Add(newTeam); // Ajout de l'équipe à la liste globale
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}