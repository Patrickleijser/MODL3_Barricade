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

public class Pawn : IMoveable
{
	public virtual Color Color
	{
		get;
		set;
	}

	public virtual IField Position
	{
		get;
		set;
	}

	public virtual IField IField
	{
		get;
		set;
	}

	public virtual void Move(IField field)
	{
		throw new System.NotImplementedException();
	}

}

