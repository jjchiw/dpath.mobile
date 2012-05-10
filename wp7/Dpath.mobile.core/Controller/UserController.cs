using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Net;
using Dpath.Mobile.Core.Models;
using RestSharp.Serializers;
using Newtonsoft.Json;

namespace Dpath.Mobile.Core.Controller
{
	public class UserController : Dpath.Mobile.Core.Controller.IUserController
	{
		private RestClient _client;

		public UserController()
		{
			_client = new RestClient
			{
				BaseUrl = Settings.Url
			};
		}

		public void VerifyToken(string email, string token, Action<User> callback)
		{
			var request = new RestRequest("/api/paths/user/validate", Method.POST);

			request.AddParameter("Email", email);
			request.AddParameter("Token", token);

			_client.Authenticator = new HttpBasicAuthenticator(email, token);

			_client.ExecuteAsync(request, (response, req) =>
			{
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var userView = JsonConvert.DeserializeObject<User>(response.Content);
					callback(userView);
					return;
				}
				callback(null);
					
			});
		}
	}
}
