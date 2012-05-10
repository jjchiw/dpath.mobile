using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Dpath.Mobile.Core;

namespace DPath.monotouch
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UIViewController view = null;
		UINavigationController _navigationController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_navigationController = new UINavigationController ();  
			window.AddSubview (_navigationController.View); 
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			var info = NSUserDefaults.StandardUserDefaults;
			var infoEmail = info.StringForKey(AppConstants.EMAIL_INFO);
			var infoToken = info.StringForKey(AppConstants.TOKEN_INFO);
			
			
			
			//window.RootViewController = NavigationController;
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			
			if(infoEmail == null)
			{
				view = new UserLoginScreen();
			}
			else
			{
				AppContext.User = new Dpath.Mobile.Core.Models.User {Email = infoEmail, Token = infoToken};
				view = new PathsIndexScreen(); 
			}
			
			_navigationController.PushViewController (view, true); 
			
			return true;
		}
	}
}

