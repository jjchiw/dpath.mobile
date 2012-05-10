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

namespace Dpath.wp.ViewModels
{
	public class AchievementViewModel
	{
		public string Id { get; set; }
		public string Comment { get; set; }
		public string Resolution { get; set; }
		public string PrettyDate { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
