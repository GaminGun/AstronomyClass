using System;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для EditArticleTypeAdmin.xaml
    /// </summary>
    public partial class EditArticleTypeAdmin : Page
    {
        ArticleTypes currentArticleType = new ArticleTypes();
        int addArticleType = 1;
        public EditArticleTypeAdmin(ArticleTypes articleType)
        {
            InitializeComponent();
            if (articleType != null)
            {
                currentArticleType = articleType;
                addArticleType = 2;
            }
            DataContext = currentArticleType;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addArticleType == 1)
                AstronomyClassDBEntities.GetContext().ArticleTypes.Add(currentArticleType);
            try
            {
                AstronomyClassDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                Manager.AdminLoadPage.GoBack();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
