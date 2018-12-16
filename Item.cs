// Title:			SwinAdventure_4-2P - Item.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Sub-Class of GameObject, used to represent any Item
//                  which is locatable in the game (disregarding player and
//                  player's inventory). 
// Last modified:	3/04/2018
// To Fix:         	Complete!

namespace SwinAdventure
{
    public class Item : GameObject
    {
        // CONSTRUCTOR:
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            
        }
    }
}
