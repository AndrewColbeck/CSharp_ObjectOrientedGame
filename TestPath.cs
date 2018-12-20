// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/7-D_Swin-Adventure_Iteration_7_and_8/Swin-Adventure - TestMoveCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Unit Test for Path Class in Swin-Adventure 
// Last modified:	24/05/2018
// To Fix:         	Complete!

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestMoveCommand
    {
        [Test()] // Test whether Path can Move Player between Locations:
        public void TestMovePlayer()
        {
			List<Location> _locations = new List<Location>();
			Player Andrew = new Player("Andrew", "A great student");
            Location Bathroom = new Location("Bathroom", "Room in a house");
			Location Study = new Location("Study", "Study nook");
			Path Hallway = new Path(new string[] { "north", "Hallway in house" }, Bathroom);
			Path Corridor = new Path(new string[] { "south", "Corridor leading south" }, Study);
			_locations.Add(Bathroom);
			_locations.Add(Study);

			Study.AddPath(Hallway);
			Bathroom.AddPath(Corridor);
			Andrew.Location = Bathroom;
			MoveCommand move = new MoveCommand(_locations);

			string actual = move.Execute(Andrew, new string[] { "move", "north" });
			string expected = "Player moved to " + Study.Name;

			Assert.AreEqual(actual, expected, "Player not being located to new location correctly");
        }
    }
}
