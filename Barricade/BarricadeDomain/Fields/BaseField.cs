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

public abstract class BaseField : IField
{
	public virtual bool IsVillage
	{
		get;
		set;
	}

	public virtual IField FieldAbove
	{
		get;
		set;
	}

	public virtual IField FieldBelow
	{
		get;
		set;
	}

	public virtual IField FieldLeft
	{
		get;
		set;
	}

	public virtual IField FieldRight
	{
		get;
		set;
	}

	public virtual Pawn Pawn
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
