using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class TeamStatistics : Statistic
    {
        public TeamStatistics(bool winner, int kills, int death, int assists, int degatInflige, int degatSubit, int cs, TimeSpan dureePartie) : base(winner, kills, death, assists, degatInflige, degatSubit, cs, dureePartie)
        {
        }
    }
}
