using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BaseField : IField
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
        /*if (Moveable != null)
            RemoveMoveable(Moveable);
        Moveable = moveable;*/
	}

	public void RemoveMoveable(IMoveable moveable)
	{
        //moveable.Position = moveable.Position;
	}

	public virtual bool CanPlace()
	{
        return true;
    }
    #endregion

}

