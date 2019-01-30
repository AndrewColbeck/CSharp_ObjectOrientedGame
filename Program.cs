// Title:           SwinAdventure_5-1C - Program.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     Swin Adventure Iteration 3 & 4
// Last modified:   6/04/2018
// To Fix:          Complete!

using System;
using System.Collections.Generic;

namespace SwinAdventure 
{
    public class MainClass 
    {
        
        public static void Main(string[] args) 
        {
			// Create List of Locations
            List < Location > _locations = new List<Location>();
			List <Path> _paths = new List<Path>();
			List <Item> _items = new List<Item>();

            //Item _sword = new Item(new string[] { "sword", "bronze sword" }, "a Sword", "A mighty fine Sword");
            //Location _bathroom = new Location("Bathroom", "Room in a house");
            //Location _study = new Location("Study", "Study nook");
            //Path Hallway = new Path(new string[] { "north", "Hallway in house" }, _bathroom);
            //Path Corridor = new Path(new string[] { "south", "Corridor leading south" }, _study);
            //_locations.Add(_bathroom);
            //_locations.Add(_study);

            // Create list of Items

            //Item _shovel = new Item(new string[] { "shovel", "spade" }, "a Shovel", "A Mighty fine Shovel");

            // Place Items in locations
            //_bathroom.Inventory.Put(_sword);
            //_study.Inventory.Put(_shovel);


            // Populate Maze
            PopulateMaze(_locations, _paths, _items);
            
            
            // Print Introduction
            Console.WriteLine("\n\nWelcome to the C# Adventure Game!");
            Console.WriteLine("What is your name?");

            // Save the User's input into the string variable called 'name':
            string _name = Console.ReadLine();

            // Print Dialog
            Console.WriteLine("\nWelcome {0}!", _name);
            Console.WriteLine("How would you describe yourself?");

            // Save the User's input into
            string _description = Console.ReadLine();

            // Create Player
            Player _player = new Player(_name, _description);
            _player.Location = _locations[0];
            

            
            // Create bag and new item, put bag in Player's inventory, put item in bag
            Bag bag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            _player.Inventory.Put(bag);
            Item computer = new Item(new string[] {"computer", "PC" }, "a Computer", "Small PC for Hacking");
            bag.Inventory.Put(computer);
            
            Console.WriteLine("\nThere are doors to your left and right.");
            
            // Set Variables
            string command;
            string[] commandArray = {"Look", "at", "room"};
			//LookCommand look = new LookCommand();
            
			CommandProcessor commandProcessor = new CommandProcessor(_locations);
            
            // Game Loop
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.Write("\nCommand --> ");
                command = Console.ReadLine();
                
                if (command == "quit")
                {
                    break;
                }
                
                //commandArray = command.Split();
                Console.WriteLine("{0}", commandProcessor.Execute(_player, command)); 
                
            } 
        }
        
        public static void PopulateMaze(List<Location> locations, List<Path> paths, List<Item> items)
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = 
                new System.IO.StreamReader(@"/Users/andru/Desktop/dev/GitAdventureGame/AdventureGame/Maze.txt");
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
        
        
        
    }
}