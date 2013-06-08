using System;
using Xwt;

namespace KeePassXWT
{
	public class Program
	{
		static void Main(string[] args) {
			Application.Initialize (ToolkitType.Gtk);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}

