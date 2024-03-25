using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Team> AvailableTeams { get; set; } = new ObservableCollection<Team>();

        public PlayerViewModel()
        {
            // creation manuelle de quelques équipes
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Alpha", "ALPHA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Beta", "BETA", new List<Player>()));
            AvailableTeams.Add(new Team(Guid.NewGuid(), "Équipe Gamma", "GAMMA", new List<Player>()));
        }

    }
}
