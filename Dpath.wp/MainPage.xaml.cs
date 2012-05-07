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
using Microsoft.Phone.Controls;
using Ninject;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core;
using Dpath.Mobile.Core.Models;
using Dpath.wp.ViewModels;

namespace Dpath.wp
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Set the data context of the listbox control to the sample data
			DataContext = AppViewContext.MainViewModel;
			this.Loaded += new RoutedEventHandler(MainPage_Loaded);
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			var userRegistered = AppViewContext.UserData.GetUser();

			if (userRegistered == null)
			{
				NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
				return;
			}
			else
			{
				AppContext.User = userRegistered;
			}

			base.OnNavigatedTo(e);
		}

		// Load data for the ViewModel Items
		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (!AppViewContext.MainViewModel.IsDataLoaded)
			{
				AppViewContext.MainViewModel.LoadData();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AppViewContext.ActualPath = (sender as Button).DataContext as PathViewModel;
			NavigationService.Navigate(new Uri("/GoalPage.xaml", UriKind.Relative));
			return;
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			AppViewContext.RefreshMainViewModel();
		}
	}
}