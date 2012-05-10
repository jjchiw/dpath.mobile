using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Dpath.Mobile.Core;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core.Models;
using System.Linq;

namespace DPath.monotouch
{
	public partial class UserLoginScreen : UIViewController
	{
		IUserController _userController;
		
		public UserLoginScreen () : base ("UserLoginScreen", null)
		{
			_userController = AppContext.Get<IUserController>();
			
			
			
			var cancelSettingButton = new UIBarButtonItem(){
				Title = "Cancel",
				Style = UIBarButtonItemStyle.Done
			};
			
			cancelSettingButton.Clicked += (sender, e) => {
				if(AppContext.User != null)
				{
					Array.Clear(NavigationController.ViewControllers, 0, NavigationController.ViewControllers.Count());
					NavigationController.PushViewController(new PathsIndexScreen(), true);
				}
					
			};
			
			NavigationItem.LeftBarButtonItem = cancelSettingButton;
			Title = "Login";
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
			this._loginButton.TouchDown += (sender, e) => {
				
				_userController.VerifyToken(this._emailTexField.Text, this._tokenTextField.Text, (user) =>
				{
					if(user == null)
						return;
					
					AppContext.User = user;
					
					var info = NSUserDefaults.StandardUserDefaults;
					SaveSynchronizeInfo(AppConstants.EMAIL_INFO, AppContext.User.Email, info);
					SaveSynchronizeInfo(AppConstants.TOKEN_INFO, AppContext.User.Token, info);
					
					NavigationController.PushViewController (new PathsIndexScreen(), true);  
				
				});
			};
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
		
		private void SaveSynchronizeInfo(string key, string val, NSUserDefaults info)
		{
			if(val == string.Empty)
				info.RemoveObject(key);
			else
				info[key] = new NSString(val);
			
			info.Synchronize();
		}
	}
}

