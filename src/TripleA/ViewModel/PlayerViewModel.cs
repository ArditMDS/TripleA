using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private bool _opponentName;
        public bool chosenOpponent
        {
            get { return _opponentName; }
            set
            {
                _opponentName = value;
                OnPropertyChanged();
            }
        }

        public Player Player { get; }

        public string Name => Player.Name;

        public PlayerViewModel(Player player)
        {
            Player = player;
            chosenOpponent = false; // Default to not selected
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
