using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzienniczekE.Data;
using DzienniczekE.Data.Tables;
using DzienniczekE.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DzienniczekE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentInfoPage : ContentPage
    {
        Student student { get; set; }
        List<Grade> grades { get; set; }
        public StudentInfoPage(Student student)
        {
            InitializeComponent();
            this.student = student;

            using (var db = new ApplicationDbContext())
            {
                grades = db.Grades.Where(g => g.StudentId == student.StudentId).ToList();

                if(grades.Count > 0)
                    avgGrade.Text = $"Srednia: {grades.Select(g => g.Value).Average()}";
                else
                    avgGrade.Text = "Brak ocen, aby wyliczyc srednia";
            }
            BindingContext = new StudentInfoViewModel { grades = grades };
        }

        private async void OnNewGradeBtn_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGradePage(student));
        }
    }
}