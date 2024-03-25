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

        public ICommand AddPlayerCommand { get; private set; }

        public ObservableCollection<Player> Players { get; } = new ObservableCollection<Player>();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _playerName;
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


        private string _playerPseudo;
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

        private Team _selectedTeam;
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


        public ObservableCollection<Team> AvailableTeams { get; set; } = new ObservableCollection<Team>();

        private readonly PlayerManager _playerManager;

        public PlayerViewModel(PlayerManager playerManager)
        {
            // creation manuelle de quelques équipes
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Alpha", "ALPHA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Beta", "BETA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Gamma", "GAMMA", new List<Player>()));

            AddPlayerCommand = new Command(AddPlayer);

            _playerManager = playerManager;
            Players = playerManager.Players;

        }

        private void AddPlayer()
        {
            if (!CanSubmit)
                return; 

            int newId = Players.Count + 1;

            var newPlayer = new Player(newId, PlayerName, PlayerPseudo)
            {
                Team = SelectedTeam
            };

             _playerManager.Players.Add(newPlayer);
            
            PlayerName = string.Empty;
            PlayerPseudo = string.Empty;
            SelectedTeam = null;

            OnPropertyChanged(nameof(PlayerName));
            OnPropertyChanged(nameof(PlayerPseudo));
            OnPropertyChanged(nameof(SelectedTeam));

        }

        public bool CanSubmit
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PlayerName) &&
                       !string.IsNullOrWhiteSpace(PlayerPseudo) &&
                       SelectedTeam != null;
            }
        }
    }
}
