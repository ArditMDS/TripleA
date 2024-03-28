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
        private ObservableCollection<Game> games;
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
            /*Players = new ObservableCollection<PlayerViewModel>()
            {
                new PlayerViewModel(new Player(1, "Player 1", "P1", null)),
                new PlayerViewModel(new Player(2, "Player 2", "P2", null)),
                new PlayerViewModel(new Player(3, "Player 3", "P3", null)),
            };*/

            GameName = ""; // Initial game name
            GameDate = DateTime.Now; // Initial game date

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
            // Create a StringBuilder to build the submitted data string
            StringBuilder submittedDataBuilder = new StringBuilder();

            // Append game name and date
            submittedDataBuilder.AppendLine($"{GameName}");
            submittedDataBuilder.AppendLine($"{GameDate}");

            // Append selected players
            submittedDataBuilder.AppendLine("");
            foreach (var player in Players)
            {
                submittedDataBuilder.AppendLine($"- {player.Name}");
            }

            // Set the SubmittedData property to the built string
            SubmittedData = submittedDataBuilder.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
