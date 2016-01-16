using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BaseField : IField
{
	public Pawn Pawn { get; set; }

	public void PlacePawn(Pawn pawn)
	{
        if (Pawn != null)
            RemovePawn(Pawn);
        Pawn = pawn;
	}

	public void RemovePawn(Pawn pawn)
	{
        pawn.Position = pawn.IField;
	}

	public bool CanPlace()
	{
        return true;
	}
    public IEnumerable<IField> ConnectedFields { get; set; }

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
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public bool IsVillage
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }
}

