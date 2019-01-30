// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - CommandProcessor.cs
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
    public class CommandProcessor
    {
        List<Command> _commands= new List<Command>();
        
        
        public CommandProcessor(List<Location> locations)
        {
			LookCommand look = new LookCommand();
			MoveCommand move = new MoveCommand(locations);
			PutCommand put = new PutCommand();
			TakeCommand take = new TakeCommand();
			InventoryCommand inventory = new InventoryCommand();
          
			_commands.Add(look);
			_commands.Add(move);
			_commands.Add(put);
			_commands.Add(take);
			_commands.Add(inventory);
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
