// Title:			SwinAdventure_5-1C - Player.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Player is a Sub-Class of GameObject, and holds an inventory 
// Last modified:	3/04/2018
// To Fix:         	Complete!

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        // LOCAL VARIABLES:
        private Inventory _inventory = new Inventory();
        private Location _location = new Location("room", "Building");

        
        // CONSTRUCTORS:
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {

        }

        // PROPERTIES:
        public Inventory Inventory { get => _inventory; }
        public Location Location { get => _location; set => _location = value; }
        
        // METHODS:
        // RETURN GameObject if name matches passed string:
        public GameObject Locate(string id)
        {
            // If Player is the item, return player
            if (AreYou(id))
            {
                return this;
            }
            else
            {   // If item is in inventory, return item
                if (Inventory.Fetch(id) != null)
                {
                    return Inventory.Fetch(id);
                }
                else
                {
                    // Else check Player's location, return item or null
                    return Location.Locate(id);
                }
            }
            
            
        }
        
        // OVERRIDE METHOD adds "You are carrying" to FullDescription method
        // located in GameObject Class:
        public override string FullDescription
        {
            get
            {    
                return "You are carrying\n" + Inventory.ItemList;
            }
        }
        
        
	}
}
