using DzienniczekE.Data;
using DzienniczekE.Models;
using DzienniczekE.Data.Tables;
using DzienniczekE.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DzienniczekE
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel model { get; set; }
        public MainPage()
        {
            InitializeComponent();

            model = new MainPageViewModel();

            using (var db = new ApplicationDbContext())
            {
                model.Students = db.Students.ToList();
            }

            BindingContext = model;
        }

        private async void OnAddBtn_Click(object sender, EventArgs e) 
        {
            using (var db = new ApplicationDbContext())
            {
                db.Students.Add(new Student
                {
                    FirstName = "Johnny",
                    LastName = "Test"
                });

                await db.SaveChangesAsync();
            }
            //TODO: refresh list
        }

        private async void OnNewBtn_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStudentPage());
        }

        private async void OnStudentSelected(object sender, SelectionChangedEventArgs e)
        {
            Student studentSelected = e.CurrentSelection.FirstOrDefault() as Student;
            if (studentSelected != null)
            {
                await Navigation.PushAsync(new StudentInfoPage(studentSelected));
                studentsCollection.SelectedItem = null;
            }
        }
    }
}
