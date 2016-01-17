using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeConsole
{
    public class GameController
    {
        private Game _game;
        private BoardController _board;
        private Player[] playerDeposit = new Player[] { new Player("Patrick"), new Player("Walfie"), new Player("Dikke"), new Player("Dunne") };
        public GameController()
        {
            initGame();
            RunTurns();
        }

        private void initGame()
        {
            Console.WriteLine("Enter desired players: ");
            bool validNumber = false;
            int numberOfPlayers = 0;
            while (!validNumber)
            {
                validNumber = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
                if(!(numberOfPlayers >= 2 && numberOfPlayers <= 4))
                {
                    validNumber = false;
                    Console.WriteLine("Invalid input. Try again!");
                }
            }
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(playerDeposit[i]);
            }
            _game = new Game(players);
            _board = new BoardController();
            foreach (Player player in _game.Players)
            {
                Console.WriteLine("Player: " + player.Name + " " + player.Color);
            }
            Console.WriteLine("Selecting random starting player: "+_game.activePlayer.Name + " selected.");
        }

        private void RunTurns()
        {
            while (true)
            {
                _board.DrawBoard(_game.Fields);
                ExecuteTurn();
                SwitchTurn();
            }
        }

        private void ExecuteTurn()
        {
            int diceNumber = _game.ThrowDice();
            Console.WriteLine("Throwing dice......");
            Console.WriteLine(_game.activePlayer.Name+" threw "+diceNumber);
            Console.WriteLine("Choose pawn by coord X-coord Y: ");
            Pawn p = SelectPawn();
            Console.WriteLine("Choose new posistion by coord X-coord Y:");
            MovePawn(p,diceNumber);
            
        }

        private Pawn SelectPawn()
        {
            int nr = -1;
            while (true)
            {
                string s = Console.ReadLine();
                Int32.TryParse(s, out nr);
                if (nr != -1)
                {
                    return _game.ChoosePawn(nr);
                }
                Console.WriteLine("Invalid coords try again");
            }
        }

        private void MovePawn(Pawn p,int steps)
        {
            int coordx = -1;
            int coordy = -1;
            while (true)
            {
                string[] s = Console.ReadLine().Split('-');
                Int32.TryParse(s[0], out coordx);
                Int32.TryParse(s[1], out coordy);
                if (coordx != -1 && coordy != -1)
                {
                    IField targetField = _game.Fields.Where(x => x.CoordX == coordx && x.CoordY == coordy).FirstOrDefault();
                    if (_game.validMove(p.Position,targetField,steps))
                    {
                        if (targetField != null && targetField.CanPlace(p))
                        {
                            p.Move(p.Position, targetField);// targetField.PlaceMoveable(p);
                        }
                        break;
                    }
                }
                Console.WriteLine("Invalid coords try again");
            }
        }

        private void SwitchTurn()
        {
            _game.ChangeTurn();
        }
    }
}
