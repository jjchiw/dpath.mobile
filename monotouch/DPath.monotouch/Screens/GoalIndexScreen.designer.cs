// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace DPath.monotouch
{
	[Register ("GoalIndexScreen")]
	partial class GoalIndexScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView _tblGoals { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_tblGoals != null) {
				_tblGoals.Dispose ();
				_tblGoals = null;
			}
		}
	}
}
