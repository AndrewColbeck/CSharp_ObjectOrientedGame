// Title:           SwinAdventure_5-1C - Program.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     Swin Adventure Iteration 3 & 4
// Last modified:   6/04/2018
// To Fix:          Complete!

using System;

namespace SwinAdventure 
{
    public class MainClass 
    {
        public static void Main(string[] args) 
        {

            
            Console.WriteLine("Welcome to Swin-Adventure!");
            Console.WriteLine("What is your name?");

            // Save the User's input into the string variable called 'name':
            string _name = Console.ReadLine();

            Console.WriteLine("Welcome {0}!\n", _name);
            Console.WriteLine("How would you describe yourself, {0}?\n", _name);

            // Save the User's input into
            string _description = Console.ReadLine();

            // Create Player and Items
            Player player = new Player(_name, _description);
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a Shovel", "A Mighty fine Shovel");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "a Sword", "A mighty fine Sword");

            // Put Items in Player's inventory
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            
            // Create bag and new item, put bag in Player's inventory, put item in bag
            Bag bag = new Bag(new string[] { "bag", "container" }, "a Bag", "A Container for items");
            player.Inventory.Put(bag);
            Item computer = new Item(new string[] {"computer", "PC" }, "a Computer", "Small PC for Hacking");
            bag.Inventory.Put(computer);
            
            Console.WriteLine("Welcome to Swin Adventure, {0}! ", _name);
            
            // Game Loop
            string command;
            string[] commandArray = {"Look", "at", "me"};
            LookCommand look = new LookCommand();
            
            do
            {
                Console.WriteLine("What would you like to look at?");
                Console.Write("\nCommand --> ");
                command = Console.ReadLine();

                commandArray = command.Split();
                Console.WriteLine("{0}", look.Execute(player, commandArray)); 
                
            } while (command != "exit");
        }
    }
}