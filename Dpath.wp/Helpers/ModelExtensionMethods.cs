using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Dpath.Mobile.Core.Models;
using Dpath.wp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Dpath.wp.Helpers
{
	public static class ModelExtensionMethods
	{
		public static PathViewModel ConvertToPathView(this Path path)
		{
			var viewModel = new PathViewModel
			{
				Id = path.Id,
				Name = path.Name,
			};

			viewModel.Goals = new System.Collections.ObjectModel.ObservableCollection<GoalViewModel>();
			viewModel.Goals.AddRange(path.Goals.OrderBy(x => x.Order).Select(y => y.ConvertToGoalView()));

			return viewModel;
		}

		public static GoalViewModel ConvertToGoalView(this Goal goal)
		{
			var viewModel = new GoalViewModel
			{
				Id = goal.Id,
				Name = goal.Name
			};

			viewModel.Achievements = new System.Collections.ObjectModel.ObservableCollection<AchievementViewModel>();
			viewModel.Achievements.AddRange(goal.Achievements.Select(y => y.ConverToAchievementView()).OrderByDescending(x => x.DateCreated));

			return viewModel;
		}

		public static AchievementViewModel ConverToAchievementView(this Achievement achievement)
		{
			return new AchievementViewModel
			{
				Id = achievement.Id,
				Comment = achievement.Comment,
				DateCreated = achievement.DateCreated,
				Resolution = achievement.Resolution.ToString(),
				PrettyDate = achievement.PrettyDate
			};
		}
	}
}
