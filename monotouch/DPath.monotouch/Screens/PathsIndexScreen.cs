using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Dpath.Mobile.Core.Models;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core;
using System.Collections.Generic;
using System.Linq;
using Dpath.monotouch.ViewModels;
using Dpath.monotouch;

namespace DPath.monotouch
{
	public partial class PathsIndexScreen : UIViewController
	{
		
		PathTableViewSource _tableViewSource;
		IPathController _pathController; 
		
		
		public PathsIndexScreen () : base ("PathsIndexScreen", null)
		{
			_pathController = AppContext.Get<IPathController>();
			
			var registerSettingButton = new UIBarButtonItem(){
				Title = "Login",
				Style = UIBarButtonItemStyle.Done
			};
			
			registerSettingButton.Clicked += (sender, e) => {
				Array.Clear(NavigationController.ViewControllers, 0, NavigationController.ViewControllers.Count());
				NavigationController.PushViewController(new UserLoginScreen(), true);
				
			};
			
			NavigationItem.RightBarButtonItem = registerSettingButton;
			Title = "Paths";
			
			
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			LoadPaths();
		}
		
		private void LoadPaths()
		{
			var tableItems = new List<PathTableViewItemGroup> ();
			
			_pathController.Get((paths) =>
			{
				var pathTableItems = paths.Select(x => new PathViewModel(x));			
				var pathTableGroup = new PathTableViewItemGroup();
				
				pathTableGroup.Items.AddRange(pathTableItems);			
				tableItems.Add(pathTableGroup);			
				this._tableViewSource = new PathTableViewSource(tableItems, this);			
				this._tblPaths.Source = this._tableViewSource;
			
				InvokeOnMainThread(() => this._tblPaths.ReloadData());
			});
			
			
		}
	}
	
	
	class PathTableViewItemGroup
	{
		public string Name { get; set; }

		public string Footer { get; set; }
		
		public List<PathViewModel> Items
		{
			get { return this._items; }
			set { this._items = value; }
		}
		protected List<PathViewModel> _items = new List<PathViewModel>();
		
		public PathTableViewItemGroup ()
		{
		}
	}
	
	class PathTableViewSource : UITableViewSource
	{
		protected List<PathTableViewItemGroup> _tableItems;
		protected UIViewController _controller;
		string _cellIdentifier = "PathTableViewCell";
		
		
		public PathTableViewSource (List<PathTableViewItemGroup> items, UIViewController controller)
		{
			this._tableItems = items;
			this._controller = controller;
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return this._tableItems.Count;
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return this._tableItems[section].Name;
		}
		
		public override string TitleForFooter (UITableView tableView, int section)
		{
			return this._tableItems[section].Footer;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return this._tableItems[section].Items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(this._cellIdentifier);
			
			if(cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, this._cellIdentifier);
			}
			
			var item = this._tableItems[indexPath.Section].Items[indexPath.Row];
			
			cell.TextLabel.Text = item.Name;
			
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
			
			
			return cell;
		}
		
		public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
		{
			AppViewContext.ActualPath = this._tableItems[indexPath.Section].Items[indexPath.Row];
			
			var view = new GoalIndexScreen();
			_controller.NavigationController.PushViewController(view, true);
		}
	}
}

