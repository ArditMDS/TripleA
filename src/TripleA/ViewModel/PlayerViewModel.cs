using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TripleA.Managers;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _playerName;
        private string _playerPseudo;
        private Team _selectedTeam;
        private readonly PlayerManager _playerManager;

        public ObservableCollection<Player> Players { get; private set; }
        public ObservableCollection<Team> AvailableTeams { get; set; } = new ObservableCollection<Team>();

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public string PlayerPseudo
        {
            get => _playerPseudo;
            set
            {
                _playerPseudo = value;
                OnPropertyChanged(nameof(PlayerPseudo));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public Team SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                if (_selectedTeam != value)
                {
                    _selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                    OnPropertyChanged(nameof(CanSubmit));
                }
            }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand DeletePlayerCommand { get; private set; }

        // constructeur
        public PlayerViewModel(PlayerManager playerManager)
        {
            _playerManager = playerManager;
            Players = playerManager.Players;

            AddPlayerCommand = new Command(AddPlayer);
            DeletePlayerCommand = new Command<Player>(DeletePlayer);

            // creation manuelle de quelques équipes
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Alpha", "ALPHA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Beta", "BETA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Gamma", "GAMMA", new List<Player>()));
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void AddPlayer()
        {
            if (!CanSubmit) return;

            var newPlayer = new Player(Players.Count + 1, PlayerName, PlayerPseudo) { Team = SelectedTeam };
            _playerManager.Players.Add(newPlayer);

            // on reinitilise les champs
            PlayerName = string.Empty;
            PlayerPseudo = string.Empty;
            SelectedTeam = null;
        }

        private void DeletePlayer(Player player)
        {
            _playerManager.Players.Remove(player);
        }

        public bool CanSubmit => !string.IsNullOrWhiteSpace(PlayerName) && !string.IsNullOrWhiteSpace(PlayerPseudo) && SelectedTeam != null;
    }
}