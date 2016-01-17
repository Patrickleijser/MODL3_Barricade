using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ForestField : IField
{
    #region Properties
    public IEnumerable<IField> ConnectedFields { get; set; }

    public List<IMoveable> Moveables { get; set; }

    public int CoordX
    {
        get;
        set;
    }

    public int CoordY
    {
        get;
        set;
    }

    public bool IsFirstRow
    {
        get;
        set;
    }

    public bool IsVillage
    {
        get;
        set;
    }
    #endregion

    #region Methods
    public void PlaceMoveable(IMoveable moveable)
    {
        Moveables.Add(moveable);
    }

    public void RemoveMoveable(IMoveable moveable)
    {
        Moveables.Remove(moveable);
    }

    public bool CanPlace(IMoveable moveable)
	{
        if (moveable == typeof(Pawn))
            return true;
        else
            return false;
    }
    #endregion

}

