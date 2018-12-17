// Task 5-1C - TestIdentifiableObject class by Andrew Colbeck © 2018, all rights reserved.
// This Class will use NUnit testing on the IdentifiableObject class to
// assist in the locating of potential bugs and anomalies

using NUnit.Framework;

namespace SwinAdventure 
{
    // UNIT TESTS:
    [TestFixture]
    public class TestIdentifiableObject 
    {
        [Test] // Whether AreYou Method is returning TRUE for positive match
        public void TestAreYou() 
        {
            IdentifiableObject testIdentifiableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            bool actual = testIdentifiableObject.AreYou("fred");
            bool expected = true;
            Assert.AreEqual(expected, actual, "AreYou() is not identifying matches correctly.");
        }

        [Test] // Whether AreYou Method is returning FALSE for negative match
        public void TestAreYouNot() 
        {
            IdentifiableObject testIdentifiableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            bool actual = testIdentifiableObject.AreYou("andrew");
            bool expected = false;
            Assert.AreEqual(expected, actual, "AreYou() has returned a false positive");
        }
    
        [Test] // Whether AreYou Method is ignoring casing when comparing identifiers 
        public void TestAreYouCaseSensitive() 
        {
            IdentifiableObject testIdentifiableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            bool actual = testIdentifiableObject.AreYou("fReD");
            bool expected = true;
            Assert.AreEqual(expected, actual, "AreYou() is exhibiting Case Sensitivity when casing should be ignored.");
        }
    
        [Test] // Whether FirstId method is returning first identifier in list
        public void FirstIdGetTest() 
        {
            IdentifiableObject testIdentifiableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            string actual = testIdentifiableObject.Firstid;
            string expected = "fred";
            Assert.AreEqual(expected, actual, "FirstId is not returning the correct value.");
        }

        [Test] // Whether AddId will add passed identifier to the list
        public void AddIdentifierTest() 
        {
            IdentifiableObject testIdentifiableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            testIdentifiableObject.AddIdentifier("james");
            bool actual = testIdentifiableObject.AreYou("james");
            bool expected = true;
            Assert.AreEqual(expected, actual, "AddIdentifier() has not added an Identifier to the list.");
        }
    }
}