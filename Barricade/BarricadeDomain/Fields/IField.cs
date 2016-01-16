using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IField 
{
    int CoordX { get; set; }

    int CoordY { get; set; }

	IEnumerable<IField> ConnectedFields { get; set; }
    
	void PlacePawn(Pawn pawn);

	void RemovePawn(Pawn pawn);

	bool CanPlace();

}

