using System;
using System.Collections.Generic;
using Xwt;

namespace KeePassXWT
{
	public class MainWindow : Window
	{
		List<Command> openRecentCommandList;
		List<Command> synchronizeRecentCommandList;

		public MainWindow ()
		{
			StartPosition = WindowPosition.CenterScreen;
			Size = new Size (600, 400);
			Title = "KeePassXWT";

			/* Commands */

			/* New */
			var newCommand = GlobalCommand.New.Get ();
			newCommand.Activated += (sender, e) =>
			{
				MessageDialog.RootWindow = this;
				var result = MessageDialog.Confirm ("NEW!", "Secondary");
				result = result;
			};

			/* Open File */
			var openFileCommandAccelerator = new Accelerator (Key.O, ModifierKeys.Control);
			var openFileCommand = new Command ("OpenFile", "Open _File\u2026", openFileCommandAccelerator);
			openFileCommand.Activated += (sender, e) =>
			{
				var openFileDialog = new OpenFileDialog ();
				openFileDialog.Filters.Add (new FileDialogFilter ("KeePass KDBX Files", "*.kdbx"));
				openFileDialog.Filters.Add (new FileDialogFilter ("All Files", "*.*"));
				openFileDialog.CurrentFolder = Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
				openFileDialog.Run ();
				// TODO: Handle actual file opening
			};

			/* Open Url */
			var openUrlCommandAccelerator = new Accelerator (Key.O, ModifierKeys.Shift | ModifierKeys.Control);
			var openUrlCommand = new Command ("OpenUrl", "Open _URL\u2026", openUrlCommandAccelerator);
			openUrlCommand.Activated += (sender, e) =>
			{
				// TODO: add OpenUrlDialog
			};

			/* Clear Recent List */
			var clearOpenRecentListCommand = new Command ("OpenRecentClearList", "_Clear List");
			clearOpenRecentListCommand.Activated += (sender, e) =>
			{
				if (openRecentCommandList != null)
					openRecentCommandList.Clear ();
			};

			/* Close */
			var closeCommand = GlobalCommand.Close.Get ();
			closeCommand.Activated += (sender, e) =>
			{
				// TODO: handle closing
			};

			/* Save */
			var saveCommand = GlobalCommand.Save.Get ();
			saveCommand.Activated += (sender, e) =>
			{
				// TOOD: handle saving
			};

			/* Save To File */
			var saveFileCommand = new Command ("SaveToFile", "Save to _File\u2026");
			saveFileCommand.Activated += (sender, e) =>
			{
				// TOOD: handle saving
			};

			/* Save To URL */
			var saveUrlCommand = new Command ("SaveToURL", "Save to _URL\u2026");
			saveUrlCommand.Activated += (sender, e) =>
			{
				// TOOD: handle saving
			};

			/* Save Copy To File */
			var saveCopyFileCommand = new Command ("SaveCopyToFile", "Save _Copy to File\u2026");
			saveCopyFileCommand.Activated += (sender, e) =>
			{
				// TOOD: handle saving
			};

			/* Database Settings */
			var showDatabaseSettingsCommand = new Command ("DatabaseSettings", "_Database Settings\u2026");
			showDatabaseSettingsCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Change Master Key */
			var changeMasterKeyCommand = new Command ("ChangeMasterKey", "Change _Master Key\u2026");
			changeMasterKeyCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Print */
			var printCommand = GlobalCommand.Print.Get ();
			printCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Import */
			var importcommand = GlobalCommand.Import.Get ();
			importcommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Export */
			var exportcommand = GlobalCommand.Export.Get();
			exportcommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Synchronize File */
			var synchronizeFileCommand = new Command ("SynchronizeFile", "Synchronize with _File\u2026");
			synchronizeFileCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Synchronize URL */
			var synchronizeUrlCommand = new Command ("SynchronizeURL", "Synchronize with _URL\u2026");
			synchronizeUrlCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Clear Synchronize Recent List */
			var clearSynchronizeRecentListCommand = new Command ("SynchronizeRecentClearList", "_Clear List");
			clearSynchronizeRecentListCommand.Activated += (sender, e) =>
			{
				if (synchronizeRecentCommandList != null)
					synchronizeRecentCommandList.Clear ();
			};

			/* Lock Workspace */
			var lockWorkspaceAccelerator = new Accelerator (Key.L, ModifierKeys.Control);
			var lockWorkspaceCommand = new Command ("LockWorkspace", "_Lock Workspace", lockWorkspaceAccelerator);
			lockWorkspaceCommand.Activated += (sender, e) =>
			{
				// TOOD: handle
			};

			/* Preferences/Options */
			var showPreferencesCommand = GlobalCommand.Preferences.Get ();

			/* Quit */
			var quitCommand = GlobalCommand.Quit.Get ();
			quitCommand.Activated += (sender, e) => Application.Exit ();


			/* About */
			var aboutCommand = new Command ("About", "_About");


			/* Main Menu */

			MainMenu = new Menu ();

			// TODO: check for platform
			var isOSX = true;

			if (isOSX)
			{
				/* Application */
				var appMenu = new MenuItem (); // title is automatic
				MainMenu.Items.Add (appMenu);
				appMenu.SubMenu = new Menu ();

				/* Application > About */
				appMenu.SubMenu.Items.Add (aboutCommand.CreateMenuItem());

				/* Application > Preferences */
				var appPreferencesMenuItem = showPreferencesCommand.CreateMenuItem ();
				appMenu.SubMenu.Items.Add (appPreferencesMenuItem);

				appMenu.SubMenu.Items.Add (new SeparatorMenuItem());

				/* Application > Quit */
				appMenu.SubMenu.Items.Add (quitCommand.CreateMenuItem());
			}

			/* File */
			var fileMenu = new MenuItem ("_File");
			fileMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (fileMenu);
			var fileNewMenuItem = newCommand.CreateMenuItem ();

			/* File > New... */
			fileMenu.SubMenu.Items.Add (fileNewMenuItem);

			/* File > Open */
			var fileOpenMenuItem = new MenuItem ("_Open");
			fileOpenMenuItem.SubMenu = new Menu ();
			fileMenu.SubMenu.Items.Add (fileOpenMenuItem);

			/* File > Open > Open File... */
			fileOpenMenuItem.SubMenu.Items.Add (openFileCommand.CreateMenuItem ());

			/* File > Open > Open URL... */
			fileOpenMenuItem.SubMenu.Items.Add (openUrlCommand.CreateMenuItem ());

			/* File > Open Recent */
			var fileOpenRecentMenuItem = new MenuItem("Open _Recent");
			fileOpenRecentMenuItem.SubMenu = new Menu ();
			// SubMenu is dynamically generated
			fileOpenRecentMenuItem.Clicked += (sender, e) =>
			{
				fileOpenRecentMenuItem.SubMenu.Items.Clear ();
				if (openRecentCommandList == null) {
					openRecentCommandList = new List<Command> ();
					// TODO: Populate from user settings
				}
				var hasItems = openRecentCommandList.Count > 0;
				if (hasItems) {
					foreach (var command in openRecentCommandList)
						fileOpenRecentMenuItem.SubMenu.Items.Add (command.CreateMenuItem ());
				} else {
					fileOpenRecentMenuItem.SubMenu.Items.Add
						(new MenuItem ("(No Recent Items)") { Sensitive = false });
				}
				fileOpenRecentMenuItem.SubMenu.Items.Add (new SeparatorMenuItem ());
				var fileOpenRecentClearListMenuItem = clearOpenRecentListCommand.CreateMenuItem ();
				fileOpenRecentClearListMenuItem.Sensitive = hasItems;
				fileOpenRecentMenuItem.SubMenu.Items.Add (fileOpenRecentClearListMenuItem);
			};
			fileMenu.SubMenu.Items.Add (fileOpenRecentMenuItem);

			/* File > Close */
			fileMenu.SubMenu.Items.Add (closeCommand.CreateMenuItem());

			fileMenu.SubMenu.Items.Add (new SeparatorMenuItem());

			/* File > Save */
			fileMenu.SubMenu.Items.Add (saveCommand.CreateMenuItem ());

			/* File > Save As */
			var fileSaveAsMenuItem = new MenuItem ("Save _As");
			fileSaveAsMenuItem.SubMenu = new Menu ();
			fileMenu.SubMenu.Items.Add (fileSaveAsMenuItem);

			/* File > Save As > Save to File... */
			fileSaveAsMenuItem.SubMenu.Items.Add (saveFileCommand.CreateMenuItem ());

			/* File > Save As > Save to URL... */
			fileSaveAsMenuItem.SubMenu.Items.Add (saveUrlCommand.CreateMenuItem ());

			fileSaveAsMenuItem.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Save As > Save Copy to File... */
			fileSaveAsMenuItem.SubMenu.Items.Add (saveCopyFileCommand.CreateMenuItem ());

			fileMenu.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Database Settings... */
			fileMenu.SubMenu.Items.Add (showDatabaseSettingsCommand.CreateMenuItem ());

			/* File > Change Master Key... */
			fileMenu.SubMenu.Items.Add (changeMasterKeyCommand.CreateMenuItem ());

			fileMenu.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Print... */
			fileMenu.SubMenu.Items.Add (printCommand.CreateMenuItem ());

			fileMenu.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Import... */
			fileMenu.SubMenu.Items.Add (importcommand.CreateMenuItem ());

			/* File > Export... */
			fileMenu.SubMenu.Items.Add (exportcommand.CreateMenuItem ());

			fileMenu.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Synchronize */
			var fileSynchronizeMenuItem = new MenuItem ("S_ynchronize");
			fileSynchronizeMenuItem.SubMenu = new Menu ();
			fileMenu.SubMenu.Items.Add (fileSynchronizeMenuItem);

			/* File > Synchronize > Synchronize with File... */
			fileSynchronizeMenuItem.SubMenu.Items.Add (synchronizeFileCommand.CreateMenuItem ());

			/* File > Synchronize > Synchronize with URL... */
			fileSynchronizeMenuItem.SubMenu.Items.Add (synchronizeUrlCommand.CreateMenuItem ());

			fileSynchronizeMenuItem.SubMenu.Items.Add (new SeparatorMenuItem ());

			/* File > Synchronize > Recent Files */
			var fileSynchronizeRecentMenuItem = new MenuItem ("_Recent Files");
			fileSynchronizeRecentMenuItem.SubMenu = new Menu ();
			// SubMenu is dynamically generated
			fileSynchronizeRecentMenuItem.Clicked += (sender, e) =>
			{
				fileSynchronizeRecentMenuItem.SubMenu.Items.Clear ();
				if (openRecentCommandList == null) {
					openRecentCommandList = new List<Command> ();
					// TODO: Populate from user settings
				}
				var hasItems = openRecentCommandList.Count > 0;
				if (hasItems) {
					foreach (var command in openRecentCommandList)
						fileSynchronizeRecentMenuItem.SubMenu.Items.Add (command.CreateMenuItem ());
				} else {
					fileSynchronizeRecentMenuItem.SubMenu.Items.Add
						(new MenuItem ("(No Recent Items)") { Sensitive = false });
				}
				fileSynchronizeRecentMenuItem.SubMenu.Items.Add (new SeparatorMenuItem ());
				var fileSynchronizeRecentClearListMenuItem = clearSynchronizeRecentListCommand.CreateMenuItem ();
				fileSynchronizeRecentClearListMenuItem.Sensitive = hasItems;
				fileSynchronizeRecentMenuItem.SubMenu.Items.Add (fileSynchronizeRecentClearListMenuItem);
			};
			fileSynchronizeMenuItem.SubMenu.Items.Add (fileSynchronizeRecentMenuItem);

			/* File > Lock Workspace */
			fileMenu.SubMenu.Items.Add (lockWorkspaceCommand.CreateMenuItem ());

			if (!isOSX) {
				fileMenu.SubMenu.Items.Add (new SeparatorMenuItem ());

				/* File > Quit */
				fileMenu.SubMenu.Items.Add (quitCommand.CreateMenuItem ());
			}

			/* Edit */
			var editMenu = new MenuItem ("_Edit");
			editMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (editMenu);

			if (!isOSX) {
				/* Edit > Preferences */
				var editPreferencesMenuItem = showPreferencesCommand.CreateMenuItem ();
				editMenu.SubMenu.Items.Add (editPreferencesMenuItem);
			}

			/* View */

			var viewMenu = new MenuItem ("_View");
			viewMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (viewMenu);


			/* Tools */

			var toolsMenu = new MenuItem ("_Tools");
			toolsMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (toolsMenu);


			/* Help */

			var helpMenu = new MenuItem ("_Help");
			helpMenu.SubMenu = new Menu ();
			MainMenu.Items.Add (helpMenu);

			if (!isOSX) {
				/* Help > About */
				helpMenu.SubMenu.Items.Add (aboutCommand.CreateMenuItem());
			}

			/* Content */

			Content = new HBox ();


			/* Events */

			CloseRequested += (sender, args) => quitCommand.Activate();
		}


	}
}

