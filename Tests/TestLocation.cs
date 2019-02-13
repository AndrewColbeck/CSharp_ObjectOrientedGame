// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-2C_Swingame_Iteration_5_and_6/Swin-Adventure - TestLocation.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	3/05/2018
// To Fix:         	Check Instructions
//
//
using NUnit.Framework;
using System;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestLocation
    {
        [Test] // LOCATION CAN IDENTIFY ITSELF:
        public void LocationIdentifyItself()
        {
            Location testLocation = new Location("room", "a large room");

            bool actual = testLocation.AreYou("room");
            bool expected = true;
            
            Assert.AreEqual(expected, actual, "AreYou() Method passed through Location is not identifying matches correctly.");
        }
        
        [Test] // LOCATION CAN LOCATE ITEMS THEY HAVE:
        public void LocationCanIdentifyItems()
        {
            Location testLocation = new Location("room", "a large room");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "a Sword", "A mighty fine Sword");

            testLocation.Inventory.Put(sword);

            GameObject actual = testLocation.Locate("sword");
            GameObject expected = sword;

            Assert.AreEqual(expected, actual, "Location not locating Items it has correctly");
        }
        
        [Test] // PLAYERS CAN LOCATE ITEMS IN THEIR LOCATION:
        public void PlayerCanLocateItemsInLocation()
        {
            Location testLocation = new Location("room", "a large room");
            Player andrew = new Player("Andrew", "HD Student");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "a Sword", "A mighty fine Sword");

            testLocation.Inventory.Put(sword);
            andrew.Location = testLocation;

            GameObject actual = andrew.Locate("sword");
            GameObject expected = sword;

            Assert.AreEqual(expected, actual, "Player not able to locate items in Player's location correctly.");
            
        }
        
        
    }
}
