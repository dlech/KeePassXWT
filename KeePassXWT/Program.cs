using System;
using Xwt;
using System.Reflection;
using System.IO;

namespace KeePassXWT
{
	public class Program
	{
		// single apartment thread needed for windows backend
		[STAThreadAttribute()]
		static void Main(string[] args) {
			ToolkitType toolkitType;
			var engine = new Xwt.Mac.MacEngine();

#if FORCE_GTK
			switch (PlatformID.Unix) {
#else
			switch (Environment.OSVersion.Platform) {
#endif
				case PlatformID.Win32NT:
					toolkitType = ToolkitType.Wpf;
					break;
				case PlatformID.Unix:
					// workaround for returning Unix even though we are on OSX
					if (Directory.Exists("/Applications") & Directory.Exists("/System") &
					    Directory.Exists("/Users") & Directory.Exists("/Volumes"))

						goto case PlatformID.MacOSX;

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

