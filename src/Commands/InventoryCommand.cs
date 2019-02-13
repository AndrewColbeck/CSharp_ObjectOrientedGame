// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/Swin-Adventure - InventoryCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	25/05/2018
// To Fix:         	Check Instructions
//
//
using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace SwinAdventure
{
    public class InventoryCommand : Command
    {
        public InventoryCommand() : base (new string[] { "inventory", "inv" })
        {
        }

		public override string Execute(Player p, string[] commandsArray)
		{
			return p.FullDescription;
		}
    }
}
