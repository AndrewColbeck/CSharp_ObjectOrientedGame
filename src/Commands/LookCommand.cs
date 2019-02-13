// Title:			SwinAdventure_5-1C - LookCommand.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	18/04/2018
// To Fix:         	Complete!

using System;
namespace SwinAdventure
{
    public class LookCommand : Command
    {
        // CONSTRUCTOR:
        public LookCommand() : base (new string[] { "look", "look at", "look at in" })
        {
            
        }

        // METHODS:
        public override string Execute(Player p, string[] commandsArray)
        {
            string result;

            // HANDLE LOOK INPUT:

            // Must be either "Look at <item>" OR "Look at <item> in <container>"
            if (commandsArray.Length == 3 || commandsArray.Length == 5)
            {
                // Must begin with LOWERCASE look or UPPERCASE Look
                if (commandsArray[0] == "look" || commandsArray[0] == "Look")
                {
                    // Second word must be "at"
                    if (commandsArray[1] == "at")
                    {
                        // If "Look at <item>"
                        if (commandsArray.Length == 3)
                        {
                            // Player is container
                            result = LookAtIn(commandsArray[2], p);
                            
                            // If Item is not in Player, look in Player location:
                            if (result == null)
                            {
                                result = LookAtIn(commandsArray[2], p.Location);
                            }
                        }
                        
                        // Else command must be "look at item in container"
                        else
                        {
                            // Check if input includes keyword "in":
                            if (commandsArray[3] == "in")
                            {
                                
                                // If Command does include "in" keyword, fetch Container & LookAt<item>In:
                                result = LookAtIn(commandsArray[2], FetchContainer(p, commandsArray[4]));
                                
                                // If Container returns null, inform player:
                                if (result == "Container is null")
                                {
                                    result = "I can't find the " + commandsArray[4];
                                }
                                
                            }else result = "What do you want to look in?";
                        }
                    }else result = "What do you want to look at?";
                    
                }else result = "Error in look input";
                
            }else result = "I don't know how to look like that";                        

            return result;
        }
        
        // Return a Container (as an Inventory):
        public IHaveInventory FetchContainer (Player p, string containerId)
        {
            return (p.Locate(containerId) as IHaveInventory);
        }
        
        // Look inside a Container (as an Inventory) for an Item:
        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container != null)
            {
                GameObject result = container.Locate(thingId);
                if (result != null)
                {
                    return result.ShortDescription;
                }
                else
                {
                    return "I can't find the " + thingId;                
                }
            }
            else
            {
                return "Container is null";
            }
        }
    }
}
