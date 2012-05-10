using System;
using System.Net;
using Dpath.Mobile.Core.Models;


namespace Dpath.monotouch.ViewModels
{
	public class AchievementViewModel
	{
		public string Id { get; set; }
		public string Comment { get; set; }
		public string Resolution { get; set; }
		public string PrettyDate { get; set; }

		public DateTime DateCreated { get; set; }
		
		public AchievementViewModel (Achievement achievement)
		{
			Id = achievement.Id;
			Comment = achievement.Comment;
			Resolution = achievement.Resolution;
			PrettyDate = achievement.PrettyDate;
			DateCreated = achievement.DateCreated;
		}
		
	}
}
