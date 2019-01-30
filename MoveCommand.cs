// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - MoveCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	24/05/2018
// To Fix:         	Check Instructions
//
//
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
		List<Location> _locations;
        public MoveCommand(List<Location> locations) : base (new string[] { "move", "go" })
        {
			_locations = locations;
            
        }

		public override string Execute(Player p, string[] commandsArray)
		{
			string result = null;
            foreach(Location l in _locations)
            {
                if (l.LocatePath(commandsArray[1]))
                {
					l.MovePlayer(p, commandsArray[1]);
					result = "Player moved to " + l.Name;
                }
                else
                {
                    Console.WriteLine("Cannot find path " + commandsArray[1]);
                }
            }
			return result;
        }
    }
}
