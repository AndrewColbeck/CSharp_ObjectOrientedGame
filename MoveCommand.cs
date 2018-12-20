// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - MoveCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Move Command for Swin Adventure, implemented in Iteration 7 & 8
// Last modified:	24/05/2018
// To Fix:         	Complete
//
//
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
		List<Location> _locations;
        public MoveCommand(List<Location> locations) : base (new string[] { "move", "command" })
        {
			_locations = locations;
            
        }

		public override string Execute(Player p, string[] commandsArray)
		{
			string result = null;

            foreach(Location l in _locations)
            {
                // Check if Path direction (array[1]) matches a path in locations:
                if (l.LocatePath(commandsArray[1]))
                {
					l.MovePlayer(p, commandsArray[1]);
					result = "Player moved to " + l.Name;
                }
            }
			return result;
        }
    }
}
