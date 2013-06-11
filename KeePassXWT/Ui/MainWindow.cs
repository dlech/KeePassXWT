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

			var newCommand = new Command (StockCommand.New);
			Commands.Add (newCommand);
			var fileNewMenuItem = newCommand.CreateMenuItem ();
			newCommand.Activated += (sender, e) =>
			{
				MessageDialog.RootWindow = this;
				MessageDialog.Confirm ("NEW!", new Command (StockCommand.Ok));
			};
			fileMenu.SubMenu.Items.Add (fileNewMenuItem);

			var openCommand = new Command (StockCommand.Open);
			var fileOpenMenuItem = openCommand.CreateMenuItem ();
			fileOpenMenuItem.SubMenu = openCommand.CreateMenu ();
			fileMenu.SubMenu.Items.Add (fileOpenMenuItem);

			var openCommandAccelerator = new Accelerator (Key.O, ModifierKeys.Control);
			var openFileCommand = new Command ("OpenFile", "Open _File\u2026", openCommandAccelerator);
			Commands.Add (openFileCommand);
			var fileOpenOpenFileMenuItem = openFileCommand.CreateMenuItem ();
			fileOpenMenuItem.SubMenu.Items.Add (fileOpenOpenFileMenuItem);

			var quitCommand = new Command (StockCommand.Quit);
			Commands.Add (quitCommand);
			var fileQuitMenuItem = quitCommand.CreateMenuItem ();
			quitCommand.Activated += (sender, e) => Application.Exit ();
			fileMenu.SubMenu.Items.Add (fileQuitMenuItem);

			var editMenu = new MenuItem ("_Edit");
			editMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (editMenu);

			var openPreferencesCommand = new Command (StockCommand.Preferences);
			var editPreferencesMenuItem = openPreferencesCommand.CreateMenuItem ();
			editMenu.SubMenu.Items.Add (editPreferencesMenuItem);

			Content = new HBox ();

			CloseRequested += (sender, args) => Application.Exit ();
		}


	}
}

