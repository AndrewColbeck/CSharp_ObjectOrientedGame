// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - CommandProcessor.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			CommandProcessor [Second Buffer design Pattern]
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	24/05/2018
// To Fix:         	Complete!
//
//
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        List<Command> _commands= new List<Command>();
        
        public CommandProcessor(List<Location> locations)
        {
			LookCommand look = new LookCommand();
			MoveCommand move = new MoveCommand(locations);

            // Add commands to list of available options:
			_commands.Add(look);
			_commands.Add(move);
        }
    
        public string Execute(Player player, string command)
        {
			string[] commandInput = command.ToLower().Split();
            
            foreach(Command c in _commands)
            {
                if (c.AreYou(commandInput[0]))
                {
					return c.Execute(player, commandInput);
                }
            }
			return "Re-enter Command";
        }
        
    }
}
