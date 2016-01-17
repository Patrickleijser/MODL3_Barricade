using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarricadeConsole
{
    public class BoardController
    {

        public void DrawBoard(List<IField> fields)
        {
            for (int i = fields.Max(x => x.CoordY) + 1; i-- > 0; )
            {
                string s = "   ";
                string line = "   ";
                for (int j = fields.Max(x => x.CoordX) + 1; j-- > 0; )
                {
                    IField selected = fields.Where(x => x.CoordY == i && x.CoordX == j).FirstOrDefault();
                    if (selected != null)
                    {
                        if(selected.ConnectedFields.Where(x => x.CoordY < selected.CoordY).Count() > 0)
                        {
                            line += " |  ";
                        
                        }
                        else
                        {
                            line += "    ";
                        }
                        switch (selected.GetType().ToString())
                        {
                            case "RestField":
                                s += "(R) ";
                                break;
                            case "ForestField":
                                s += "(F) ";
                                break;
                            default:
                                if (selected.Moveables.Count != 0 && selected.Moveables.First().GetType().ToString() == "Barricade")
                                {
                                    s += "(B) ";
                                }
                                if (selected.Moveables.Count != 0 && selected.Moveables.First().GetType().ToString() == "Pawn")
                                {
                                    Pawn selectedPawn = (Pawn)selected.Moveables.First();
                                    switch (selectedPawn.Color)
                                    {
                                        case Color.Red:
                                            s += "(1) ";
                                            break;
                                        case Color.Blue:
                                            s += "(2) ";
                                            break;
                                        case Color.Yellow:
                                            s += "(3) ";
                                            break;
                                        case Color.Green:
                                            s += "(4) ";
                                            break;
                                    }
                                }
                                if (selected.Moveables.Count == 0)
                                {
                                    s += "( ) ";
                                }
                                break;
                        }
                    }
                    else
                    {
                        line += "    ";
                        s += "    ";
                    }
                    
                }
                Console.WriteLine(s);
                Console.WriteLine(line);
            }
        }

    }
}
