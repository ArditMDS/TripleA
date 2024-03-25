using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private Player _editingPlayer;
        private bool _isEditing;
        public ICommand SaveChangesCommand { get; private set; }


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
        public ICommand EditPlayerCommand { get; private set; }
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

            LoadDefaultPlayers();

            IsEditing = false;
            SaveChangesCommand = new Command(SaveChanges, CanSaveChanges);
            EditPlayerCommand = new Command<Player>(EditPlayer);
        }

        private void LoadDefaultPlayers()
        {
            Players.Add(new Player(1, "Alice", "Alice_Super") { Team = AvailableTeams[0] });
            Players.Add(new Player(2, "Bob", "Bobby") { Team = AvailableTeams[0] });
            Players.Add(new Player(3, "Charlie", "Agent007") { Team = AvailableTeams[1] });
        }

        private bool CanSaveChanges() => CanSubmit;

        private void SaveChanges()
        {
            if (_editingPlayer != null)
            {
                // mise à jous des joueur avec les nouvelles valeurs
                _editingPlayer.Name = PlayerName;
                _editingPlayer.Pseudo = PlayerPseudo;
                _editingPlayer.Team = SelectedTeam;

                // mise à jour dans la liste
                OnPropertyChanged(nameof(Players));
            }

            // réinitialiser l'état d'édition
            ResetEditingState();
        }

        private void EditPlayer(Player player)
        {
            _editingPlayer = player;
            PlayerName = player.Name;
            PlayerPseudo = player.Pseudo;
            SelectedTeam = player.Team;
            IsEditing = true;
        }

        private void ResetEditingState()
        {
            _editingPlayer = null;
            IsEditing = false;
            // réinitialiser les valeurs des champs d'entrée
            PlayerName = string.Empty;
            PlayerPseudo = string.Empty;
            SelectedTeam = null;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        public bool CanAddPlayer => !IsEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing == value) return;
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
                OnPropertyChanged(nameof(CanAddPlayer));
                (AddPlayerCommand as Command)?.ChangeCanExecute();
                (SaveChangesCommand as Command)?.ChangeCanExecute();
            }
        }
    }
}