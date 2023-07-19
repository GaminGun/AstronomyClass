using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для AddEditQuestionPage.xaml
    /// </summary>
    public partial class AddEditQuestionPage : Page
    {
        Questions question = new Questions();
        Tests test = new Tests();
        Users user;
        AstronomyClassDBEntities db;
        List<Questions> oldQuestions = new List<Questions>();
        public AddEditQuestionPage(Tests test, Users user, AstronomyClassDBEntities db)
        {
            InitializeComponent();
            this.db = db;

            if (this.db.Questions.Where(p => p.id_test == test.id).ToList().Count() > 0)
            {
                oldQuestions = this.db.Questions.Where(p => p.id_test == test.id).ToList();
                if (Manager.NumberQuestion < oldQuestions.Count)
                {
                    question = oldQuestions[Manager.NumberQuestion];
                    if (question.answer_3 != null)
                    {
                        AdditionalAnswer.IsChecked = true;
                    }
                }
                else
                {
                    question = new Questions();
                }
            }

            this.user = user;
            this.test = test;

            DataContext = question;
        }

        private void AdditionalAnswer_Checked(object sender, RoutedEventArgs e)
        {
            BlockAnswer3.Visibility = Visibility.Visible;
            BlockAnswer4.Visibility = Visibility.Visible;
        }

        private void AdditionalAnswer_Unchecked(object sender, RoutedEventArgs e)
        {
            BlockAnswer3.Visibility = Visibility.Collapsed;
            BlockAnswer4.Visibility = Visibility.Collapsed;
        }

        private void SaveTest_Click(object sender, RoutedEventArgs e)
        {
            ExaminationInputData();
            if (nextOperation == true)
            {
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Тест сохранён");
                    GoBackUsMainPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                Manager.NumberQuestion = 0;
            }
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            ExaminationInputData();
            if (nextOperation == true)
            {
                Manager.NumberQuestion++;
                Manager.MainLoadPage.Navigate(new AddEditQuestionPage(test, user, db));
            }
        }
        bool nextOperation;
        void ExaminationInputData()
        {
            StringBuilder errors = new StringBuilder();
            if (QuestionText.Text == "")
                errors.AppendLine("Текст вопроса не может быть пустым.");
            if (AnswerOne.Text == "")
                errors.AppendLine("Поле первого ответа не может быть пустым.");
            if (AnswerTwo.Text == "")
                errors.AppendLine("Поле второго ответа не может быть пустым.");
            if (Regex.IsMatch(TrueAsnwer.Text, @"[a-zA-Zа-яА-Я567890]"))
                errors.AppendLine("Используйте только номера существующих ответов.");

            if (AnswerThree.Text == "" && AnswerFour.Text != "")
            {
                errors.AppendLine("Заполните поля ответов корректно и по порядку.");
                if (TrueAsnwer.Text == "3" || TrueAsnwer.Text == "4")
                    errors.AppendLine("При некорректном заполнении дополнительных ответов не могут быть указаны номера правильных ответов 3 или 4. Заполните данные верно.");
            }
            if (AnswerFour.Text == "" && AnswerThree.Text != "")
                if (TrueAsnwer.Text == "4")
                    errors.AppendLine("Номер правильного ответа не может быть четвёртым. Ответ пустой.");
            if (AnswerThree.Text == "" && AnswerFour.Text == "")
                if (TrueAsnwer.Text == "3" || TrueAsnwer.Text == "4")
                    errors.AppendLine("Некорректный номер правильного ответа. Поля ответов три и четыре пусты.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                nextOperation = false;
                return;
            }

            if (question.id == 0)
            {
                question.id_test = test.id;
                question.answer_1 = AnswerOne.Text;
                question.answer_2 = AnswerTwo.Text;
                if (AdditionalAnswer.IsChecked == true)
                {
                    if (AnswerThree.Text != "")
                        question.answer_3 = AnswerThree.Text;
                    if (AnswerThree.Text != "" && AnswerFour.Text != "")
                        question.answer_4 = AnswerFour.Text;
                }
                question.true_answer = Convert.ToInt32(TrueAsnwer.Text);
                if (question.id == 0)
                    db.Questions.Add(question);
                nextOperation = true;
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            GoBackUsMainPage();
        }

        void GoBackUsMainPage()
        {
            Manager.MainLoadPage.RemoveBackEntry();
            Manager.MainLoadPage.Navigate(new OutputArticlesPage(user));
        }
    }
}