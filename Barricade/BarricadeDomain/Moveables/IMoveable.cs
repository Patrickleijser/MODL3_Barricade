using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IMoveable 
{
    IField Position { get; set; }
	void Move(IField field);

}

