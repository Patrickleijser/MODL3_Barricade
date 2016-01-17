using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FinishField : BaseField
{

    public override void PlaceMoveable(IMoveable moveable)
    {
        if(moveable == typeof(Pawn)) {
            // Todo : Yay you won!
        }
    }

}

