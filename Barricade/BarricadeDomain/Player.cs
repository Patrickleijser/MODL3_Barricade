using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeDomain
{
    class Player
    {
        public String Name { get; private set; }
        public String Color { get; set; }
        public List<Pawn> Pawns { get; set; }

        public IField StartField { get; set; }

        public Player(String name)
        {
            Name = name;
        }
    }
}
