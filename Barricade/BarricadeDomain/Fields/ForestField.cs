﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ForestField : IField
{
	public virtual IEnumerable<Pawn> Pawns
	{
		get;
		set;
	}

	public virtual void PlacePawn(Pawn pawn)
	{
		throw new System.NotImplementedException();
	}

	public virtual void RemovePawn(Pawn pawn)
	{
		throw new System.NotImplementedException();
	}

	public virtual bool CanPlace()
	{
		throw new System.NotImplementedException();
	}

}
