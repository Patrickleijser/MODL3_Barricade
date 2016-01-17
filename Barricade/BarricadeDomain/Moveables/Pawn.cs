using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pawn : IMoveable
{
	public Color Color { get; set; }

	public IField Position { get; set; }

    public void Move(IField oldField, IField field) 
	{
        IMoveable moveable = oldField.Moveables.First();
        field.PlaceMoveable(moveable);
        oldField.RemoveMoveable(moveable);
        Position = field;
	}

}

