// Title:			SwinAdventure_5-1C - GameObject.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Abstract Sub-Class inheriting from IdentifiableObject 
// Last modified:	3/04/2018
// To Fix:         	Complete!

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        // LOCAL VARIABLES:
        string _description;
        string _name;
        
        // CONSTRUCTOR:
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
        
        // PROPERTIES:
        public string Name { get => _name; }    
        public string ShortDescription { get => _name + " (" + base.Firstid + ")"; }
        public virtual string FullDescription { get => _description; }
    }
}
