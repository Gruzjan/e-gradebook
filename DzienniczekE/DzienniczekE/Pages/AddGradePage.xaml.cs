using DzienniczekE.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DzienniczekE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGradePage : ContentPage
    {
        Student student;
        public AddGradePage(Student Student)
        {
            InitializeComponent();
            student = Student;
        }

        private async void AddGrade_Clicked(object sender, EventArgs e)
        {
            int value = int.Parse(gradeValue.Text);
            if (gradeValue.Text != string.Empty && value < 7 && value > 0)
            {
                using (var db = new Data.ApplicationDbContext())
                {
                    db.Grades.Add(new Grade
                    {
                        Value = value,
                        StudentId = student.StudentId
                    });
                    db.SaveChanges();
                }
                await Navigation.PopAsync();
                //TODO: refresh students info page
            }
        }
    }
}