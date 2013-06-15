using System;
using Xwt;
using System.Reflection;
using System.IO;

namespace KeePassXWT
{
	public class Program
	{
		// single apartment thread needed for windows backend
		//[STAThreadAttribute()]
		static void Main(string[] args) {
			ToolkitType toolkitType;
#if FORCE_GTK
			var platform = PlatformID.Unix;
#else
			var platform = Environment.OSVersion.Platform;

			// workaround for returning Unix even though we are on OSX
			if (platform == PlatformID.Unix && Directory.Exists("/Applications") & Directory.Exists("/System") &
			    Directory.Exists("/Users") & Directory.Exists("/Volumes"))

				platform = PlatformID.MacOSX;
#endif
			switch (platform) {
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

