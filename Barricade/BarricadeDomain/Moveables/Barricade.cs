using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Barricade : IMoveable
{

	public IField IField { get; set; }

	public void Move(IField field) 
    {
		throw new System.NotImplementedException();
	}

}

