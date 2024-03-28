using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TripleA.Model;
using TripleA.Managers;

namespace TripleA.ViewModel
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<String> _opponentsName;
        private ObservableCollection<Player> _players;
        private ObservableCollection<Game> _games;
        private PlayerManager _playerManager;

        public ObservableCollection<Player> Players
        {
            get
            {
                return _playerManager.Players;
            }
            private set
            {
                _playerManager.Players = value;
            }
        }


        public ObservableCollection<Game> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public ObservableCollection<String> OpponentsName
        {
            get { return _opponentsName; }
            set
            {
                _opponentsName = value;
                OnPropertyChanged();
            }
        }

        private string _gameName;
        public string GameName
        {
            get { return _gameName; }
            set
            {
                _gameName = value;
                OnPropertyChanged("GameName");
            }
        }

        private DateTime _gameDate;
        public DateTime GameDate
        {
            get { return _gameDate; }
            set
            {
                _gameDate = value;
                OnPropertyChanged("GameDate");
            }
        }

        private string _submittedData;

        public string SubmittedData
        {
            get { return _submittedData; }
            set
            {
                _submittedData = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }

        public GamePageViewModel(PlayerManager playerManager)
        {
            _playerManager = playerManager;
            LoadPlayers();

            OpponentsName = new ObservableCollection<String>()
            {
                "Team A",
                "Team B"
            };

            GameName = ""; // Initial game name
            GameDate = DateTime.Now; // Initial game date

            Games = new ObservableCollection<Game>(); // Initialize the Games collection here

            SubmitCommand = new Command(OnSubmit);
        }

        public GamePageViewModel()
        {
        }

        private void LoadPlayers()
        {
            
            foreach (Player player in _playerManager.Players)
            {
                Players.Add(player);
            }
            OnPropertyChanged(nameof(Players));
        }

        private void OnSubmit()
        {
            List<Player> teamAPlayers = new List<Player>();
            List<Player> teamBPlayers = new List<Player>();

            // Separate players into teams A and B based on the selected value in the picker
            foreach (var player in Players)
            {
                if (player.chosenTeam == "Team A")
                {
                    teamAPlayers.Add(player);
                    player.chosenTeam = null;
                }
                else if (player.chosenTeam == "Team B")
                {
                    teamBPlayers.Add(player);
                    player.chosenTeam = null;
                }
            }

            // Create a new Game object with the separated players
            Game newGame = new Game(Guid.NewGuid(), GameDate, teamAPlayers, teamBPlayers, GameName);

            // Add the new game to the collection
            Games.Add(newGame);

            // Clear input fields after submission
            GameName = string.Empty;
            GameDate = DateTime.Now;


            // Notify UI that the collection of games has changed
            OnPropertyChanged(nameof(Games));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
