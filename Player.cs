// Title:			SwinAdventure_4-2P - Player.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Player is a Sub-Class of GameObject, and holds an inventory 
// Last modified:	3/04/2018
// To Fix:         	Complete!

namespace SwinAdventure
{
    public class Player : GameObject
    {
        // LOCAL VARIABLES:
        Inventory _inventory = new Inventory();

        // CONSTRUCTORS:
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
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
        
        // OVERRIDE METHOD adds "You are carrying" to FullDescription method
        // located in GameObject Class:
        public override string FullDescription
        {
            get
            {    
                return "You are carrying: " + Inventory.ItemList;
            }
        }    
	}
}
