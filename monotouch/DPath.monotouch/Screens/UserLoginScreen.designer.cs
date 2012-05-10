// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace DPath.monotouch
{
	[Register ("UserLoginScreen")]
	partial class UserLoginScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField _emailTexField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _tokenTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _loginButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_emailTexField != null) {
				_emailTexField.Dispose ();
				_emailTexField = null;
			}

			if (_tokenTextField != null) {
				_tokenTextField.Dispose ();
				_tokenTextField = null;
			}

			if (_loginButton != null) {
				_loginButton.Dispose ();
				_loginButton = null;
			}
		}
	}
}
