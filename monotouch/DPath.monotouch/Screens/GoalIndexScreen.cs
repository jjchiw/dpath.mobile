using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Dpath.monotouch;
using System.Collections.Generic;
using Dpath.monotouch.ViewModels;

namespace DPath.monotouch
{
	public partial class GoalIndexScreen : UIViewController
	{
		GoalTableViewSource _tableViewSource;
		
		public GoalIndexScreen () : base ("GoalIndexScreen", null)
		{
			Title = "Goals";
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
			
			var tableItems = new List<GoalTableViewItemGroup> ();
			// Perform any additional setup after loading the view, typically from a nib.
			var goalTableItems = AppViewContext.ActualPath.Goals;
			var goalTableGroup = new GoalTableViewItemGroup();
			
			goalTableGroup.Items.AddRange(goalTableItems);			
			tableItems.Add(goalTableGroup);			
			this._tableViewSource = new GoalTableViewSource(tableItems, this);			
			this._tblGoals.Source = this._tableViewSource;
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
	}
	
	class GoalTableViewItemGroup
	{
		public string Name { get; set; }

		public string Footer { get; set; }
		
		public List<GoalViewModel> Items
		{
			get { return this._items; }
			set { this._items = value; }
		}
		protected List<GoalViewModel> _items = new List<GoalViewModel>();
		
		public GoalTableViewItemGroup ()
		{
		}
	}
	
	class GoalTableViewSource : UITableViewSource
	{
		protected List<GoalTableViewItemGroup> _tableItems;
		protected UIViewController _controller;
		string _cellIdentifier = "GoalTableViewCell";
		
		
		public GoalTableViewSource (List<GoalTableViewItemGroup> items, UIViewController controller)
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
			AppViewContext.ActualGoal = this._tableItems[indexPath.Section].Items[indexPath.Row];
			
			var view = new AchievementIndexScreen();
			_controller.NavigationController.PushViewController(view, true);
		}
	}
}

