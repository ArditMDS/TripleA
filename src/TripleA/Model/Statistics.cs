using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class Statistic
    {
        public bool Winner { get; set; }
        public int Kills { get; set; }
        public int Death { get; set; }
        public int Assists { get; set; } // Ajoutez ce champ si vous souhaitez inclure les assistances dans les statistiques
        public int DegatInflige { get; set; }
        public int DegatSubit { get; set; }
        public int CS { get; set; } // Creep Score
        public TimeSpan DureePartie { get; set; } // Durée de la partie

        public Statistic(bool winner, int kills, int death, int assists, int degatInflige, int degatSubit, int cs, TimeSpan dureePartie)
        {
            Winner = winner;
            Kills = kills;
            Death = death;
            Assists = assists;
            DegatInflige = degatInflige;
            DegatSubit = degatSubit;
            CS = cs;
            DureePartie = dureePartie;
        }
    }
}
