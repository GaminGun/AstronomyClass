using System;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для EditRoleAdmin.xaml
    /// </summary>
    public partial class EditRoleAdmin : Page
    {
        Roles currentRole = new Roles();
        int addRole = 1;
        public EditRoleAdmin(Roles role)
        {
            InitializeComponent();
            if (role != null)
            {
                currentRole = role;
                addRole = 2;
            }
            DataContext = currentRole;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addRole == 1)
                AstronomyClassDBEntities.GetContext().Roles.Add(currentRole);

            try
            {
                AstronomyClassDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                Manager.AdminLoadPage.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
