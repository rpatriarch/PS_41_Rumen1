using System;
using System.Linq;
using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Model;
using Welcome.Others;

using (var context = new DatabaseContext())
{
    context.Database.EnsureCreated();
    context.Add<DatabaseUser>(new DatabaseUser()
    {
        Names = "user",
        Password = "password",
        ValidUntil = DateTime.Now,
        Role = UserRolesEnum.STUDENT
    });
    context.SaveChanges();

    Console.WriteLine("Enter user name:");
    string? userName = Console.ReadLine();
    Console.WriteLine("Enter password:");
    string? password = Console.ReadLine();
    var validUser = context.Users.FirstOrDefault(u => u.Names == userName && u.Password == password && u.ValidUntil > DateTime.Now);

    if (validUser != null)
    {
        Console.WriteLine("Valid User");
    }
    else
    {
        Console.WriteLine("Invalid Date");
    }

    var users = context.Users.ToList();
    Console.ReadKey();


}


