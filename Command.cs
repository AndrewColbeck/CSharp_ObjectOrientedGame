// Title:			SwinAdventure_5-1C - Command.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	18/04/2018
// To Fix:         	Check Instructions


using System;
namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
    
        // CONSTRUCTOR:
        public Command(string[] ids) : base(ids)
        {
        }

        // METHODS:
        public abstract string Execute(Player p, string[] commandsArray);
        
    }
}
