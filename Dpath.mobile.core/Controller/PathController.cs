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
using System.Collections.Generic;
using Path = Dpath.Mobile.Core.Models.Path;
using RestSharp;
using Newtonsoft.Json;
using Dpath.Mobile.Core.Models;

namespace Dpath.Mobile.Core.Controller
{
	public class PathController : Dpath.Mobile.Core.Controller.IPathController
	{
		private RestClient _client;

		public PathController()
		{
			_client = new RestClient
			{
				BaseUrl = Settings.Url
			};

			
		}

		public void Get(Action<List<Path>> callback)
		{
			var request = new RestRequest
			{
				Resource = "/api/paths/my-paths",
				Method = Method.POST
			};

			_client.Authenticator = new HttpBasicAuthenticator(AppContext.User.Email, AppContext.User.Token);

			_client.ExecuteAsync(request, (response, req) =>
			{
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var paths = JsonConvert.DeserializeObject<List<Path>>(response.Content);
					callback(paths);
					return;
				}
				callback(null);

			});
		}

		public void AddResolution(string pathId, string goalId, string resolution, string comments, Action<Achievement> callback)
		{
			var request = new RestRequest
			{
				Resource = "/api/{pathId}/goal/{goalId}/{resolution}",
				Method = Method.POST
			};

			_client.Authenticator = new HttpBasicAuthenticator(AppContext.User.Email, AppContext.User.Token);

			request.AddUrlSegment("pathId", pathId);
			request.AddUrlSegment("goalId", goalId);
			request.AddUrlSegment("resolution", resolution);

			request.AddParameter("comment", comments);

			_client.ExecuteAsync(request, (response, req) =>
			{
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var paths = JsonConvert.DeserializeObject<Achievement>(response.Content);
					callback(paths);
					return;
				}
				callback(null);
			});
		}
	}
}
