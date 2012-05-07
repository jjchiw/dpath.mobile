using System;
using System.Collections.Generic;
using System.Linq;

namespace Dpath.Mobile.Core.Models
{
	public class Achievement
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string GravatarUrl { get; set; }
		public string Comment { get; set; }
		public string Resolution { get; set; }
		public DateTime DateCreated { get; set; }
		public string PrettyDate {get; set;}
	}
}