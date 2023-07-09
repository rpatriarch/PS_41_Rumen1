using System;
using Welcome.Model;
using WelcomExtended.Data;
using System.Linq;


namespace WelcomExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(User user)
        {
            return $"User: {user.Names}, Id: {user.Id}, Role: {user.Role}, Active: {user.Active}, ValidUntil: {user.ValidUntil}";
        }

        public static string ValidateCredentials(UserData userData, string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "The Name cannot be empty.";
            }

            if (string.IsNullOrEmpty(password))
            {
                return "The Password cannot be empty.";
            }

            var user = userData.ValidateUser(name, password);
            if (user == false)
            {
                return "Invalid credentials.";
            }

            return null;
        }

        public static User GetUser(UserData userData, string name, string password)
        {
            var user = userData.GetUser(name, password);
            return user;
        }
    }
}
