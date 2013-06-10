using System;
using Xwt;
using System.Reflection;

namespace KeePassXWT
{
	public class Program
	{
		// single apartment thread needed for windows backend
		[STAThreadAttribute()]
		static void Main(string[] args) {
			ToolkitType toolkitType;

#if FORCE_GTK
			switch (PlatformID.Unix) {
#else
			switch (Environment.OSVersion.Platform) {
#endif
				case PlatformID.Win32NT:
					toolkitType = ToolkitType.Wpf;
					break;
				case PlatformID.Unix:
					toolkitType = ToolkitType.Gtk;
					break;
				case PlatformID.MacOSX:
					toolkitType = ToolkitType.Cocoa;
					break;
				default:
					Console.WriteLine("Unsupported Platform");
					return;
			}
			Application.Initialize (toolkitType);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}

