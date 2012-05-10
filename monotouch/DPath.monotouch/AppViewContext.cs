using System;
using System.Net;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core;
using Dpath.Mobile.Core.Models;
using Dpath.monotouch.ViewModels;

namespace Dpath.monotouch
{
	public class AppViewContext
	{
		public static PathViewModel ActualPath { get; set; }

		public static GoalViewModel ActualGoal { get; set; }
	}
}
