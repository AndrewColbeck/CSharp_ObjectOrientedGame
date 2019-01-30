// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/Swin-Adventure - PutCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Put Command returns a string and Puts an Object in an inv
// Last modified:	24/05/2018
// To Fix:         	Complete!
//
//
using System;
namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] {"put", "drop"})
        {
        }

		public override string Execute(Player p, string[] commandsArray)
		{

			if (commandsArray.Length == 2 || commandsArray.Length == 4)
			{
                if (commandsArray.Length == 2)
                {
                    Item obj = p.Take(commandsArray[1]) as Item;
                    if (obj != null)
                    {
                        p.Location.Inventory.Put(obj);
                        return "Dropped " + commandsArray[1] + " in " + p.Location.Name;
    
                    }
                    return "Couldn't find the " + commandsArray[1];
                }
                
                if (commandsArray.Length == 4)
                {
                    if (commandsArray[2].ToLower().Equals("in"))
                    {
                        IHaveInventory container = FetchContainer(p, commandsArray[3].ToLower());
                        if (container != null)
                        {
                            Item obj = p.Take(commandsArray[1]) as Item;
                            if (obj != null)
                            {
                                p.Inventory.Put(obj);
                                return "Dropped " + commandsArray[1] + " into " + commandsArray[3];
                            }
                        }
                    }
					else
                    {
						return "I don't know how to drop like that";
                    }
                }   
			}
			return null;    
		}
        
        GameObject Pickup(string id, IHaveInventory container)
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
