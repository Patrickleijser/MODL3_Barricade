using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarricadeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter desired players: ");

            List<Player> players = new List<Player>();
            Player p = new Player("Patrick");
            Player l = new Player("Walfie" );
            Player a = new Player("Dikke");
            Player y = new Player("Dunne" );
            players.Add(p);
            players.Add(l);
            players.Add(a);
            players.Add(y);
            Game g = new Game(players);
            List<int> dicesThrow = new List<int>();
            while(true)
            {
            }

        }
    }
}
