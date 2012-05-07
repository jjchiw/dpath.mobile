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
using System.Collections.Generic;

namespace Dpath.wp.Helpers
{
	public static class ObservableCollectionExtensions
	{
		public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> add)
		{
			foreach (var item in add)
			{
				collection.Add(item);
			}
		}
	}
}
