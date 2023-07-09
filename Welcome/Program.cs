using System;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Names = "John Smith";
            user.Password = "password123";
            user.Role = Others.UserRolesEnum.STUDENT;

            UserViewModel viewModel = new UserViewModel(user);

            UserView view = new UserView(viewModel);

            view.Display();

            Console.ReadKey();
        }
    }
}