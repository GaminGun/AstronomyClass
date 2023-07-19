using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для OutputQuestionOnPage.xaml
    /// </summary>
    public partial class OutputQuestionOnPage : Page
    {
        Users user;
        Tests test;
        
        int currentUserAnswer = 0;
        public OutputQuestionOnPage(Users user, Tests test)
        {
            InitializeComponent();
            if (Manager.UserAnswer == null)
                Manager.UserAnswer = new List<int>();

            this.user = user;
            this.test = test;

            if (Manager.ListQuestions == null)
                Manager.ListQuestions = AstronomyClassDBEntities.GetContext().Questions.Where(p => p.id_test == test.id).ToList();
            DataContext = Manager.ListQuestions[Manager.NumberQuestion];

            if (Manager.CountQuestions == 0)
                Manager.CountQuestions = Manager.ListQuestions.Count();

            if (Manager.ListQuestions[Manager.NumberQuestion].answer_3 != null)
                AnswerThreeBtn.Visibility = Visibility.Visible;
            if (Manager.ListQuestions[Manager.NumberQuestion].answer_3 != null && Manager.ListQuestions[Manager.NumberQuestion].answer_4 != null)
            {
                AnswerThreeBtn.Visibility = Visibility.Visible;
                AnswerFourBtn.Visibility = Visibility.Visible;
            }
            if (Manager.UserAnswer.Count == Manager.ListQuestions.Count - 1)
            {
                nextOperation = false;
                NextQuestionBtn.IsEnabled = false;
            }
        }

        bool nextOperation = true;
        private void NextQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nextOperation == true)
            {
                Manager.NumberQuestion++;
                if (currentUserAnswer == 0)
                {
                    return;
                }
                Manager.UserAnswer.Add(currentUserAnswer);
                Manager.OutputQuestions.Navigate(new OutputQuestionOnPage(user, test));
            }
        }
        private void EndTestBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.UserAnswer.Add(currentUserAnswer);
            for (int i = 0; i < Manager.ListQuestions.Count; i++)
                if (Manager.UserAnswer.Count != Manager.ListQuestions.Count)
                    Manager.UserAnswer.Add(0);
            for (int index = 0; index < Manager.UserAnswer.Count; index++)
                if (Manager.ListQuestions[index].true_answer == Manager.UserAnswer[index])
                    Manager.TrueAnswer++;
            Marks newMark = new Marks();
            int percent = (Manager.TrueAnswer * 100) / Manager.CountQuestions;
            if (percent >= 85)
                newMark.mark = 5;
            else if (percent >= 70)
                newMark.mark = 4;
            else if (percent >= 50)
                newMark.mark = 3;
            else
                newMark.mark = 2;

            newMark.id_test = test.id;
            newMark.id_student = user.id;
            newMark.finish_date = DateTime.Now;
            try
            {
                MessageBox.Show($"Тест завершён.\nВаша оценка: {newMark.mark}\nПроцент правильных ответов: {percent}%");
                AstronomyClassDBEntities.GetContext().Marks.Add(newMark);
                AstronomyClassDBEntities.GetContext().SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Manager.TrueAnswer = 0;
            Manager.NumberQuestion = 0;
            Manager.ListQuestions = null;
            Manager.UserAnswer = null;
            Manager.MainLoadPage.RemoveBackEntry();
            Manager.MainLoadPage.Navigate(new OutputArticlesPage(user));
        }

        private void AnswerOneBtn_Checked(object sender, RoutedEventArgs e)
        {
            currentUserAnswer = 1;
        }

        private void AnswerTwoBtn_Checked(object sender, RoutedEventArgs e)
        {
            currentUserAnswer = 2;
        }

        private void AnswerThreeBtn_Checked(object sender, RoutedEventArgs e)
        {
            currentUserAnswer = 3;
        }

        private void AnswerFourBtn_Checked(object sender, RoutedEventArgs e)
        {
            currentUserAnswer = 4;
        }
    }
}
