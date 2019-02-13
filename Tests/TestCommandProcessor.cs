// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - TestCommandProcessor.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	24/05/2018
// To Fix:         	Check Instructions
//
//
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestCommandProcessor
    {
        [Test()]
        public void LookAtMe()
        {
			List<Location> _locations = new List<Location>();
			CommandProcessor _commandProcessor = new CommandProcessor(_locations);
			Player player = new Player("Andrew", "Top notch bloke");
			string actual = _commandProcessor.Execute(player, "look at me");
			string expected = "Andrew (me)";
			Assert.AreEqual(actual, expected, "Player is not looking at themselves correctly");
        }
        
        public void LookAtSword()
        {
            List<Location> _locations = new List<Location>();
            CommandProcessor _commandProcessor = new CommandProcessor(_locations);
            Player player = new Player("Andrew", "Top notch bloke");
			Item Sword = new Item(new string[] { "sword", "a bronze sword" }, "sword", "a mighty fine sword");

			player.Inventory.Put(Sword);
            
            string actual = _commandProcessor.Execute(player, "look at sword");
            string expected = "sword (a bronze sword)";
            Assert.AreEqual(actual, expected, "Player is not looking at items correctly");
        }
    }
}
