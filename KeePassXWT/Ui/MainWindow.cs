using System;
using Xwt;

namespace KeePassXWT
{
	public class MainWindow : Window
	{
		public MainWindow ()
		{
			Title = "KeePassXWT";

			var screenCenter = ScreenBounds.Center;
			Location = new Point (screenCenter.X - Width / 2,
			                      screenCenter.Y - Height / 2);
			Size = new Size (400, 200);

			MainMenu = new Menu ();
			var fileMenu = new MenuItem ("_File");

			MainMenu.Items.Add (fileMenu);
			fileMenu.SubMenu = new Menu ();

			var fileExitMenuItem = new MenuItem (Command.Close);
			fileExitMenuItem.Clicked += (sender, e) => Application.Exit ();
			fileMenu.SubMenu.Items.Add (fileExitMenuItem);

			var editMenu = new MenuItem ("_Edit");
			editMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (editMenu);

			var editPreferencesMenuItem = new MenuItem ("_Preferences...");
			editMenu.SubMenu.Items.Add (editPreferencesMenuItem);

			Content = new HBox ();

			CloseRequested += (sender, args) => Application.Exit ();
		}


	}
}

