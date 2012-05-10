using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using Dpath.monotouch.ViewModels;
using Dpath.monotouch;
using Dpath.Mobile.Core;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core.Models;

namespace DPath.monotouch
{
	public partial class AchievementIndexScreen : UIViewController
	{
		AchievementTableViewSource _tableViewSource;
		IPathController _pathController;
		
		public AchievementIndexScreen () : base ("AchievementIndexScreen", null)
		{
			Title = "Achievements";
			_pathController = AppContext.Get<IPathController>();
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
			
			LoadTable ();
			
			
			this._btnOnCourse.TouchDown += (sender, e) => 
			{
				var resolution = "oncourse";
				
				
				PostResolution (resolution);
			};
			
			this._btnAstray.TouchDown += (sender, e) => 
			{
				
				var resolution = "astray";
				
				
				PostResolution (resolution);
			};
			
		}

		void PostResolution (string resolution)
		{
			var pathId = AppViewContext.ActualPath.Id;
			var goalId = AppViewContext.ActualGoal.Id;
			var comment = "";
			_pathController.AddResolution(pathId, goalId, resolution, comment, (achievement) =>
			{
				if(achievement != null)
				{
					AppViewContext.ActualGoal.Achievements.Insert(0, new AchievementViewModel(achievement));
					LoadTable();
				}
			});
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

		void LoadTable ()
		{
			// Perform any additional setup after loading the view, typically from a nib.
			var tableItems = new List<AchievementTableViewItemGroup> ();
			// Perform any additional setup after loading the view, typically from a nib.
			var achievementTableItems = AppViewContext.ActualGoal.Achievements;
			var achievementTableGroup = new AchievementTableViewItemGroup();
			
			achievementTableGroup.Items.AddRange(achievementTableItems);			
			tableItems.Add(achievementTableGroup);			
			this._tableViewSource = new AchievementTableViewSource(tableItems, this);			
			this._tblAchievements.Source = this._tableViewSource;
			InvokeOnMainThread(() => this._tblAchievements.ReloadData());
		}
	}
	
	class AchievementTableViewItemGroup
	{
		public string Name { get; set; }

		public string Footer { get; set; }
		
		public List<AchievementViewModel> Items
		{
			get { return this._items; }
			set { this._items = value; }
		}
		protected List<AchievementViewModel> _items = new List<AchievementViewModel>();
		
		public AchievementTableViewItemGroup ()
		{
		}
	}
	
	class AchievementTableViewSource : UITableViewSource
	{
		protected List<AchievementTableViewItemGroup> _tableItems;
		protected UIViewController _controller;
		string _cellIdentifier = "AchievementTableViewCell";
		
		
		public AchievementTableViewSource (List<AchievementTableViewItemGroup> items, UIViewController controller)
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
			
			cell.TextLabel.Text = item.Resolution;
			
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
			
			
			return cell;
		}
		
		
	}
}

