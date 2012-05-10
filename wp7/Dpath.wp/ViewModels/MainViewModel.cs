using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Ninject;
using Dpath.Mobile.Core.Controller;
using Dpath.Mobile.Core.Models;
using Dpath.wp.ViewModels;
using Dpath.wp.Helpers;

namespace Dpath.wp
{
	public class MainViewModel
	{
		[Inject]
		public IPathController PathController { get; set; }

		public MainViewModel()
		{
			this.Paths = new ObservableCollection<PathViewModel>();
		}

		/// <summary>
		/// A collection for ItemViewModel objects.
		/// </summary>
		public ObservableCollection<PathViewModel> Paths { get; private set; }


		public bool IsDataLoaded
		{
			get;
			private set;
		}

		/// <summary>
		/// Creates and adds a few ItemViewModel objects into the Items collection.
		/// </summary>
		public void LoadData()
		{
			Paths.Clear();
			PathController.Get((x) =>
			{
				x.ForEach(y =>
				{
					Paths.Add(y.ConvertToPathView());
				});
			});
			// Sample data; replace with real data
			this.IsDataLoaded = true;
		}
	}
}