// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - Path.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	24/05/2018
// To Fix:         	Check Instructions
//
//
using NUnit.Framework;
using System;
namespace SwinAdventure
{
    
    public class Path : IdentifiableObject
    {
		Location _location;
    
        public Path(string[] idents, Location location) : base (idents)
        {
			_location = location;
        }
    
        public void MovePlayer(Player p)
        {
    			p.Location = _location;
        }
    }
}
