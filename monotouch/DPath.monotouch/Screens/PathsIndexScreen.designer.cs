// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace DPath.monotouch
{
	[Register ("PathsIndexScreen")]
	partial class PathsIndexScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView _tblPaths { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_tblPaths != null) {
				_tblPaths.Dispose ();
				_tblPaths = null;
			}
		}
	}
}
