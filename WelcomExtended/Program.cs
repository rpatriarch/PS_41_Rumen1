using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomExtended.Data;
using WelcomExtended.Helpers;
using WelcomExtended.Loggers;
using static WelcomExtended.Others.Delegates;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            UserData userData = new UserData();

            User studentUser = new User()
            {
                Names = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.AddUsers(studentUser);

            User student2User = new User()
            {
                Names = "student2",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.AddUsers(student2User);

            User teacherUser = new User()
            {
                Names = "teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };
            userData.AddUsers(teacherUser);

            User adminUser = new User()
            {
                Names = "admin",
                Password = "12345",
                Role = UserRolesEnum.ADMIN
            };
            userData.AddUsers(adminUser);

            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            if (name != null && password != null)
            {
                string error = UserHelper.ValidateCredentials(userData, name, password);

                if (error != null)
                {
                    Console.WriteLine(error);
                }
                else
                {
                    User user = UserHelper.GetUser(userData, name, password);
                    Console.WriteLine(UserHelper.ToString(user));
                }
            }
            else
            {
                Console.WriteLine("Name and password cannot be null.");
            }
        }
    }
}
