using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для OutputArticlesPage.xaml
    /// </summary>
    public partial class OutputArticlesPage : Page
    {
        Users user;
        public OutputArticlesPage(Users user)
        {
            InitializeComponent();
            this.user = user;
            if (user.id_role == 1)
                PanelControlArticles.Visibility = Visibility.Collapsed;

            var allTypes = AstronomyClassDBEntities.GetContext().ArticleTypes.ToList();
            allTypes.Insert(0, new ArticleTypes
            {
                name_type = "Все типы"
            });
            TypeArticleSearch.ItemsSource = allTypes;
            TypeArticleSearch.SelectedIndex = 0;

            var currentArticles = AstronomyClassDBEntities.GetContext().ArticleTypes.ToList();
            OutputArticleList.ItemsSource = currentArticles;
            UpdateArticles();
        }

        private void TypeArticleSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateArticles();
        }
        private void NameArticleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateArticles();
        }

        void UpdateArticles()
        {
            var currentArticles = AstronomyClassDBEntities.GetContext().Articles.Where(p => p.active == true).ToList();

            if (NameArticleSearch.Text != null)
                currentArticles = currentArticles.Where(p => p.name_article.ToLower().Contains(NameArticleSearch.Text.ToLower()) && p.active == true).ToList();
            if (TypeArticleSearch.SelectedIndex > 0)
                currentArticles = currentArticles.Where(p => p.id_type == (TypeArticleSearch.SelectedItem as ArticleTypes).id && p.active == true).ToList();
            OutputArticleList.ItemsSource = currentArticles;
        }

        private void BtnEditArticle_Click(object sender, RoutedEventArgs e)
        {
            if (user.id_role == 1)
                MessageBox.Show("Отказано в доступе.");
            else
                Manager.MainLoadPage.Navigate(new AddEditArticlePage((sender as Button).DataContext as Articles, user));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (user.id_role == 1)
                MessageBox.Show("Отказано в доступе.");
            else
                Manager.MainLoadPage.Navigate(new AddEditArticlePage(null, user));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentArticlesForDeleting = OutputArticleList.SelectedItems.Cast<Articles>().ToList();
            if (currentArticlesForDeleting.Count == 0)
            {
                MessageBox.Show("Выберите элементы для удаления.");
            }
            else if (MessageBox.Show($"Вы уверены, что хотите удалить следующие {currentArticlesForDeleting.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    AstronomyClassDBEntities.GetContext().Articles.RemoveRange(currentArticlesForDeleting);
                    AstronomyClassDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            UpdateArticles();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AstronomyClassDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                UpdateArticles();
            }
        }

        private void FullViewArticle_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.Navigate(new FullViewArticlePage((sender as Button).DataContext as Articles, user));
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (user.id_role == 2)
            {
                ViewMark_GenerateReport viewMarkWin = new ViewMark_GenerateReport(user, null);
                viewMarkWin.ShowDialog();
            }
        }
    }
}
