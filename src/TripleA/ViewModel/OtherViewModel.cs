using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Managers;
using TripleA.Model;

namespace TripleA.ViewModel
{
    public class OtherViewModel
    {
        // voici le code pour récupérer les Players stockés dans le PlayerManager
        // dans un autre ViewModel

        private readonly PlayerManager _playerManager;

        public OtherViewModel(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public ObservableCollection<Player> Players => _playerManager.Players;
    }
}
