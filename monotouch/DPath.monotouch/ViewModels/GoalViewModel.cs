using System;
using System.Net;
using Dpath.Mobile.Core.Models;
using System.Collections.Generic;
using System.Linq;
namespace Dpath.monotouch.ViewModels
{
	public class GoalViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<AchievementViewModel> Achievements { get; set; }

		public int TotalUsersInGoal { get; set; }
		
		public GoalViewModel (Goal goal)
		{
			Id = goal.Id;
			Name = goal.Name;
			Achievements = goal.Achievements.Select(x => new AchievementViewModel(x)).ToList();
		}
	}
}
