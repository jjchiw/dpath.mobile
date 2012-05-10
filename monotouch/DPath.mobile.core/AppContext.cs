using System;
using System.Net;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core.Models;

namespace Dpath.Mobile.Core
{
	public class AppContext
	{
		public static TinyIoC.TinyIoCContainer Kernel
		{
			get { return TinyIoC.TinyIoCContainer.Current; }
		}

		public static User User { get; set; }

		static AppContext()
		{
			Kernel.Register<IPathController>(new PathController());
			Kernel.Register<IUserController>(new UserController());
			
		}

		public static T Get<T>() where T : class
		{
			return Kernel.Resolve<T>();
		}
	}
}
