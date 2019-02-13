// Title:			SwinAdventure_5-1C - testLook.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:     Unit Tests for Look Class in Swinadventure
// Last modified:	18/04/2018
// To Fix:         	Complete!
//
//
using NUnit.Framework;
using System;
namespace SwinAdventure
{
    [TestFixture()]
    public class TestLook
    {
        [Test] // LOOK AT ME: Look returns player's description when looking at "inventory"
        public void LookAtMe()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "inventory" });
            string expected = testPlayer.ShortDescription;
            Assert.AreEqual(expected, actual, "Look At Me command not returning correct string");
        }

        [Test] // LOOK AT GEM: Returns the gems description when looking at a gem in the player's inventory.
        public void LookAtGem()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "Gem", "Shiny Gem" }, "Gem", "A very shiny Gem");
            testPlayer.Inventory.Put(gem);

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem" });
            string expected = gem.ShortDescription;
            Assert.AreEqual(expected, actual, "Look At Gem command not returning correct string");
        }

        [Test] // LOOK AT UNK: Returns "I can't find the gem" when the the player does not have a gem in their inventory.
        public void LookAtUnk()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "Gem", "Shiny Gem" }, "a Gem", "A very shiny Gem");

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem" });
            string expected = "I can't find the gem";
            Assert.AreEqual(expected, actual, "Look At Gem command not returning correct string");
        }

        [Test] // LOOK AT GEM IN ME: Returns the gem's description when looking at a gem in the player's inventory. "look at gem in inventory"
        public void LookAtGemInMe()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "Gem", "Shiny Gem" }, "a Gem", "A very shiny Gem");
            testPlayer.Inventory.Put(gem);


            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem", "in", "inventory" });
            string expected = gem.ShortDescription;

        }

        [Test] // LOOK AT GEM IN BAG: Returns the gems description when looking at a gem in a bag that is in the player's inventory.
        public void LookAtGemInBag()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "gem", "Shiny Gem" }, "a Gem", "A very shiny Gem");
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            testBag.Inventory.Put(gem);
            testPlayer.Inventory.Put(testBag);

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem", "in", "bag" });
            string expected = gem.ShortDescription;
            Assert.AreEqual(expected, actual, "Look At Gem in Bag command not returning correct string");

        }

        [Test] // LOOK AT GEM IN NO BAG: Returns "I can't find the bag" when the player does not have a bag in their inventory.
        public void LookAtGemInNoBag()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "gem", "Shiny Gem" }, "a Gem", "A very shiny Gem");
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            testBag.Inventory.Put(gem);
            //testPlayer.Inventory.Put(testBag);

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem", "in", "bag" });
            string expected = "I can't find the bag";
            Assert.AreEqual(expected, actual, "Look At Gem when Player doesn't have bag, command not returning correct string");

        }

        [Test] // LOOK AT NO GEM IN BAG: Returns "I can't find the gem" when the the bag does not have a gem in its inventory.
        public void LookAtNoGemInBag()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");
            Item gem = new Item(new string[] { "gem", "Shiny Gem" }, "a Gem", "A very shiny Gem");
            Bag testBag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            //testBag.Inventory.Put(gem);
            testPlayer.Inventory.Put(testBag);

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "gem", "in", "bag" });
            string expected = "I can't find the gem";
            Assert.AreEqual(expected, actual, "Look At Gem when Player doesn't have bag, command not returning correct string");
        }

        [Test] // LOOK INVALID LOOK: Test look options to check all error conditions. For example: “look around”, or “hello”, “look at a at b”, etc.
        public void TestInvalidLookAround()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "around" });
            string expected = "I don't know how to look like that";
            Assert.AreEqual(expected, actual, "Invalid Look command not returning expected result");
        }

        [Test] // LOOK INVALID LOOK: Test look options to check all error conditions. For example: “look around”, or “hello”, “look at a at b”, etc.
        public void TestInvalidLookWassup()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            string actual = testLook.Execute(testPlayer, new string[] { "Wassssuuuuup" });
            string expected = "I don't know how to look like that";
            Assert.AreEqual(expected, actual, "Invalid Look command not returning expected result");
        }

        [Test] // LOOK INVALID LOOK: Test look options to check all error conditions. For example: “look around”, or “hello”, “look at a at b”, etc.
        public void TestInvalidLookForAThing()
        {
            LookCommand testLook = new LookCommand();
            Player testPlayer = new Player("Fred", "The Mighty Programmer");

            string actual = testLook.Execute(testPlayer, new string[] { "Look", "at", "a thing", "in ", "rubbish bin" });
            string expected = "What do you want to look in?";
            Assert.AreEqual(expected, actual, "Invalid Look command not returning expected result");
        }
    }
}
