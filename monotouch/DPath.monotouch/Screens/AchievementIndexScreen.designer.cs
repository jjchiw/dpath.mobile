// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace DPath.monotouch
{
	[Register ("AchievementIndexScreen")]
	partial class AchievementIndexScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView _tblAchievements { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _btnOnCourse { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _btnAstray { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_tblAchievements != null) {
				_tblAchievements.Dispose ();
				_tblAchievements = null;
			}

			if (_btnOnCourse != null) {
				_btnOnCourse.Dispose ();
				_btnOnCourse = null;
			}

			if (_btnAstray != null) {
				_btnAstray.Dispose ();
				_btnAstray = null;
			}
		}
	}
}
