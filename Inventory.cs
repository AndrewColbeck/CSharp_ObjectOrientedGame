// Title:			SwinAdventure_5-1C - Inventory.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Inventory is a sub-class of GameObject, used to store items 
// Last modified:	3/04/2018
// To Fix:         	Complete!

using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        // LOCAL VARIABLES:
        List<Item> _items = new List<Item>();
        
        // PROPERTIES:
        // ItemList returns a string of indented names and descriptions of items
        // within the Inventory:
        public string ItemList
        { 
            get
            {
                string shortDescriptions = null;
                foreach(Item itm in _items)
                {
                    shortDescriptions += "\t" + itm.ShortDescription + "\n";
                }

                return shortDescriptions;
            }
        }
        
        // METHODS:
        
        // Check if item exists in Inventory:
        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                    return true;
            }
            
            return false;
        }
        
        // Add an item to the Inventory:
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        
        // Take an item from the Inventory:
        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.Name == id)
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            
            return null;
        }
    
        // RETURN an Item with matching name:
        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.Firstid == id)
                {
                    return itm;
                }
            }
            
            return null;
        }
    }
}
