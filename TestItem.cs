// Title:			4-2P - TestItem.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Unit Tests for Item class in Swinadventure 
// Last modified:	6/04/2018
// To Fix:         	Complete!

using NUnit.Framework;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestItem
    {
        [Test] // AREYOU: The item responds correctly to "Are You"
        public void ItemAreYou()
        {
            Item testItem = new Item(new string[] { "TestFirstId", "TestSecondId" }, "a TestName", "TestDesc");

            bool actual = testItem.AreYou("TestFirstId");
            bool expected = true;
            Assert.AreEqual(expected, actual, "AreYou() Method passed through Item is not identifying matches correctly.");
        }

        [Test] // SHORTDESCRIPTION: The game object's short description returns correctly formatted string
        public void TestShortDesc()
        {
            Item testItem = new Item(new string[] { "TestFirstId", "TestSecondId" }, "a TestName", "TestDesc");

            string actual = testItem.ShortDescription;
            string expected = "a TestName (testfirstid)";
            Assert.AreEqual(expected, actual, "Short Description not retrieved correctly.");
        }

        [Test] // FULLDESCRIPTION: Returns the item's full description
        public void TestFullDesc()
        {
            Item testItem = new Item(new string[] { "a TestFirstId", "TestSecondId" }, "TestName", "TestDesc");
        
            string actual = testItem.FullDescription;
            string expected = "TestDesc";
            Assert.AreEqual(expected, actual, "Full Description not retrieved correctly.");
        }
    }
}
