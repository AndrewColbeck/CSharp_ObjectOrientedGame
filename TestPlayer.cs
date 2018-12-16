// Title:			4-2P - TestPlayer.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Unit Tests for Player class in Swinadventure 
// Last modified:	6/04/2018
// To Fix:         	Complete!

using NUnit.Framework;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestPlayer
    {
        [Test] // AREYOU: The Player responds correctly to "Are You" request
        public void TestAreYou()
        {
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            bool actual = testPlayer.AreYou("me");
            bool expected = true;
            Assert.AreEqual(expected, actual, "AreYou() is not identifying default identifier correctly.");
        }

        [Test] // LOCATE: The Player can locate items in its inventory
        public void TestLocateItems()
        {
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
            testPlayer.Inventory.Put(testItem);

            // Locate the item and store in GameObject:
            GameObject locatedItem = testPlayer.Locate("TestName");

            // Search Inventory for item:
            bool actual = testPlayer.Inventory.HasItem("a testfirstid");

            bool expected = true;
            Assert.AreEqual(expected, actual, "Item in Players Inventory is not locating correctly.");
        }

        [Test] // LOCATE: The Player returns itself if asked to locate "me" or "inventory":
        public void testLocatePlayerOrInventory()
        {
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            GameObject locatedPlayer = testPlayer.Locate("me");
            GameObject locatedInventory = testPlayer.Locate("inventory");
            bool actual = false;

            if (locatedPlayer == testPlayer && locatedInventory != null)
            {
                actual = true;
            }

            bool expected = true;
            Assert.AreEqual(expected, actual, "Player is not returning itself or its inventory correctly.");
        }

        [Test] // LOCATE: The Player returns a null if asked to locate something it does not have
        public void TestLocateNot()
        {
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            GameObject actual = testPlayer.Locate("non-existent item");
            GameObject expected = null;
            Assert.AreEqual(expected, actual, "Player has retrieved a non-existent item from inventory.");
        }

        [Test] // FULLDESCRIPTION: The Players full description returns correct phrase
        public void TestFullDescription()
        {
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item testItem = new Item(new string[] { "shovel", "spade" }, "a shovel", "a mighty fine shovel");
            testPlayer.Inventory.Put(testItem);

            string actual = testPlayer.FullDescription;
            string expected = "You are carrying: \ta shovel (shovel)\n";
            Assert.AreEqual(expected, actual, "Full description not returning correct phrase.");
        }
    }
}
