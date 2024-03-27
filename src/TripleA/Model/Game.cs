﻿using System;
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

        // public List<Team> teams { get; set; }

        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public string gameName { get; set; }

        public Game(Guid anId, DateTime aDate, List<Team> theTeams, string theGameName)
        {
            this.id = anId;
            this.date = aDate;
            // this.teams = theTeams;
            this.player1 = player1;
            this.player2 = player2;
            this.gameName = theGameName;
        }
    }
}
