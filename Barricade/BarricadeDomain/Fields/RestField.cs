﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RestField : BaseField
{
    public override bool CanPlace()
    {
        if (Moveables != null)
            return false;
        else
            return true;
    }
}

