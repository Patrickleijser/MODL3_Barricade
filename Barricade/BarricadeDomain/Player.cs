using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player
{
    #region Properties
    public string Name
	{
		get;
		set;
	}

	public Color Color
	{
		get;
		set;
	}

    public IEnumerable<StartField> StartFields
    {
        get;
        set;
    }

	public IEnumerable<Pawn> Pawns
	{
		get;
		set;
	}
    #endregion

    #region Constructor
    public Player(String name)
    {
        Name = name;
    }
    #endregion

    #region Methods
    public Pawn ChoosePawn(int nr)
	{
        Pawn p = Pawns.ElementAt(nr-1);
        return p;
	}

	public void PlacePawn()
	{
		throw new System.NotImplementedException();
    }
    #endregion

}

