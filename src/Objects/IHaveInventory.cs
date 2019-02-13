// Title:			/OneDrive/_Swinburne/_Degree/OOP/Week_05/5-1C_Swingame_Iteration_3_and_4/SwinAdventure_5-1C - IHaveInventory.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	18/04/2018
// To Fix:         	Check Instructions
//
//
using System;
namespace SwinAdventure
{
    public interface IHaveInventory
    {
        // METHODS:
        GameObject Locate(string id);
		GameObject Take(string id);
        
        // PROPERTIES:
        string Name { get; }
    }
}
