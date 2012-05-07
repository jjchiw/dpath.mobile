using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Dpath.Mobile.Core.Controller;
using Ninject;
using Dpath.Mobile.Core;

namespace Dpath.wp
{
	public partial class Login : PhoneApplicationPage
	{
		LoginComponents _loginComponents;

		public Login()
		{
			InitializeComponent();
			_loginComponents = AppContext.Get<LoginComponents>();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var email = emailTextBox.Text;
			var token = tokenTextBox.Text;
			_loginComponents.UserController.VerifyToken(email, token, (userView) =>
			{
				if (userView != null)
				{
					AppViewContext.UserData.Save(userView);
					AppContext.User = userView;
					Dispatcher.BeginInvoke(() =>
					{
						Microsoft.Phone.Shell.SystemTray.ProgressIndicator.IsVisible = false;
						NavigationService.GoBack();
					});

					return;
				}
			});
		}
	}

	public class LoginComponents
	{
		[Inject]
		public IUserController UserController { get; set; }
	}
}