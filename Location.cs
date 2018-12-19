// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-2C_Swingame_Iteration_5_and_6/Swin-Adventure - Location.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Location Class for Swin Adventure 
// Last modified:	3/05/2018
// To Fix:         	Check Instructions
//
//
using System;
namespace SwinAdventure
{
    public class Location: GameObject, IHaveInventory
    {

        // LOCAL VARIABLES:
        Inventory _inventory = new Inventory();

        // CONSTRUCTORS:
        public Location(string name, string desc) : base(new string[] { "room", "location" }, name, desc)
        {

        }

        // PROPERTIES:
        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        
        
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
                string fullDesc = "You are in the " + Name + ".\n" + "In this room, you can see:\n" + Inventory.ItemList;

                return fullDesc;
            }
        }


	}
}
