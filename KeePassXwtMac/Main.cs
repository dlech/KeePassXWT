using System;
using Xwt;
using KeePassXWT;

namespace KeePassXwtMac
{
	class MainClass
	{
		static void Main (string [] args)
		{
			Application.Initialize (ToolkitType.Cocoa);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}	

