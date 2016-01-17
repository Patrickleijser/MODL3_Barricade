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
                        string temp = "";
                        if (selected.Moveables.Count != 0 && selected.Moveables.First().GetType().ToString() == "Barricade")
                        {
                            temp = "(B) ";
                        }
                        if (selected.Moveables.Count != 0 && selected.Moveables.First().GetType().ToString() == "Pawn")
                        {
                            Pawn selectedPawn = (Pawn)selected.Moveables.First();
                            switch (selectedPawn.Color)
                            {
                                case Color.Red:
                                    temp = "(1) ";
                                    break;
                                case Color.Blue:
                                    temp = "(2) ";
                                    break;
                                case Color.Yellow:
                                    temp = "(3) ";
                                    break;
                                case Color.Green:
                                    temp = "(4) ";
                                    break;
                            }
                        }
                        if (selected.Moveables.Count == 0)
                        {
                            if (selected.GetType().ToString() == "RestField")
                            {
                                temp = "(R) ";
                            }
                            if (selected.GetType().ToString() == "ForestField")
                            {
                                temp = "(F) ";
                            }
                            if (selected.GetType().ToString() == "Field" || selected.GetType().ToString() == "FinishField" ||(selected.GetType().ToString() == "StartField" && selected.Moveables.Count == 0))
                            {
                                temp = "( ) ";
                            }
                        }
                        if(selected.ConnectedFields.Where(x => x.CoordY < selected.CoordY).Count() > 0)
                        {
                            line += " |  ";
                        
                        }
                        else
                        {
                            line += "    ";
                        }
                        s += temp;
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
