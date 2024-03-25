using System.ComponentModel;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public Player Player { get; }

        public string Name => Player.Name;

        public PlayerViewModel(Player player)
        {
            Player = player;
            IsSelected = false; // Default to not selected
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
