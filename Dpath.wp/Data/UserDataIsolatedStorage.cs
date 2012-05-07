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
using System.IO.IsolatedStorage;
using Dpath.Mobile.Core.Models;
using Newtonsoft.Json;

namespace Dpath.wp.Data
{
	public class UserDataIsolatedStorage : IUserData
	{
		System.IO.IsolatedStorage.IsolatedStorageSettings _settings;
		private const string USER_KEY = "UserData";

		public UserDataIsolatedStorage()
		{
			_settings = IsolatedStorageSettings.ApplicationSettings;
		}

		public bool Save(User user)
		{

			// txtInput is a TextBox defined in XAML.
			if (!_settings.Contains(USER_KEY))
			{
				_settings.Add(USER_KEY, JsonConvert.SerializeObject(user));
			}
			else
			{
				_settings[USER_KEY] = JsonConvert.SerializeObject(user);
			}
			_settings.Save();

			return true;
		}

		public User GetUser()
		{
			if (!_settings.Contains(USER_KEY))
				return null;


			return JsonConvert.DeserializeObject<User>(_settings[USER_KEY].ToString());
		}
	}
}
