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
                                s += "( ) ";
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
