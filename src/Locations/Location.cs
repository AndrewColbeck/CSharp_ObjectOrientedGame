// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-2C_Swingame_Iteration_5_and_6/Swin-Adventure - Location.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Location Class for Swin Adventure 
// Last modified:	3/05/2018
// To Fix:         	Check Instructions
//
//
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location: GameObject, IHaveInventory
    {

        // LOCAL VARIABLES:
        Inventory _inventory = new Inventory();
		List<Path> _paths = new List<Path>();
        // CONSTRUCTORS:
        public Location(string name, string desc) : base(new string[] { "room", "location" }, name, desc)
        {

        }

        // PROPERTIES:
        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        public List<Path> Paths { get => _paths; set => _paths = value; }      
        
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

        public GameObject Take(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return Inventory.Take(id);
            
        }

		public override string FullDescription
        {
            get
            {
                string fullDesc = "You are in the " + Name + ".\n" + "In this room, you can see:\n" + Inventory.ItemList;

                return fullDesc;
            }
        }

	
		public void AddPath(Path p)
        {
			_paths.Add(p);
        }

        public void MovePlayer(Player player, string command)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(command))
                {
					p.MovePlayer(player);
                }
            }
        }
        
        public bool LocatePath (string command)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(command))
                {
					return true;
                }
            }
            return false;
        }
	}
}
