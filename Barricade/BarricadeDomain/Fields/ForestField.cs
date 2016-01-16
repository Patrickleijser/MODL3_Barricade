using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ForestField : IField
{
	public IEnumerable<Pawn> Pawns { get; set; }

	public void PlacePawn(Pawn pawn)
	{
		throw new System.NotImplementedException();
	}

	public void RemovePawn(Pawn pawn)
	{
		throw new System.NotImplementedException();
	}

	public bool CanPlace()
	{
		throw new System.NotImplementedException();
	}

    public IEnumerable<IField> ConnectedFields { get; set; }

    public int CoordX
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

    public int CoordY
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

