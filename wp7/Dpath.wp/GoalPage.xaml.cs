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
using Dpath.Mobile.Core.Models;
using Dpath.wp.ViewModels;

namespace Dpath.wp
{
	public partial class GoalPage : PhoneApplicationPage
	{
		public GoalPage()
		{
			InitializeComponent();

			DataContext = AppViewContext.ActualPath;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AppViewContext.ActualGoal = (sender as Button).DataContext as GoalViewModel;
			NavigationService.Navigate(new Uri("/AchievementsPage.xaml", UriKind.Relative));
			return;
		}
	}
}