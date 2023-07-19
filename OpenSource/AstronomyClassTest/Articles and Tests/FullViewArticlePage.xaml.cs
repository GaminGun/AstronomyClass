using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для FullViewArticlePage.xaml
    /// </summary>
    public partial class FullViewArticlePage : Page
    {
        Articles currentArticle;
        Users user;
        public FullViewArticlePage(Articles articleView, Users user)
        {
            InitializeComponent();
            this.user = user;
            List<Articles> article = new List<Articles> { articleView };
            OutputFullInfoArticle.ItemsSource = article;
            currentArticle = articleView;

            TimeForTestInput.Text = "Время теста (мин)";
            VisibleButton();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.GoBack();
        }

        private void RunTestBtn_Click(object sender, RoutedEventArgs e)
        {
            var test = AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id);
            if (AstronomyClassDBEntities.GetContext().Marks.FirstOrDefault(p => p.id_student == user.id && p.id_test == test.id) == null)
                Manager.MainLoadPage.Navigate(new PassingTest(user, AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id)));
            else MessageBox.Show("Вы уже прошли этот тест.");
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            if (user.id_role == 2)
            {
                if (AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id == currentArticle.id) == null)
                {
                    if (TimeForTestInput.Text != null && !Regex.IsMatch(TimeForTestInput.Text, @"[a-zA-Zа-яА-Я]"))
                    {
                        Tests newTest = new Tests();
                        newTest.id_article = currentArticle.id;
                        newTest.time = Convert.ToInt32(TimeForTestInput.Text);
                        try
                        {
                            AstronomyClassDBEntities db = new AstronomyClassDBEntities();
                            db.Tests.Add(newTest);
                            Manager.MainLoadPage.Navigate(new AddEditQuestionPage(newTest, user, db));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    else MessageBox.Show("Введите время для прохождения теста (в минутах)");

                }
                else MessageBox.Show("Тест к данной статье уже существует.");
            }
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.Navigate(new AddEditQuestionPage(AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id), user, AstronomyClassDBEntities.GetContext()));
        }

        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            Tests searchTest = AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id);
            List<Questions> oldQuestions = AstronomyClassDBEntities.GetContext().Questions.Where(p => p.id_test == searchTest.id).ToList();
            if (MessageBox.Show("Вы точно хотите удалить тест?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AstronomyClassDBEntities.GetContext().Questions.RemoveRange(oldQuestions);
                    AstronomyClassDBEntities.GetContext().Tests.Remove(searchTest);
                    AstronomyClassDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Тест удалён");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            VisibleButton();
        }

        void VisibleButton()
        {
            if (user.id_role == 1 && AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id) != null)
                RunTestBtn.Visibility = Visibility.Visible;
            else
                RunTestBtn.Visibility = Visibility.Collapsed;
            if (user.id_role != 1 && AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id) != null)
            {
                EditTest.Visibility = Visibility.Visible;
                DeleteTest.Visibility = Visibility.Visible;
            }
            else
            {
                EditTest.Visibility = Visibility.Collapsed; ;
                DeleteTest.Visibility = Visibility.Collapsed; ;
            }
            if (user.id_role == 2 && AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id) == null)
            {
                CreateTest.Visibility = Visibility.Visible;
                TimeForTestInput.Visibility = Visibility.Visible;
            }
            else
            {
                TimeForTestInput.Visibility = Visibility.Collapsed;
                CreateTest.Visibility = Visibility.Collapsed;
            }
            if (user.id_role == 2 && AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id) != null)
                ViewMarkThisTest.Visibility = Visibility.Visible;
            else
                ViewMarkThisTest.Visibility = Visibility.Collapsed;
            if (user.id_role != 1)
                GenerateReportArticle.Visibility = Visibility.Visible;
            else
                GenerateReportArticle.Visibility = Visibility.Collapsed;
        }

        private void TimeForTestInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TimeForTestInput.Text == "Время теста (мин)")
                TimeForTestInput.Text = "";
        }

        private void TimeForTestInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TimeForTestInput.Text == "")
                TimeForTestInput.Text = "Время теста (мин)";
        }

        private void ViewMarkThisTest_Click(object sender, RoutedEventArgs e)
        {
            if (user.id_role == 2)
            {
                Tests searchTest = AstronomyClassDBEntities.GetContext().Tests.FirstOrDefault(p => p.id_article == currentArticle.id);
                ViewMark_GenerateReport viewMarkWin = new ViewMark_GenerateReport(user, searchTest);
                viewMarkWin.ShowDialog();
            }
        }

        private void GenerateReportArticle_Click(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            Excel.Worksheet worksheet = application.Worksheets.Item[1];


            worksheet.Cells[1][startRowIndex] = "Название";
            worksheet.Cells[2][startRowIndex] = "Тип";
            worksheet.Cells[3][startRowIndex] = "Дистанция от Земли";
            worksheet.Cells[4][startRowIndex] = "Размер";
            worksheet.Cells[5][startRowIndex] = "Масса";

            startRowIndex++;

            worksheet.Cells[1][startRowIndex] = currentArticle.name_article;
            worksheet.Cells[2][startRowIndex] = currentArticle.ArticleTypes.name_type;
            worksheet.Cells[3][startRowIndex] = currentArticle.distance;
            worksheet.Cells[4][startRowIndex] = currentArticle.size;
            worksheet.Cells[5][startRowIndex] = currentArticle.weight;

            startRowIndex++;
            worksheet.Columns.AutoFit();
            application.Visible = true;
        }
    }
}
