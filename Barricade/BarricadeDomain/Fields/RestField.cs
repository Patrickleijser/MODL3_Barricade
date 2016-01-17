using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RestField : BaseField
{
    public override bool CanPlace()
    {
        /*if (Moveable != null)
            return false;
        else
            return true;*/
        return true;
    }
}

