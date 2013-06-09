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
			string toolkit;

#if FORCE_GTK
			switch (PlatformID.Unix) {
#else
			switch (Environment.OSVersion.Platform) {
#endif
				case PlatformID.Win32NT:
					var wpfAssm = Assembly.LoadFrom("Xwt.WPF.dll");
					toolkit = string.Join(", ", "Xwt.WPFBackend.WPFEngine", wpfAssm.FullName);
					break;
				case PlatformID.Unix:
					var gtkAssm = Assembly.LoadFrom("Xwt.Gtk.dll");
					toolkit = string.Join(", ", "Xwt.GtkBackend.GtkEngine", gtkAssm.FullName);
					break;
				case PlatformID.MacOSX:
					var cocoaAssm = Assembly.LoadFrom("Xwt.Mac.dll");
					toolkit = string.Join(", ", "Xwt.Mac.MacEngine", cocoaAssm.FullName);
					break;
				default:
					Console.WriteLine("Unsupported Platform");
					return;
			}
			Application.Initialize (toolkit);
			using (var mainWindow = new MainWindow ()) {
				mainWindow.Show ();
				Application.Run ();
			}
		}
	}
}

