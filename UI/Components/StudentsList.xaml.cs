using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Welcome.Others;

namespace UI.Components
{
    public partial class StudentsList : UserControl
    {
        private MainWindow mainWindow;
        private List<DatabaseUser> originalUsers;
        private DatabaseContext context;

        public StudentsList()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow as MainWindow;
            context = new DatabaseContext();
            LoadData();
            DataContext = this; // Привържване на текущия контекст към UserControl
        }

        public void LoadData()
        {
            originalUsers = context.Users.ToList().AsEnumerable()
        .OrderBy(u => u.RoleOrder)
        .ThenBy(u=> u.Names)
        .ToList();
            
            students.DataContext = originalUsers;

        }


        private void BtnGenerateRandomText_Click(object sender, RoutedEventArgs e)
        {
            RandomTextWindow randomTextWindow = new RandomTextWindow();
            randomTextWindow.ShowDialog();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            int maxId = originalUsers.Count > 0 ? originalUsers.Max(u => u.Id) : 0;
            var newUser = new DatabaseUser()
            {
                Id = maxId + 1,
                Names = "New User",
                Role = UserRolesEnum.USER
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            mainWindow?.ShowSuccessMessage("User successfully added!");

            LoadData();
        }

        private void BtnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (students.SelectedItem != null)
            {
                var selectedUser = (DatabaseUser)students.SelectedItem;

                context.Users.Remove(selectedUser);
                context.SaveChanges();

                mainWindow?.ShowSuccessMessage("User successfully removed!");

                LoadData();
            }
            else
            {
                mainWindow?.ShowErrorMessage("Please select a user to remove!");
            }
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();

            mainWindow?.ShowSuccessMessage("Changes saved successfully!");

            LoadData();
        }

        
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }

        
        public IEnumerable<UserRolesEnum> UserRoles
        {
            get { return Enum.GetValues(typeof(UserRolesEnum)).Cast<UserRolesEnum>().OrderBy(r => r == UserRolesEnum.USER).ThenBy(r => r.ToString()); }
        }

    }
}
