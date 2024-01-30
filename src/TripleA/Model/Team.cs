using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class Team
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string nameTag { get; set; }
        public List<Player> players { get; set; }

        public Team(Guid anId, string aName, string aNameTag, List<Player> thePlayers)
        {
            this.id = anId;
            this.name = aName;
            this.nameTag = aNameTag;
            this.players = thePlayers;
        }
    }
}
