using System;
using Xwt;

namespace KeePassXWT
{
	public class Program
	{
		// single apartment thread needed for windows backend
		[STAThreadAttribute ()]
		static void Main (string[] args)
		{
			Application.Initialize (ToolkitType.Wpf);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}

