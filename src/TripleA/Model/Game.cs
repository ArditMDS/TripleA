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
        public List<Player> players { get; set; }
        public string gameName { get; set; }

        public Game(Guid anId, DateTime aDate, List<Player> thePlayers, string theGameName)
        {
            this.id = anId;
            this.date = aDate;
            this.players = thePlayers;
            this.gameName = theGameName;
        }
    }
}
