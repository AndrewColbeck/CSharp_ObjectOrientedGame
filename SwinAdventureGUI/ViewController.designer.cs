// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SwinAdventureGUI
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton _button { get; set; }

		[Outlet]
		AppKit.NSTextField _cLI { get; set; }

		[Outlet]
		AppKit.NSTextField _commandOutput { get; set; }

		[Action ("_buttonOnClick:")]
		partial void _buttonOnClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_button != null) {
				_button.Dispose ();
				_button = null;
			}

			if (_cLI != null) {
				_cLI.Dispose ();
				_cLI = null;
			}

			if (_commandOutput != null) {
				_commandOutput.Dispose ();
				_commandOutput = null;
			}
		}
	}
}
