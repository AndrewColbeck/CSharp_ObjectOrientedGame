// Title:			5-1C - TestInventory.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Unit Tests for Inventory Class in Swinadventure
// Last modified:	6/04/2018
// To Fix:         	Complete!

using NUnit.Framework;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestInventory
    {
        [Test] // PUT: The inventory has items that are put in it
        public void TestFindItem()
        {
            Inventory testInventoryObject = new Inventory();
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
            testInventoryObject.Put(testItem);

            bool actual = testInventoryObject.HasItem("a testfirstid");
            bool expected = true;
            Assert.AreEqual(expected, actual, "Item not retrieved from Inventory correctly.");
        }
        
        [Test] // HASITEM: does not have items it does not contain
        public void TestDontFindNonexistingItem()
        {
            Inventory testInventoryObject = new Inventory();
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
            testInventoryObject.Put(testItem);

            bool actual = testInventoryObject.HasItem("Non-existent Item");
            bool expected = false;
            Assert.AreEqual(expected, actual, "Item retrieved from Inventory incorrectly.");
        }
        
        [Test] // FETCH: Returns items it has, and the item remains in the inventory
        public void TestFetchItem()
        {
            Inventory testInventoryObject = new Inventory();
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
            testInventoryObject.Put(testItem);

            Item fetchedItem = testInventoryObject.Fetch("a testfirstid");
            bool actual = testInventoryObject.HasItem("a testfirstid");
            bool expected = true;
            Assert.AreEqual(expected, actual, "Item has been fetched and no longer exists in inventory.");
        }

        [Test] // TAKE: Returns items it has, and the item remains in the inventory
        public void TestTakeItem()
        {
            Inventory testInventoryObject = new Inventory();
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
            testInventoryObject.Put(testItem);
            testInventoryObject.Take("a testfirstid");

            Item actual = testInventoryObject.Take("a testfirstid");
            Item expected = null;
            Assert.AreEqual(expected, actual, "Item has been taken but still remains in the inventory.");
        }
        
        [Test] // ITEMLIST: returnsstring with one row per item and indented short descriptions
        public void TestItemList()
        {
            Inventory testInventoryObject = new Inventory();
            Item testItem1 = new Item(new string[] { "shovel", "spade" }, "a shovel", "a mighty fine shovel");
            Item testItem2 = new Item(new string[] { "sword", "medieval battle sword" }, "a bronze sword", "a mighty sharp sword");
            Item testItem3 = new Item(new string[] { "pc", "a small terminal" }, "a small computer", "a small but fast computer");
            testInventoryObject.Put(testItem1);
            testInventoryObject.Put(testItem2);
            testInventoryObject.Put(testItem3);

            string actual = testInventoryObject.ItemList;
            string expected = "\ta shovel (shovel)\n\ta bronze sword (sword)\n\ta small computer (pc)\n";
            Assert.AreEqual(expected, actual, "Item List not returning short descriptions correctly");
        }
    }
}
