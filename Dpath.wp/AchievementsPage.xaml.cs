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
using Ninject;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core;
using Dpath.wp.Helpers;
using Dpath.Mobile.Core.Models;

namespace Dpath.wp
{
	public partial class AchievementsPage : PhoneApplicationPage
	{
		AchievementPageComponents _pageComponents;

		public AchievementsPage()
		{
			InitializeComponent();

			_pageComponents = AppContext.Get<AchievementPageComponents>();
			DataContext = AppViewContext.ActualGoal;
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			var pathId = AppViewContext.ActualPath.Id;
			var goalId = AppViewContext.ActualGoal.Id;
			var resolution = "oncourse";
			var comment = "";
			_pageComponents.PathController.AddResolution(pathId, goalId, resolution, comment, AddToActualGoal);
		}

		private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
		{
			var pathId = AppViewContext.ActualPath.Id;
			var goalId = AppViewContext.ActualGoal.Id;
			var resolution = "astray";
			var comment = "";
			_pageComponents.PathController.AddResolution(pathId, goalId, resolution, comment, AddToActualGoal);
		}

		Action<Achievement> AddToActualGoal = (achievement) =>
		{
			if (achievement != null)
			{
				AppViewContext.ActualGoal.Achievements.Insert(0, achievement.ConverToAchievementView());
			}
		};
	}

	public class AchievementPageComponents
	{
		[Inject]
		public IPathController PathController { get; set; }
	}
}