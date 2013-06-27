using System;
using Xwt;
using System.Reflection;
using System.IO;

namespace KeePassXWT
{
	public class Program
	{
		// single apartment thread needed for windows backend
		[STAThreadAttribute ()]
		static void Main (string[] args)
		{
			Application.Initialize (ToolkitType.Gtk);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}

