using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для MainAdminWin.xaml
    /// </summary>
    public partial class MainAdminWin : Page
    {
        public MainAdminWin()
        {
            InitializeComponent();
            UploadDataBaseInfo();
        }

        void UploadDataBaseInfo()
        {
            RolesGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Roles.ToList();
            ClassesGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Classes.ToList();
            UsersGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Users.ToList();
            TypesGrid.ItemsSource = AstronomyClassDBEntities.GetContext().ArticleTypes.ToList();
            ArticlesGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Articles.ToList();
            TestsGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Tests.ToList();
            QuestionsGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Questions.ToList();
            MarksGrid.ItemsSource = AstronomyClassDBEntities.GetContext().Marks.ToList();
        }
        
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == 0)
            {
                var selectedRoles = RolesGrid.SelectedItems.Cast<Roles>().ToList();
                if (selectedRoles != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedRoles.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Roles.RemoveRange(selectedRoles);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 1)
            {
                var selectedClasses = ClassesGrid.SelectedItems.Cast<Classes>().ToList();
                if (selectedClasses != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedClasses.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Classes.RemoveRange(selectedClasses);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 2)
            {
                var selectedUsers = UsersGrid.SelectedItems.Cast<Users>().ToList();
                if (selectedUsers != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedUsers.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Users.RemoveRange(selectedUsers);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 3)
            {
                var selectedArticleTypes = TypesGrid.SelectedItems.Cast<ArticleTypes>().ToList();
                if (selectedArticleTypes != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedArticleTypes.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().ArticleTypes.RemoveRange(selectedArticleTypes);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 4)
            {
                var selectedArticles = ArticlesGrid.SelectedItems.Cast<Articles>().ToList();
                if (selectedArticles != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedArticles.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Articles.RemoveRange(selectedArticles);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 5)
            {
                var selectedTests = TestsGrid.SelectedItems.Cast<Tests>().ToList();
                if (selectedTests != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedTests.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Tests.RemoveRange(selectedTests);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 6)
            {
                var selectedQuestions = QuestionsGrid.SelectedItems.Cast<Questions>().ToList();
                if (selectedQuestions != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedQuestions.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Questions.RemoveRange(selectedQuestions);
                        SaveChangesInDataBase();
                    }
                }
            }
            if (TabControlMain.SelectedIndex == 7)
            {
                var selectedMarks = MarksGrid.SelectedItems.Cast<Marks>().ToList();
                if (selectedMarks != null)
                {
                    if (MessageBox.Show($"Вы хотите удалить {selectedMarks.Count} элементов?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AstronomyClassDBEntities.GetContext().Marks.RemoveRange(selectedMarks);
                        SaveChangesInDataBase();
                    }
                }
            }
            UploadDataBaseInfo();
        }

        private void EditActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == 2)
            {
                Users selectUser = UsersGrid.SelectedItem as Users;
                if (selectUser.id_role == 3)
                {
                    MessageBox.Show("Вы не можете заблокировать доступ администратору.");
                    return;
                }
                else
                {
                    if (selectUser.active == true)
                        selectUser.active = false;
                    else
                        selectUser.active = true;
                }

                SaveChangesInDataBase();
                UploadDataBaseInfo();
            }
            else if (TabControlMain.SelectedIndex == 4)
            {
                Articles selectArticle = ArticlesGrid.SelectedItem as Articles;
                if (selectArticle.active == true)
                    selectArticle.active = false;
                else
                    selectArticle.active = true;

                SaveChangesInDataBase();
                UploadDataBaseInfo();
            }
            else MessageBox.Show("Вы не можете взаимодействовать с полем Active в других разделах кроме 'Пользователи' и 'Статьи'.");
        }
        void SaveChangesInDataBase()
        {
            try
            {
                AstronomyClassDBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            AstronomyClassDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AstronomyClassDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                SaveChangesInDataBase();
                UploadDataBaseInfo();
            }
        }

        private void EditRoles_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.Navigate(new EditRoleAdmin((sender as Button).DataContext as Roles));
            SaveChangesInDataBase();
            UploadDataBaseInfo();
        }

        private void EditClasses_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.Navigate(new EditClassAdmin((sender as Button).DataContext as Classes));
            SaveChangesInDataBase();
            UploadDataBaseInfo();
        }

        private void EditArticleTypes_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.Navigate(new EditArticleTypeAdmin((sender as Button).DataContext as ArticleTypes));
            SaveChangesInDataBase();
            UploadDataBaseInfo();
        }

        private void EditUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.Navigate(new EditUserAdmin((sender as Button).DataContext as Users));
            UploadDataBaseInfo();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == 0)
                Manager.AdminLoadPage.Navigate(new EditRoleAdmin(null));
            else if (TabControlMain.SelectedIndex == 1)
                Manager.AdminLoadPage.Navigate(new EditClassAdmin(null));
            else if (TabControlMain.SelectedIndex == 2)
                Manager.AdminLoadPage.Navigate(new EditUserAdmin(null));
            else if (TabControlMain.SelectedIndex == 3)
                Manager.AdminLoadPage.Navigate(new EditArticleTypeAdmin(null));
            else
                MessageBox.Show("Вы можете добавлять записи только в таблицы Ролей, Классов, Пользователей и Типы статей.");

        }
    }
}
