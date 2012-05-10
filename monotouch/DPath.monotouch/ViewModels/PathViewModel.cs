using System;
using System.Net;
using Dpath.Mobile.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dpath.monotouch.ViewModels
{
	public class PathViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<GoalViewModel> Goals { get; set; }
		
		public PathViewModel (Path path)
		{
			Id = path.Id;
			Name = path.Name;
			Goals = path.Goals.Select(x => new GoalViewModel(x)).ToList();
		}
	}
}
