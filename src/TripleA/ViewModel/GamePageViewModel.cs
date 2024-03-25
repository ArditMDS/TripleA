using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PlayerViewModel> _players;
        public ObservableCollection<PlayerViewModel> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged("Players");
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
                OnPropertyChanged("SubmitName");
            }
        }

        public ICommand SubmitCommand { get; }

        public GamePageViewModel()
        {
            Players = new ObservableCollection<PlayerViewModel>()
            {
                new PlayerViewModel(new Player(1, "Player 1", "P1")),
                new PlayerViewModel(new Player(2, "Player 2", "P2")),
                new PlayerViewModel(new Player(3, "Player 3", "P3")),
                // Add more players as needed
            };

            GameName = ""; // Initial game name
            GameDate = DateTime.Now; // Initial game date

            SubmitCommand = new Command(OnSubmit);
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
                if (player.IsSelected)
                {
                    submittedDataBuilder.AppendLine($"- {player.Name}");
                }
            }

            // Set the SubmittedData property to the built string
            SubmittedData = submittedDataBuilder.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
