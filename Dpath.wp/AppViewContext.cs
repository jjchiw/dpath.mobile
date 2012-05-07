using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Ninject;
using Dpath.wp.Data;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core;
using Dpath.Mobile.Core.Models;
using Dpath.wp.ViewModels;

namespace Dpath.wp
{
	public class AppViewContext
	{
		static MainViewModel _mainViewModel;

		public static void Initialize()
		{
			AppContext.Kernel.Bind<IUserData>().To<UserDataIsolatedStorage>();
		}

		public static IUserData UserData
		{
			get
			{
				return AppContext.Get<IUserData>();
			}
		}

		public static MainViewModel MainViewModel
		{
			get
			{
				if (_mainViewModel == null)
					_mainViewModel = AppContext.Get<MainViewModel>();
				
				return _mainViewModel;
			}
		}

		public static void RefreshMainViewModel()
		{
			_mainViewModel.LoadData();
		}

		public static PathViewModel ActualPath { get; set; }

		public static GoalViewModel ActualGoal { get; set; }
	}
}
