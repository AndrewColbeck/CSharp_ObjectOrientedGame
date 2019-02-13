// Title:			SwinAdventure_5-1C - TestBag.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	12/04/2018
// To Fix:         	Check Instructions

using NUnit.Framework;
using System;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestBag
    {
        [Test] // LOCATE: The Bag can locate items in its inventory
        public void TestLocateBagItems()
        {
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for Items");
            Item testItem = new Item(new string[] { "item", "A passed item" }, "an item", "This item could be anything");
            testBag.Inventory.Put(testItem);

            // Locate the item and store in GameObject:
            GameObject locatedItem = testBag.Locate("item");

            // Search Inventory for item:
            bool actual = testBag.Inventory.HasItem("item");

            bool expected = true;
            Assert.AreEqual(expected, actual, "Item in Bag's Inventory is not locating correctly.");
        }

        [Test] // LOCATE: The Bag can locate itself
        public void TestLocateBagItself()
        {
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for Items");

            // Locate the BAG and store in GameObject:
            GameObject actual = testBag.Locate("bag");
            GameObject expected = testBag;

            Assert.AreEqual(expected, actual, "The Bag is not locating itself correctly.");

        }

        [Test] // LOCATE: Return null if located item not in Bag
        public void TestLocateBagReturnsNull()
        {
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for Items");
            Item testItem = new Item(new string[] { "item", "A passed item" }, "an item", "This item could be anything");

            // Return NULL if an Item cannot be found:
            GameObject actual = testBag.Locate("different item");
            GameObject expected = null;

            Assert.AreEqual(expected, actual, "The Bag is not locating itself correctly.");
        }

        [Test] // LOCATE: Return null if located item not in Bag:
        public void TestLocateBagFullDescription()
        {
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for Items");
            Item testItem = new Item(new string[] { "item", "A passed item" }, "an item", "This item could be anything");
            testBag.Inventory.Put(testItem);

            string actual = testBag.FullDescription;
            string expected = "In the bag you can see: \tan item (item)\n";

            Assert.AreEqual(expected, actual, "Full Description not returning properly");
        }

        [Test]  // LOCATE: Bag can locate a bag within itself, but can't locate items within that bag:
        public void TestLocateBagWithinABag()
        {
            bool actual = false;
            bool expected = true;
            Bag b1 = new Bag(new string[] { "bag1", "container" }, "a bag", "A Container for Items");
            Bag b2 = new Bag(new string[] { "bag2", "container" }, "a bag", "A Container for Items");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a Shovel", "A Mighty fine Shovel");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "a Sword", "A mighty fine Sword");
            
            b1.Inventory.Put(b2);
            b1.Inventory.Put(shovel);
            b2.Inventory.Put(sword);
            
            // Locate the second bag that has been Put in the first bags inventory:
            GameObject fetchedBag = b1.Inventory.Fetch("bag2");
            
            // Locate the shovel from the fist bags inventory:
            GameObject fetchedItemFromBag1 = b1.Inventory.Fetch("shovel");
            GameObject fetchedItemFromBag2 = b1.Inventory.Fetch("sword");

            // Return null when trying to locate an item in the second bag's inventory:
            if (fetchedBag == b2 && fetchedItemFromBag1 == shovel && fetchedItemFromBag2 == null)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }
            
            Assert.AreEqual(expected, actual, "Bag inside Bag is not locating correctly");
        }
        
    }
}
