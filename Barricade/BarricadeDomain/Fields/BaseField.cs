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
    public virtual void PlaceMoveable(IMoveable moveable)
	{
        if (Moveables.Count != 0)
            RemoveMoveable(Moveables.First());
        Moveables.Add(moveable);
	}

	public void RemoveMoveable(IMoveable moveable)
	{
        Moveables.Remove(moveable);
	}

    public virtual bool CanPlace(IMoveable moveable)
	{
        if (moveable == typeof(Barricade))
        {
            if (Moveables.Count != 0)
            {
                return false;
            }
            else
            {
                if (this.IsFirstRow)
                    return false;
                else
                    return true;
            }
        }
        else
        {
            return true;
        }
    }
    #endregion

}

