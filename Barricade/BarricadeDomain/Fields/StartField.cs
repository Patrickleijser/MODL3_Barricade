using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartField : BaseField
{
	public Player Player { get; set; }

    public override bool CanPlace(IMoveable moveable)
    {
        if (Moveables.Count != 0)
            return false;
        else
            return true;
    }

}

