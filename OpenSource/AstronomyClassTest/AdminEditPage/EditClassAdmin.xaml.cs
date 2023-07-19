using System;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для EditClassAdmin.xaml
    /// </summary>
    public partial class EditClassAdmin : Page
    {
        Classes currentClass = new Classes();
        int addClass = 1;
        public EditClassAdmin(Classes classes)
        {
            InitializeComponent();
            if (classes != null)
            {
                currentClass = classes;
                addClass = 2;
            }
            DataContext = currentClass;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addClass == 1)
                AstronomyClassDBEntities.GetContext().Classes.Add(currentClass);

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
