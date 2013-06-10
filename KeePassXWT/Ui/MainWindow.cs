using System;
using Xwt;

namespace KeePassXWT
{
	public class MainWindow : Window
	{
		public MainWindow ()
		{
			StartPosition = WindowPosition.CenterScreen;
			Title = "KeePassXWT";

			Size = new Size (600, 400);

			MainMenu = new Menu ();
			var fileMenu = new MenuItem ("_File");

			MainMenu.Items.Add (fileMenu);
			fileMenu.SubMenu = new Menu ();

			var fileNewMenuItem = new MenuItem (StockCommand.New);
			fileNewMenuItem.Clicked += (sender, e) => MessageDialog.Confirm("NEW!", new Command(StockCommand.Ok));
			fileMenu.SubMenu.Items.Add (fileNewMenuItem);

			var fileQuitMenuItem = new MenuItem (StockCommand.Quit);
			fileQuitMenuItem.Clicked += (sender, e) => Application.Exit ();
			fileMenu.SubMenu.Items.Add (fileQuitMenuItem);

			var editMenu = new MenuItem ("_Edit");
			editMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (editMenu);

			var editPreferencesMenuItem = new MenuItem (StockCommand.Preferences);
			editMenu.SubMenu.Items.Add (editPreferencesMenuItem);

			Content = new HBox ();

			CloseRequested += (sender, args) => Application.Exit ();
		}


	}
}

