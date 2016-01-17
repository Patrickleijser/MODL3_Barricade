using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IField 
{
    int CoordX { get; set; }

    int CoordY { get; set; }

    bool IsFirstRow { get; set; }

    bool IsVillage { get; set; }

	IEnumerable<IField> ConnectedFields { get; set; }
    
    List<IMoveable> Moveables { get; set; }
    
	void PlaceMoveable(IMoveable moveable);

    void RemoveMoveable(IMoveable moveable);

	bool CanPlace();

}

