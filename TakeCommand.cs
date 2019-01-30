// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/Swin-Adventure - TakeCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Take Command returns a string and moves an Object 
// Last modified:	24/05/2018
// To Fix:         	Complete!
//
//
using System;
namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base (new string [] {"take", "pickup"})
        {
        }
        
        public override string Execute(Player player, string[] command)
        {
			string item = null;
            
            if(command.Length == 2 || command.Length == 4)
            {
                if (command.Length == 4)
                {
                    if (command[2].ToLower().Equals("from"))
                    {
						IHaveInventory container = FetchContainer(player, command[3].ToLower());
                        
                        if (container != null)
                        {
							Item obj = PickUp(container, command[1].ToLower()) as Item;
							
                            if (obj != null)
                            {
								player.Inventory.Put(obj);
								return "Picked up " + command[1] + " from " + command[3];
                            }
							else
                            {
                                item = "I cannot find the " + command[1];
                            }
                        }
						else
                        {
                            item = "I cannot find the " + command[3];
                        }
					}
					else
                    {
						item = "Where do you want to take from?";
                    }
                }
                
                if (command.Length == 2)
                {
					IHaveInventory location = player.Location as IHaveInventory;
					Item obj = PickUp(location, command[1].ToLower()) as Item;
					Console.WriteLine(player.Location.Name + " " + command[1].ToLower());
                    if (obj != null)
                        {
                            player.Inventory.Put(obj);
                            return "Picked up " + command[1];
                        }
					return "Couldn't find " + command[1];
                }
            }
            else
            {
				item = "I don't know how to take like that";
            }
			return item;       
        }
        
        private GameObject PickUp (IHaveInventory container, string id)
        {
			return container.Take(id);
        }
        
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            if (obj == null && p.Location.AreYou(containerId))
            {
                obj = p.Location;
            }
            IHaveInventory container = obj as IHaveInventory;
            return container;
        }
    }
}
