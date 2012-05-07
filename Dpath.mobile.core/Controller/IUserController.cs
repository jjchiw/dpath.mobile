using System;
using Dpath.Mobile.Core.Models;
namespace Dpath.Mobile.Core.Controller
{
	public interface IUserController
	{
		void VerifyToken(string email, string token, Action<User> callback);
	}
}
