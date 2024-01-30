using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class Game
    {
        public Guid id { get; set; }
        public DateTime date { get; set; }
        public List<Team> teams { get; set; }
        public string gameName { get; set; }

        public Game(Guid anId, DateTime aDate, List<Team> theTeams, string theGameName)
        {
            this.id = anId;
            this.date = aDate;
            this.teams = theTeams;
            this.gameName = theGameName;
        }
    }
}
