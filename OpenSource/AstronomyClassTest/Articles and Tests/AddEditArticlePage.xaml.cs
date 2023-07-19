using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для AddEditArticlePage.xaml
    /// </summary>
    public partial class AddEditArticlePage : Page
    {
        Articles currentArticle = new Articles();
        Users user;
        public AddEditArticlePage(Articles selectedArticle, Users user)
        {
            InitializeComponent();
            this.user = user;

            if (selectedArticle != null)
                currentArticle = selectedArticle;
            DataContext = currentArticle;

            SelectedType.ItemsSource = AstronomyClassDBEntities.GetContext().ArticleTypes.ToList();
        }
        private void SaveArticleBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (NameArticle.Text == null)
                error.AppendLine("Укажите название статьи.");
            if (SelectedType.SelectedItem == null)
                error.AppendLine("Укажите тип объекта");
            if (DescriptionObjectArticle.Text == null)
                error.AppendLine("Подготовьте описание объекта.");
            if (TextObjectArticle.Text == null)
                error.AppendLine("Напишите основной текст статьи.");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            currentArticle.id_teacher = user.id;
            currentArticle.date_create_article = DateTime.Now;

            if (currentArticle.id == 0)
            {
                currentArticle.active = true;
                AstronomyClassDBEntities.GetContext().Articles.Add(currentArticle);
            }

            try
            {
                AstronomyClassDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                Manager.MainLoadPage.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(All Files)|*.*";
            if (openImage.ShowDialog() == true)
            {
                if (openImage.FileName.Contains(".png") || openImage.FileName.Contains(".jpg") || openImage.FileName.Contains(".bmp"))
                    currentArticle.image = File.ReadAllBytes(openImage.FileName);
                else MessageBox.Show("Загрузите изображение.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.GoBack();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth >= 1150)
                this.FontSize = 20;
            else
                this.FontSize = 18;
        }
    }
}
