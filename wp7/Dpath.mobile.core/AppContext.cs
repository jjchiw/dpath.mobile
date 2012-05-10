using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core.Models;

namespace Dpath.Mobile.Core
{
	public class AppContext
	{
		private static IKernel _kernel;

		public static IKernel Kernel
		{
			get { return _kernel; }
		}

		public static User User { get; set; }

		static AppContext()
		{
			_kernel = new StandardKernel();
		}

		public static void Initialize()
		{
			Kernel.Bind<IPathController>().To<PathController>();
			Kernel.Bind<IUserController>().To<UserController>();
		}

		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
	}
}
