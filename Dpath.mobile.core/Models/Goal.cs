using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dpath.Mobile.Core.Models
{
	public class Goal
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public List<Achievement> Achievements { get; set; }

		public int TotalUsersInGoal { get; set; }
	}
}
