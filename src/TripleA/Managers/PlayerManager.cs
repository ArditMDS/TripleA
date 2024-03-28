using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Model;

namespace TripleA.Managers
{
    public class PlayerManager
    {
        public ObservableCollection<Player> Players { get; set;  } = new ObservableCollection<Player>();
    }
}
