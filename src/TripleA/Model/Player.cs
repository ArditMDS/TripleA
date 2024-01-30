using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleA.Model
{
    public class Player : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pseudo { get; set; }

        public Player(int id, string name, string pseudo)
        {
            Id = id;
            Name = name;
            Pseudo = pseudo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
