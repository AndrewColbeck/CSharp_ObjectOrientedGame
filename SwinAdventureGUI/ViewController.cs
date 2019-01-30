// Title:			/OneDrive/_Swinburne/_Degree/OOP/_Tasks/9-2D_Swin-Adventure_Iteration_9/SwinAdventureGUI - ViewController.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		ViewController (created in X-Code controls GUI screen)
// Last modified:	25/05/2018
// To Fix:         	Add More Assets, make pretty!
//
//
using System;

using AppKit;
using Foundation;
using SwinAdventure;

namespace SwinAdventureGUI
{
    public partial class ViewController : NSViewController
    {
        SwinGameApp _swinGameApp = new SwinGameApp();
        string _name = null;
        string _desc = null;
        bool _playerSet;
        bool _descSet;
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
        
        partial void _buttonOnClick (Foundation.NSObject sender)
        {
            if (!_playerSet)
            {
                
                _name = _cLI.StringValue;
                _playerSet = true;
                _cLI.StringValue = "";
                _commandOutput.StringValue = "How would you describe yourself?";
            }
            else
            {
                if (!_descSet)
                {
                    _desc = _cLI.StringValue;
                    _descSet = true;
                    _swinGameApp.AddPlayer(_name, _desc);
                    _cLI.StringValue = "";
                    _commandOutput.StringValue = "What would you like to do?";
                }
                else
                {
                    _commandOutput.StringValue = _swinGameApp.ExecuteString(_cLI.StringValue) + "\nWhat would you like to do?";
                    _cLI.StringValue = "";
                }
            }
            
            
        }
        

        
    }
}
