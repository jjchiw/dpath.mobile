using System;
using Dpath.Mobile.Core.Models;
using System.Collections.Generic;

namespace Dpath.Mobile.Core.Controller
{
	public interface IPathController
	{
		void Get(Action<List<Path>> callback);
		void AddResolution(string pathId, string goalId, string resolution, string comment, Action<Achievement> callback);
	}
}
