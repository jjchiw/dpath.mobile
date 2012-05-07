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
using System.Collections.ObjectModel;

namespace Dpath.wp.ViewModels
{
	public class PathViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public ObservableCollection<GoalViewModel> Goals { get; set; }
	}
}
