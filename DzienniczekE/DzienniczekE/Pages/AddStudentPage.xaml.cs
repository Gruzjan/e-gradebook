using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzienniczekE.Data.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DzienniczekE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudentPage : ContentPage
    {
        public AddStudentPage()
        {
            InitializeComponent();
        }

        private async void CreateStudentClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string surname = surnameEntry.Text;
            if (name != string.Empty && surname != string.Empty)
            {
                using (var db = new Data.ApplicationDbContext())
                {
                    db.Students.Add(new Student
                    {
                        FirstName = name,
                        LastName = surname
                    });

                    db.SaveChanges();
                }
                await Navigation.PopAsync();
            }
        }
    }
}