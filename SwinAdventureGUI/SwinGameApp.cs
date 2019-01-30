// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/SwinAdventureGUI - SwinGameApp.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Reads a Maze from a File, and populates the game, Runs as SwinAdventure App 
// Last modified:	25/05/2018
// To Fix:         	Complete
//
//
using System;
using System.Collections.Generic;
using SwinAdventure;
namespace SwinAdventureGUI
{
    public class SwinGameApp
    {
        static List<Location> _locations = new List<Location>();
        CommandProcessor _commandProcessor = new CommandProcessor(_locations);
        Player _player;
        
        // Create List of Locations
        List <Path> _paths = new List<Path>();
        List <Item> _items = new List<Item>();


    
        public SwinGameApp()
        {
            // Populate Maze
            PopulateMaze(_locations, _paths, _items);
        }
        
        public string ExecuteString(string value)
        {
            return _commandProcessor.Execute(_player, value);
        }
        
        public static void PopulateMaze(List<Location> locations, List<Path> paths, List<Item> items)
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = 
                new System.IO.StreamReader(@"/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/Maze.txt");
            while((line = file.ReadLine()) != null)
            {
                int pathNumber = 0;
                string[] words = line.Split(',');
                
                if (words[0] == "Location")
                {
                    locations.Add(new Location(words[1],words[2]));
                }
                
                if (words[0] == "Path")
                { 
                    paths.Add(new Path(new string[] {words[1], words[2]}, locations[Convert.ToInt32(words[4])] ));
                    
                    locations[Convert.ToInt32(words[3])].AddPath(paths[pathNumber]);
                    pathNumber++;
                }
            }
            file.Close();
        }
        
        public void AddPlayer(string name, string desc)
        {
            _player = new Player(name, desc);
            _player.Location = _locations[0];
            
            // Create bag and new item, put bag in Player's inventory, put item in bag
            Bag bag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            _player.Inventory.Put(bag);
            Item computer = new Item(new string[] {"computer", "PC" }, "a Computer", "Small PC for Hacking");
            bag.Inventory.Put(computer);
            Item sword = new Item(new string[] {"sword", "A bronze sword" }, "a large sword", "A mighty fine Sword");
            _locations[0].Inventory.Put(sword);

        }
    }
}
