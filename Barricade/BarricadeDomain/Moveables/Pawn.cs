using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pawn : IMoveable
{
	public Color Color { get; set; }

	public IField Position { get; set; }

	public IField IField { get; set; }

	public void Move(IField field)
	{
		throw new System.NotImplementedException();
	}

}

