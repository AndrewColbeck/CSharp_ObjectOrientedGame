// Title:			SwinAdventure_5-1C - Bag.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	12/04/2018
// To Fix:         	Complete!


using System;
namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        // LOCAL VARIABLES:
        private Inventory _inventory = new Inventory();
        
        // CONSTRUCTOR:
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            
        }
        
        // PROPERTIES:
        public Inventory Inventory { get => _inventory; }
        
        // METHODS:
        // RETURN GameObject if name matches passed string:
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return Inventory.Fetch(id);
        }

		public override string FullDescription
        {
            get 
            { 
                return "In the " + this.Firstid + " you can see: " + Inventory.ItemList; 
            }
        }
	}
}
