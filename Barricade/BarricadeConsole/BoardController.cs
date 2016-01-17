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
                string s = "";
                for (int j = fields.Max(x => x.CoordX) + 1; j-- > 0; )
                {
                    if (fields.Where(x => x.CoordY == i && x.CoordX == j).Count() > 0)
                    {
                        switch (fields.Where(x => x.CoordY == i && x.CoordX == j).First().GetType().ToString())
                        {
                            case "RestField":
                                s += "(R)";
                                break;
                            default:
                                s += "( )";
                                break;
                        }
                        
                    }
                    {
                        s += " ";
                    }
                }
                Console.WriteLine(s);
            }
        }
    }
}
