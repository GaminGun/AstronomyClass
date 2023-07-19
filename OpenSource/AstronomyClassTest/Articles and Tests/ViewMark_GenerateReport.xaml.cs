using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для ViewMark_GenerateReport.xaml
    /// </summary>
    public partial class ViewMark_GenerateReport : Window
    {
        Tests test = new Tests();
        Users user = new Users();
        public ViewMark_GenerateReport(Users user, Tests test)
        {
            InitializeComponent();
            this.test = test;
            this.user = user;
            if (test != null)
                OutputMarks.ItemsSource = AstronomyClassDBEntities.GetContext().Marks.Where(p => p.id_test == test.id && p.Users.id_class == user.id_class).ToList();
            else
                OutputMarks.ItemsSource = AstronomyClassDBEntities.GetContext().Marks.Where(p => p.Users.id_class == user.id_class).ToList();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            Excel.Worksheet worksheet = application.Worksheets.Item[1];


            worksheet.Cells[1][startRowIndex] = "Фамилия";
            worksheet.Cells[2][startRowIndex] = "Имя";
            worksheet.Cells[3][startRowIndex] = "Отчество";
            worksheet.Cells[4][startRowIndex] = "Класс";
            worksheet.Cells[5][startRowIndex] = "Статья";
            worksheet.Cells[6][startRowIndex] = "Дата прохождения";
            worksheet.Cells[7][startRowIndex] = "Оценка";

            startRowIndex++;

            List<Marks> marks = new List<Marks>();
            if (test != null)
                marks = AstronomyClassDBEntities.GetContext().Marks.Where(p => p.id_test == test.id && p.Users.id_class == user.id_class).ToList();
            else
                marks = AstronomyClassDBEntities.GetContext().Marks.Where(p => p.Users.id_class == user.id_class).ToList();

            foreach (var mark in marks)
            {
                worksheet.Cells[1][startRowIndex] = mark.Users.last_name;
                worksheet.Cells[2][startRowIndex] = mark.Users.first_name;
                worksheet.Cells[3][startRowIndex] = mark.Users.surname;
                worksheet.Cells[4][startRowIndex] = mark.Users.Classes.name_class;
                worksheet.Cells[5][startRowIndex] = mark.Tests.Articles.name_article;
                worksheet.Cells[6][startRowIndex] = mark.finish_date.ToShortDateString();
                worksheet.Cells[7][startRowIndex] = mark.mark;
                startRowIndex++;
            }
            worksheet.Columns.AutoFit();
            application.Visible = true;
        }
    }
}

